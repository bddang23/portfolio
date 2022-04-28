package DAO;

import model.Transaction;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;

public class TransactionDAO {
    Connection connection;
    int row;

    public TransactionDAO(String url) throws SQLException {
        connection = DriverManager.getConnection(url);
    }

    public void insert(Transaction t) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("INSERT INTO libTransactions VALUES(?,?,?,?)");
        ps.setInt(1,t.getBookID());
        ps.setInt(2,t.getUserID());

        //Local date instance
        LocalDate localDate = t.getIssueDate();
        //Get LocalDate from SQL date
        java.sql.Date sqlDate = java.sql.Date.valueOf( localDate );

        ps.setDate(3,sqlDate);
        ps.setBoolean(4,t.isStatus());

        ps.executeUpdate();
    }

    public void update(Transaction t) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("UPDATE libTransactions SET STATUS=? WHERE BOOKID= ? AND USERID= ? AND ISSUEDATE=?");
        ps.setBoolean(1,t.isStatus());
        ps.setInt(2,t.getBookID());
        ps.setInt(3,t.getUserID());
        //change localdate to sqlDate
        LocalDate localDate = t.getIssueDate();
        java.sql.Date sqlDate = java.sql.Date.valueOf(localDate);
        ps.setDate(4,sqlDate);

        ps.executeUpdate();
    }

    public void delete(Transaction t) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("DELETE FROM libTransactions WHERE BOOKID= ? AND USERID= ? AND ISSUEDATE=?");
        ps.setInt(1, t.getBookID());
        ps.setInt(2, t.getUserID());

        LocalDate localDate = t.getIssueDate();
        java.sql.Date sqlDate = java.sql.Date.valueOf(localDate);
        ps.setDate(3, sqlDate);

        ps.executeUpdate();
    }

    public ArrayList<Transaction> getAll() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM libTransactions ");
        return getTransactions(ps);
    }
    public ArrayList<Transaction> getCurrent() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM libTransactions WHERE status = ?");
        ps.setBoolean(1,true);
        return getTransactions(ps);
    }
    public ArrayList<Transaction> getByUser(int UserID) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM libTransactions WHERE USERID=?");
        ps.setInt(1,UserID);
        return getTransactions(ps);
    }
    public ArrayList<Transaction> getByBook(int BookID) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM libTransactions WHERE BOOKID=?");
        ps.setInt(1,BookID);
        return getTransactions(ps);
    }
    private ArrayList<Transaction> getTransactions(PreparedStatement ps) throws SQLException {
        ResultSet rs = ps.executeQuery();
        ArrayList<Transaction> transactions = new ArrayList<>();
        while(rs.next()){
            Date sqlDate = rs.getDate(3);
            LocalDate localDate = sqlDate.toLocalDate();

            Transaction temp = new Transaction(
                    rs.getInt(1),
                    rs.getInt(2),
                    localDate,
                    rs.getBoolean(4)
            );
            transactions.add(temp);

        }
        rs.close();
        return transactions;
    }


}
