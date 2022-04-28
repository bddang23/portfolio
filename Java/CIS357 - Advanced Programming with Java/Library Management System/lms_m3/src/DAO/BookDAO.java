package DAO;

import model.Book;

import java.sql.*;
import java.util.ArrayList;

public class BookDAO {
    Connection connection;
    int row;

    public BookDAO(String url) throws SQLException {
        connection = DriverManager.getConnection(url);
    }

    public void insert(Book b) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("INSERT INTO books(NAME, AUTHOR, PUBLISHER,GENRE, ISBN, YEAR ) VALUES(?,?,?,?,?,?)");
        ps.setString(1,b.getName());
        ps.setString(2,b.getAuthor());
        ps.setString(3,b.getPublisher());
        ps.setString(4,b.getGenre());
        ps.setString(5,b.getISBN());
        ps.setLong(6,b.getYear());

        ps.executeUpdate();
    }

    public void update(Book b) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("UPDATE books SET NAME=?, AUTHOR=?, PUBLISHER=?,GENERE=?, ISBN=?, YEAR=? WHERE ID=?");
        ps.setInt(7,b.getID());
        ps.setString(1,b.getName());
        ps.setString(2,b.getAuthor());
        ps.setString(3,b.getPublisher());
        ps.setString(4,b.getGenre());
        ps.setString(5,b.getISBN());
        ps.setLong(6,b.getYear());

        ps.executeUpdate();

    }

    public void delete(Book b) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("DELETE FROM books WHERE ID=?");
        ps.setInt(1,b.getID());
        ps.executeUpdate();
    }


    public ArrayList<Book> getAll() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM books");
        return getBooks(ps);
    }
    public ArrayList<Book> getByQuery(String key) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM books WHERE NAME LIKE ?");
        ps.setString(1,"%"+key+"%");
        return getBooks(ps);
    }
    private ArrayList<Book> getBooks(PreparedStatement ps) throws SQLException {
        ResultSet rs = ps.executeQuery();
        ArrayList<Book> books = new ArrayList<>();
        while(rs.next()){
            Book temp = new Book(
                    rs.getInt(1),
                    rs.getString(2),
                    rs.getString(3),
                    rs.getString(4),
                    rs.getString(5),
                    rs.getString(6),
                    rs.getLong(7)
            );
            books.add(temp);

        }
        rs.close();
        return books;
    }

    public Book getBook(int ID) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM books WHERE ID=?");
        ps.setInt(1,ID);
        ResultSet rs = ps.executeQuery();

        Book temp = new Book(
                rs.getInt(1),
                rs.getString(2),
                rs.getString(3),
                rs.getString(4),
                rs.getString(5),
                rs.getString(6),
                rs.getLong(7)
        );
        rs.close();
        return temp;
    }
}
