import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.*;
import java.util.Scanner;

public class ServerSwap {

    static Connection connection;
    ServerSocket ss;
    Socket s;
    PrintWriter ostream;
    Scanner istream;

    public ServerSwap() throws SQLException, IOException {
        String url = "jdbc:sqlite:ServerDB.db";

        ss = new ServerSocket(8500);
        s=ss.accept();

        istream = new Scanner(s.getInputStream());
        ostream = new PrintWriter(s.getOutputStream(),true);

        //initialize your connection and socket objects
        // Connect to database, the file should already be in your path
        //remember to add your sqlite driver in your project structure
        connection = DriverManager.getConnection(url);

        System.out.println("Connected to DB");


        //create a new server socket on some port and wait for a client to connect,
        // once connected assign the socket
        System.out.println("Connected to Client");
    }


    public void sendWord(String s){
        // this method takes a word s, and sends it to the output stream, make sure to flush
        ostream.println(s);
        ostream.flush();
    }

    public String recvWord(){
        // this method will read it's input stream, read a word/line and return it
       String word = istream.nextLine();
        return word;

    }

    public String getWordFromDB(int idx) throws SQLException {
        // this method will get the word corresponding to the row passed in as idx and return it as a string
        PreparedStatement ps = connection.prepareStatement("SELECT word FROM tblWords WHERE id = ?");
        ps.setInt(1,idx);
        ResultSet rs= ps.executeQuery();
        String word= rs.getString(1);
        return word;
    }

    public void updateWordToDB(int idx, String word) throws SQLException {
        // this method will accept a ID and word, and update the entry with the matching ID with the passed in word
        PreparedStatement ps = connection.prepareStatement("UPDATE tblWords SET word = ? WHERE id = ?");
        ps.setString(1,word);
        ps.setInt(2,idx);
        ps.executeUpdate();
    }

    public void doSwap() throws InterruptedException, SQLException {

        // use the methods you have defined to do the swaps.
        //start a loop from 1 to 5
        // do the same thing as on the client side. keep in mind the client gets to send first,
        // so you want to first get the word from the client,then send your own word
        // and then update your table with the clients word
        for (int i = 1; i <=5 ; i++) {
            String SVWord = getWordFromDB(i);
            String receive = recvWord();

            sendWord(SVWord);
            updateWordToDB(i,receive);
        }

    }


    public static void main(String args[]) throws IOException, SQLException, InterruptedException {
        ServerSwap x = new ServerSwap(); // create a new server object, calls the constructor, sets up the db and socket conns
        printDB();
        x.doSwap();//invoke doSwap to start the swapping process
        System.out.println("\n_________________________________");
        printDB();

    }
    public static void printDB() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT word FROM tblWords");
        ResultSet rs= ps.executeQuery();
        while(rs.next()){
            System.out.print(rs.getString(1)+ " ");
        }
    }
}
