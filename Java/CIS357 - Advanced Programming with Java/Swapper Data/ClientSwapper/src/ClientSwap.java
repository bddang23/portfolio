import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.sql.*;
import java.util.Scanner;

public class ClientSwap {

    static Connection connection;
    Socket s;
    PrintWriter ostream;
    Scanner istream;

    public ClientSwap() throws SQLException, IOException {
        String url = "jdbc:sqlite:ClientDB.db";

        //initialize your connection and socket objects
        // Connect to database, the file should already be in your path
        //remember to add your sqlite driver in your project structure
        connection = DriverManager.getConnection(url);
        System.out.println("Connected to DB");


        //create a new client socket and connect to server on localhost
        s= new Socket("localhost",8500);
        istream = new Scanner(s.getInputStream());
        ostream = new PrintWriter(s.getOutputStream(),true);

        System.out.println("Connected to Server");
    }



    public void sendWord(String s){
        // this method takes a word s, and sends it to the output stream
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

        // use the methods you have defined to do the swaps./
        //start a loop from 1 to 5
        // get the ith word from the db
        //send the ith word to the server
        //get the server's ith word
        //update this word to the ith position in DB
        for (int i = 1; i <=5 ; i++) {
            String CLWord = getWordFromDB(i);
            sendWord(CLWord);
            String receive = recvWord();
            updateWordToDB(i,receive);
        }

    }

    public static void main(String args[]) throws IOException, SQLException, InterruptedException {
        ClientSwap x = new ClientSwap(); // create a new client object, calls the constructor, sets up the db and socket conns
        printDB();
        x.doSwap(); //invoke doSwap to start the swapping process
        System.out.println("\n_________________________________");
        printDB();
    }

    public static void printDB() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT word FROM tblWords");
        ResultSet rs= ps.executeQuery();
        while(rs.next()){
            System.out.print(rs.getString(1) + " ");
        }
    }

}

