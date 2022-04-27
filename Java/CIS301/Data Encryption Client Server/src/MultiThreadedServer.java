import java.io.*;
import java.net.*;

public class MultiThreadedServer {
	public static void main(String[] args) throws IOException {
		ServerSocket s = new ServerSocket(9000);
		while(true) {
			Socket socket = s.accept();
			HandleClient c = new HandleClient(socket);
			Thread t = new Thread(c);
			t.start();
		}
		
	}
}
