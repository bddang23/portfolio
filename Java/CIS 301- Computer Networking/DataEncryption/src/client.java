import java.io.*;
import java.net.*;
import java.util.*;

public class client{
	public static void main(String[] args) throws Exception
	{
		//instantiate scaanner input for name
		Scanner input = new Scanner(System.in);
		
		String serverResponse;
		String name;
		String SSN;
		
		//read in the name and then validate the name
		System.out.print("Enter the name of the person: ");
		name = input.nextLine();
		name = nameValidate(name);
		
		//create a socket port 4000
		Socket socket = new Socket("localhost", 4000);
		
		PrintWriter out = new PrintWriter(socket.getOutputStream(), true);  /*  socket.getOutputStream() returns an output stream for this socket. 
																				PrintWriter(socket.getOutputStream(), true) creates a new PrintWriter from an existing OutputStream. 
																				This convenience constructor creates the necessary intermediateOutputStreamWriter, 
																				which will convert characters into bytes using the default character encoding.*/

		BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));/* socket.getInputStream() returns an input stream for this socket. 
																								  new InputStreamReader(socket.getInputStream()) creates an InputStreamReader that uses the default charset.
																								  new BufferedReader(new InputStreamReader(socket.getInputStream())) creates a buffering character-input stream that uses a default-sized input buffer.
																								*/
		//send the information to the server with the encrypted name name
		out.println(encryptData(name));
		
		//after server response, read the result
		serverResponse = in.readLine();
		
		//System.out.println(serverResponse);
		//decrypt the SSN 
		SSN = decryptData(serverResponse);

		System.out.println("The SSN for "+ name +" is: "+ SSN);	
		
		input.close();
		socket.close();
		}
	
	//this function validate the name in which later return a name that\
	//have one first upper case character in every word. 
	public static String nameValidate (String name) {
		name= name.toLowerCase();
		Scanner s = new Scanner(System.in);
		//run a condition that must have first and last name by having a space
		//then later run through the name and make the name with the rule
			if (name.contains(" ")){
				String[] arrName = name.split(" ");
				String first = arrName[0].trim();
				String last = arrName[1].trim();
						
				name ="";
				name += first.substring(0, 1).toUpperCase();
				name += first.substring(1) +" ";
				name += last.substring(0, 1).toUpperCase();
				name += last.substring(1);
			}
			//if name doesnt have first and last name then let user try again
			else {
				System.out.println("Try again with first and last name!");
				name = s.nextLine();
				nameValidate(name);
			}			
		return name;
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
