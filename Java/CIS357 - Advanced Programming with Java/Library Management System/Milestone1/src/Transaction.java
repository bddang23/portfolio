import java.time.LocalDate;

public class Transaction {
    private int bookID;
    private int userID;
    private LocalDate issueDate;
    private boolean status; //true when book is issued
                            //false when book is available to borrow

    //constructor for declaring a new transaction
    public Transaction(int bookID, int userID) {
        this.bookID = bookID;
        this.userID = userID;
        status = true;//set status to true, since when transaction first occurs, book will be issued
        issueDate = LocalDate.now(); //set the issue date to current time
    }

    @Override
    //overide toString that return info of the transaction
    public String toString() {
        return "Transaction{" +
                "bookID=" + bookID +
                ", userID=" + userID +
                ", issueDate=" + issueDate +
                ", status=" + status +
                '}';
    }

    //getter and setter for bookID, userID, and issuedDate
    public int getBookID() {
        return bookID;
    }
    public void setBookID(int bookID) {
        this.bookID = bookID;
    }
    public int getUserID() {
        return userID;
    }
    public void setUserID(int userID) {
        this.userID = userID;
    }
    public LocalDate getIssueDate() {
        return issueDate;
    }
    public void setIssueDate(LocalDate issueDate) {
        this.issueDate = issueDate;
    }

    //return the status of the book
    public boolean isStatus() {
        return status;
    }
    //set status of the book's transaction
    public void setStatus(boolean status) {
        this.status = status;
    }
}
