public class Book {
    //declare approriate fields for book obj
    private int ID;
    private String name;
    private String author;
    private String publisher;
    private String genre;
    private String ISBN;
    private long year;
    private static int  booksAdded=0;

    //book constructor
    public Book(String name, String author, String publisher, String genre, String ISBN, long year) {
        ID = booksAdded;
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.genre = genre;
        this.ISBN = ISBN;
        this.year = year;
        booksAdded++;
    }

    @Override
    //to string method that returnn book's ID and name
    public String toString() {
        return "ID= " + ID +", name= " + name;
    }

    @Override
    //compare method using book ID
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Book)) return false;
        Book book = (Book) o;
        return getID() == book.getID();
    }

//line 40-78 is the getter and setter for every field in the object Book
    public int getID() {
    return ID;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getAuthor() {
        return author;
    }
    public void setAuthor(String author) {
        this.author = author;
    }
    public String getPublisher() {
        return publisher;
    }
    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }
    public String getGenre() {
        return genre;
    }
    public void setGenre(String genre) {
        this.genre = genre;
    }
    public String getISBN() {
        return ISBN;
    }
    public void setISBN(String ISBN) {
        this.ISBN = ISBN;
    }
    public long getYear() {
        return year;
    }
    public void setYear(long year) {
        this.year = year;
    }
}
