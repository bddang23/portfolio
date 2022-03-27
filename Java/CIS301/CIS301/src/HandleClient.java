import java.io.*;
import java.net.*;
import java.util.*;

public class HandleClient implements Runnable{
	Socket socket;
	
	HandleClient(Socket socket){
	this.socket = socket;
	}
	public void run() {
		try{
			String clientInput;
			String clientName;
			String SSN = "";
			
				// add in the data file that  contains name and SSN
				// declare a scanner for  
				File data = new File("data.txt");
				Scanner s = new Scanner(data);
				
				System.out.println("Waiting for incoming connections");
				
				PrintWriter out = new PrintWriter(socket.getOutputStream(), true);  /*  socket.getOutputStream() returns an output stream for this socket. 
																						PrintWriter(socket.getOutputStream(), true) creates a new PrintWriter from an existing OutputStream. 
																						This convenience constructor creates the necessary intermediateOutputStreamWriter, 
																						which will convert characters into bytes using the default character encoding.*/

				BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));/* socket.getInputStream() returns an input stream for this socket. 
																										  new InputStreamReader(socket.getInputStream()) creates an InputStreamReader that uses the default charset.
																										  new BufferedReader(new InputStreamReader(socket.getInputStream())) creates a buffering character-input stream that uses a default-sized input buffer.
																										*/
				//read in user input
				clientInput = in.readLine();
				System.out.println("User Input is " + clientInput);
				
				//decrypt thr name calling the decryptData method
				clientName = decryptData(clientInput);
				System.out.println("After decrypt the data is "+clientName);
				
				String encrypt="";
				boolean isFound=false;
				
				//run a while loop while the data.txt file still have
				//continuing search for the SSN
				while (s.hasNext()) {
					//split the information to name part and SSN
					String[] info = s.nextLine().split(":");
					String name = info[0].trim();
					SSN = info[1].trim();
					
					//if the input name equal the name in the database
					//break the loop and assigned data to encrypt SSN
					if(clientName.equals(name)) {
						encrypt = encryptData(SSN);
						isFound = true;
						break;
					}
					
				}
				
				//if the flag isFound true, return the encrypted SSN to the client
				if (isFound) {
					out.println(encrypt);
					System.out.println("SSN found accordingly: "+SSN);
				}
				//else encrypt "Not Found" to the client
				else {
					out.println(encryptData("Not Found"));
					System.out.println("Not Found");
				}
				
				System.out.println();
				
				s.close();
				
		}	catch(Exception e) {}
	}
	
	//this method encrypt data by moving forward 5 ascii value accordingly to the charater
	public static  String  encryptData  (String  plainText) {
		String cipherText = "";
		
		//create an array of character from the plaintext
		char[] ch = plainText.toCharArray();
		
		//for each loop run through the char array then assigned it to the cipher text string 
		for(char c : ch) {
			//if c is number or an uppercase/lowercase character or a dash shift 5!
			if ((c>=48 && c<=57)||(c>=65 && c<=90)||(c>=97 && c<=122)||(c==45))
				c+=5;
			cipherText += c;
		}
		
		return cipherText;
	}
	
	//this method decrypt data by moving backward 5 ascii value accordingly to the charater
	public static String decryptData (String cipherText) {
		String plainText = "";
		
		//create an array of character from the cipherText
		char[] ch = cipherText.toCharArray();
		
		//for each loop run through the char array then assigned it to the plain TExt string 
		for(char c : ch) {
			//if c is number or an uppercase/lowercase character or a dash shift 5!
			if ((c>=53 && c<=62)||(c>=70 && c<=95)||(c>=102 && c<=127)||(c==50))
				c-=5;
			plainText += c;
		}
		return plainText;
	}
}