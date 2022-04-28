package Library_OOP;

import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;

public class Library {
    private int MAX_BOOK_LIMIT=3;
    private int MAX_LOAN_DAYS=14;


    public ArrayList<Transaction> transactions;
    public ArrayList<User> users;
    public ArrayList<Book> books;
    public ArrayList<String> msgLog;

    public Library()
    {
        transactions = new ArrayList<Transaction>();
        users = new ArrayList<User>();
        books = new ArrayList<Book>();
        msgLog =new ArrayList<String>();
    }

    public void addBook(Book b)
    {
        books.add(b);
        msgLog.add("Book ID "+b.getID()+" added to Library");
    }
    public void addUser(User u)
    {
        users.add(u);
        msgLog.add("User ID "+u.getID()+" added to Library");
    }
    public void addTransaction(Transaction t)
    {
        transactions.add(t);
    }
    public boolean isAvailable(int bookID){
        for(Transaction t:transactions){
            if (t.getBookID() == bookID && t.isStatus())
                return false;
        }
        return true;

    }
    public int getBorrowCount(int userID){
        int count=0;
        for(Transaction t: transactions){
            if (t.getUserID()== userID && t.isStatus())
                count++;
        }
        return count;
    }


    public LocalDate getDueDate(LocalDate issueDate) {

        return issueDate.plusDays(MAX_LOAN_DAYS);
    }


    public boolean issueBook(int userID, int bookID)
    {
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
        transactions.add(trans);
        msgLog.add(b.getName()+" has been issued to "+u.getName()+"." );
        msgLog.add("The due date is "+getDueDate(trans.getIssueDate()));
        return true;
    }

    public boolean returnBook(int bookID)
    {
        Transaction trans=null;
        for (Transaction t: transactions)
            if (t.getBookID()==bookID && t.isStatus()){
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
        trans.setStatus(false);
        if(fine==0)
            msgLog.add("Thanks for returning "+b.getName()+"!");
        else {
                msgLog.add("You returned " + b.getName() + " " + fine + " days late!");
                msgLog.add("Your outstanding balance is $" + u.getBalance());
        }
        return true;

    }

    public void collectFine(User u){
        if (u.getBalance()<=0){
            msgLog.add("User has no outstanding balances..");
        }
        else{
            msgLog.add("User dues collected....");
            u.setBalance(0);
        }

    }

    private double computeFine(Transaction t)
    {

        long days = t.getIssueDate().until(LocalDate.now(), ChronoUnit.DAYS);
        if (days<=MAX_LOAN_DAYS)
            return 0;

        return days;

    }

    public ArrayList<Book> searchBook(String name)
    {
        ArrayList<Book> results= new ArrayList<Book>();
        for (Book b: books) {
            if (b.getName().contains(name))
                results.add(b);
        }

        return results;
    }

    public void printResults(ArrayList<Book> results)
    {
        if (results.size()==0)
            msgLog.add("No books matched the search criteria");
        for (Book b: results) {
            msgLog.add("Book Id : "+b.getID()+" Book Name : "+b.getName());
        }

    }


    public Book getBook(int bookID){
        for (Book temp : books){
            if (temp.getID()==bookID){
                return temp;
            }
        }
        return null;
    }

    public User getUser(int userID){
        for (User temp : users){
            if (temp.getID()==userID){
                return temp;
            }
        }
        return null;
    }

    public void getLog() {
        msgLog.clear();
    }
}
