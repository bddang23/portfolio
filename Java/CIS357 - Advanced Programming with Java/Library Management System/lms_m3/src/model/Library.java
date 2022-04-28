package model;
import DAO.BookDAO;
import DAO.TransactionDAO;
import DAO.UserDAO;

import java.sql.SQLException;
import java.time.LocalDate;
import java.time.Period;
import java.util.*;

public class Library {
    private int MAX_BOOK_LIMIT=3;
    private int MAX_LOAN_DAYS=14;
    private boolean DEBUG_DATE=false;

    private static final String URL = "jdbc:sqlite:library.db";

   private TransactionDAO transactionDAO;
    private UserDAO userDAO;
    private BookDAO bookDAO;
    public ArrayList<String> msgLog;

    public ArrayList<Transaction> getTransactionDAO() throws SQLException {
        return transactionDAO.getAll();
    }

    public ArrayList<User> getUserDAO() throws SQLException {
        return userDAO.getAll();
    }

    public ArrayList<Book> getBooks() throws SQLException {
        return bookDAO.getAll();
    }

    public Library() throws SQLException {
        transactionDAO = new TransactionDAO(URL);
        userDAO = new UserDAO(URL);
        bookDAO = new BookDAO(URL);
        msgLog =new ArrayList<String>();

    }

    public void addBook(Book b) throws SQLException {
        bookDAO.insert(b);
        msgLog.add("Book ID "+b.getID()+" added to Library");
    }
    public void addUser(User u) throws SQLException {
        userDAO.insert(u);
        msgLog.add("User ID "+u.getID()+" added to Library");
    }
    public void addTransaction(Transaction t) throws SQLException {
        transactionDAO.insert(t);
    }
    public boolean isAvailable(int bookID) throws SQLException {
        for(Transaction t: transactionDAO.getByBook(bookID)){
            if (t.isStatus())
                return false;
        }
        return true;
    }
    public int getBorrowCount(int userID) throws SQLException {
        int count=0;
        for(Transaction t: transactionDAO.getByUser(userID)){
            if (t.isStatus())
                count++;
        }
        return count;
    }


    public LocalDate getDueDate(LocalDate issueDate) {
        return issueDate.plusDays(MAX_LOAN_DAYS);
    }


    public boolean issueBook(int userID, int bookID) throws SQLException {
        User u = getUser(userID);
        Book b = getBook(bookID);

        //check if book is unavailable
        if (!isAvailable(bookID)){
            msgLog.add("This book is currently unavailable!");
            return false;
        }

        //check if max books limit has been reached or outstanding fines
        if (getBorrowCount(userID) >= MAX_BOOK_LIMIT) {
            msgLog.add("User has reached the maximum limit of borrowed books!");
            return false;
        }
        //check if user has outstanding balance
        if (u.getBalance() > 0){
            msgLog.add("User has an outstanding balance of $"+u.getBalance()+"!");
            return false;
        }

        // ready to issue book.
        Transaction trans = new Transaction(bookID,userID);
        addTransaction(trans);
        msgLog.add(b.getName()+" has been issued to "+u.getName()+"." );
        msgLog.add("The due date is "+getDueDate(trans.getIssueDate()));
        return true;
    }

    public boolean returnBook(int bookID) throws SQLException {
        Transaction trans=null;
        for (Transaction t: transactionDAO.getCurrent())
            if (t.getBookID()==bookID){
                trans = t;
                break;
            }

        if (trans==null){
            msgLog.add("Book currently not borrowed");
            return false;
        }

        //compute Fines
        int userID = trans.getUserID();
        User u = getUser(userID);
        Book b = getBook(bookID);
        double fine = computeFine(trans);
        //System.out.println(fi)

        u.setBalance(u.getBalance()+fine);
        userDAO.update(u);

        trans.setStatus(false);
        transactionDAO.update(trans);

        if(fine==0)
            msgLog.add("Thanks for returning "+b.getName()+"!");
        else {
                msgLog.add("You returned " + b.getName() + " " + fine + " days late!");
                msgLog.add("Your outstanding balance is $" + u.getBalance());
        }
        return true;

    }

    public void collectFine(User u) throws SQLException {
        if (u.getBalance()<=0){
            msgLog.add("User has no outstanding balances..");
        }
        else{
            msgLog.add("User dues collected....");
            u.setBalance(0);
            userDAO.update(u);
        }

    }

    private double computeFine(Transaction t)
    {
        if (DEBUG_DATE)
            return new Random().nextInt(20);

        Period interval = Period.between(LocalDate.now() ,t.getIssueDate());
        int ms = interval.getDays();
        if (ms<=14) //change in final
            return 0;
        return ms*1.0;


    }

    public ArrayList<Book> searchBook(String name) throws SQLException {
        if(name.equals(""))
            return bookDAO.getAll();
        else
            return bookDAO.getByQuery(name);
    }

    public ArrayList<User> searchUser(String name) throws SQLException {
        if(name.equals(""))
            return userDAO.getAll();
        else
            return userDAO.getByQuery(name);
    }


    public void printBooks(ArrayList<Book> results)
    {
        if (results.size()==0)
            msgLog.add("No books matched the search criteria");
        for (Book b: results) {
            msgLog.add("Book Id : "+b.getID()+" Book Name : "+b.getName());

        }

    }

    public void printUsers(ArrayList<User> results)
    {
        if (results.size()==0)
            msgLog.add("No users matched the search criteria");
        for (User b: results) {
            msgLog.add("User Id : "+b.getID()+" User Name : "+b.getName());

        }

    }


    public Book getBook(int bookID) throws SQLException {
        return bookDAO.getBook(bookID);
    }

    public User getUser(int userID) throws SQLException {
        return userDAO.getUser(userID);
    }

    public String getLog(){
        StringBuilder sb= new StringBuilder();

        for(String msg :msgLog){
            sb.append(msg+"\n");
        }
        msgLog.clear();
        return sb.toString();
    }

    public ArrayList<Book> getCheckedOutBooks(User u) throws SQLException {
        ArrayList<Book> res= new ArrayList<>();

        for(Transaction t: transactionDAO.getCurrent()){
            if(t.getUserID() == u.getID()){
                res.add(getBook(t.getBookID()));
            }
        }

        return res;
    }

    public ArrayList<Transaction> getActiveTransactions() throws SQLException {
        return transactionDAO.getCurrent();
    }

}
