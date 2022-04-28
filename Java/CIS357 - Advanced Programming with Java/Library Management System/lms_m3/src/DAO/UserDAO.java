package DAO;

import model.User;

import java.sql.*;
import java.time.LocalDate;
import java.util.ArrayList;

public class UserDAO {
    Connection connection;
    int row;

    public UserDAO(String url) throws SQLException {
        connection = DriverManager.getConnection(url);
    }

     public void insert(User u) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("INSERT INTO users(NAME, EMAIL, ADDRESS,DATEOFBIRTH, ISSTUDENT, BALANCE ) VALUES(?,?,?,?,?,?)");
        ps.setString(1,u.getName());
        ps.setString(2,u.getEmail());
        ps.setString(3,u.getAddress());
        //Get SQL date instance
        java.sql.Date sqlDate = java.sql.Date.valueOf(u.getDateOfBirth());
        ps.setDate(4,sqlDate);

        ps.setBoolean(5,u.getStudent());
        ps.setDouble(6,u.getBalance());

        ps.executeUpdate();
    }

    public void update(User u) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("UPDATE users SET NAME=?, EMAIL=?, ADDRESS=?,DATEOFBIRTH = ?, ISSTUDENT=?, BALANCE=? WHERE ID=?");
        ps.setInt(7,u.getID());
        ps.setString(1,u.getName());
        ps.setString(2,u.getEmail());
        ps.setString(3,u.getAddress());

        //Get SQL date instance
        java.sql.Date sqlDate = java.sql.Date.valueOf(u.getDateOfBirth());
        ps.setDate(4,sqlDate);

        ps.setBoolean(5,u.getStudent());
        ps.setDouble(6,u.getBalance());

        ps.executeUpdate();
    }

    public void delete(User u) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("DELETE FROM users WHERE ID=?");
        ps.setInt(1,u.getID());
        ps.executeUpdate();
    }


    public ArrayList<User> getAll() throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM users");
        return getUsers(ps);
    }
    public ArrayList<User> getByQuery(String key) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM users WHERE NAME LIKE ?");
        ps.setString(1, "%"+key+"%");
        return getUsers(ps);
    }
    private ArrayList<User> getUsers(PreparedStatement ps) throws SQLException {
        ResultSet rs = ps.executeQuery();
        ArrayList<User> users = new ArrayList<>();
        while(rs.next()){
            Date sqlDate = rs.getDate(5);
            LocalDate localDate = sqlDate.toLocalDate();

            User temp = new User(
                    rs.getInt(1),
                    rs.getString(2),
                    rs.getString(3),
                    rs.getString(4),
                    localDate,
                    rs.getBoolean(6),
                    rs.getDouble(7)
            );
            users.add(temp);

        }
        rs.close();
        return users;
    }

    public User getUser(int ID) throws SQLException {
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM users WHERE ID=?");
        ps.setInt(1,ID);
        ResultSet rs = ps.executeQuery();
        Date sqlDate = rs.getDate(5);
        LocalDate localDate = sqlDate.toLocalDate();

        User temp = new User(
                rs.getInt(1),
                rs.getString(2),
                rs.getString(3),
                rs.getString(4),
                localDate,
                rs.getBoolean(6),
                rs.getDouble(7)
        );
        rs.close();
        return temp;
    }
}
