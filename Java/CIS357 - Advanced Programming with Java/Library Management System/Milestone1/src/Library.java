import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.Locale;

public class Library {
    //declare necessary variable for the Library
    private static final int MAX_BOOK_LIMIT = 3;
    private static final int MAX_LOAN_DAYS = 14;
    ArrayList<Transaction> transactions = new ArrayList<>();
    ArrayList<User> users = new ArrayList<>();
    ArrayList<Book> books = new ArrayList<>();
    ArrayList<String> msgLog = new ArrayList<>();

    public void addBook(Book b) {
        //add the book to the books arraylist
        books.add(b);
        msgLog.add("Book Added Successfully!");
    }

    public void addUser(User u) {
        //add user to users arraylist
        users.add(u);
        msgLog.add("User Added Successfully!");
    }

    public void addTransaction(Transaction t) {
        //add transaction to transactions arraylist
        transactions.add(t);
        msgLog.add("Transaction Successfully!");
    }

    public boolean isAvailable(int bookID) {
        //function run a loop in the transactions arraylist
        //return true, if the status is false.
        //return false, if the status is true.
        for (Transaction t : transactions) {
            if (t.getBookID() == bookID) {
                if (t.isStatus()) {
                    msgLog.add("Book " + bookID + " is not available");
                    return false;
                }else return true;
            }
        }
        msgLog.add("Book " + bookID + " is available");
        return true;
    }

    public int getBorrowCount(int userID) {
        //run through the transactions arraylist
        //if found the ID and status is true then add to counter
        //return the counter
        int counter = 0;
        for (Transaction t : transactions) {
            if (userID == t.getUserID() && t.isStatus()) {
                counter++;
            }
        }
        msgLog.add("User borrowed " + counter + " books");
        return counter;
    }

    public LocalDate getDueDate(LocalDate issueDate) {
        //add the date to the issueDate then return the due date
        LocalDate dueDate = issueDate.plusDays(MAX_LOAN_DAYS);
        msgLog.add("The due date is " + dueDate);
        return dueDate;
    }

    public boolean issueBook(int userID, int bookID) {
        //first check if the user exceed the borrow-count and checking if the
        //book is available to issue. if satisfied, get the user through userID,
        //check if user's balance exceed 0, then add the transaction
        if (getBorrowCount(userID) == MAX_BOOK_LIMIT || isAvailable(bookID) == false) {
            msgLog.add("Cannot issue Book");
            return false;
        }else{
            User u = getUser(userID);
            if (u!=null){
                if(u.getBalance()>0) {
                    msgLog.add("Cannot issue Book");
                    return false;
                }else{
                    addTransaction(new Transaction(bookID, userID));
                    msgLog.add("Issue Book Successfully");
                    return true;
                }
            }
        }
        return false;
    }

    public boolean returnBook(int bookID){
        //run a for each loop in the transactions array
        //to find the matching bookID, set that status to false
        //if the date is overdue then find the fine and apply it to the user's balance
        double fine=0;
        for (Transaction t:transactions) {
            if(t.getBookID()==bookID){
                t.setStatus(false);
                //if the date of return is after the due date compute a fine
                if (LocalDate.now().isAfter(getDueDate(t.getIssueDate()))) {
                     fine = computeFine(t) * 1.0; //one dollar per one day late
                }
                if(fine>0){
                    User u = getUser(t.getUserID());
                    if(u!=null){
                        u.setBalance(fine);
                    }
                }
                return true;
            }
        }
        return false;
    }

    private int computeFine(Transaction t) {
        //pass in the transaction, calculate how many days has passed the due date
        //return the number of late days
            int daysLate = (int) getDueDate(t.getIssueDate()).until(LocalDate.now(), ChronoUnit.DAYS);
            return daysLate;
    }

    public void collectFine(User u){
        //pass in the user, then set their balance to 0
        u.setBalance(0);
    }

    public ArrayList<Book> searchBook(String key) {
        //run through the book arraylist to search for the book
        //if the title has the key then added in the result
        ArrayList<Book> result = new ArrayList<>();
        key = key.toUpperCase(Locale.ROOT);
        for (Book b : books) {
            if (b.getName().toUpperCase().contains(key)) {
                result.add(b);
            }
        }
        return result;
    }

    public Book getBook(int bookID){
        //run through the books arraylist, then return the book that match wth ID
        //if not found return null
        for (Book b:books) {
            if (b.getID()==bookID)
                return b;
        }
        return null;
    }

    public User getUser(int userID){
        //run through the users arraylist, then return the user that match wth ID
        //if not found return null
        for (User u:users) {
            if (u.getID()==userID)
                return u;
        }
        return null;
    }

    public void printResult(ArrayList<Book> books){
        //run through the books arraylist then print it out
        for (Book b:books) {
            System.out.println(b);
        }
    }

}
