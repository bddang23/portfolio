
import java.io.*;
import java.net.*;

public class server {
	public static void main(String[] args) throws Exception{
		//create a server socket on port 4000
		ServerSocket serversocket = new ServerSocket(4000);
		
		//this loop accept multiple clients
		while (true) {
				Socket socket = serversocket.accept();
				HandleClient c = new HandleClient(socket);
				Thread t = new Thread(c);
				t.start();
		}
	}
	
}


