package lms.lms_milestone2;

import Library_OOP.Book;
import Library_OOP.Library;
import Library_OOP.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

import java.util.ArrayList;

public class IssueBookController {

    @FXML private Label lblResult;
    @FXML private ListView<String> lstBook;
    @FXML private ListView<String> lstUser;
    @FXML private TextField txtBookID;
    @FXML private TextField txtBookSearch;
    @FXML private TextField txtUserID;
    @FXML private TextField txtUserSearch;
    Library library;

    public void initData(Library  lib){
        this.library =lib;
        library.getLog();
        ObservableList books = FXCollections.observableArrayList();
        ArrayList<Book> searchedBooks =  library.books;
        for (Book b:searchedBooks) {
            books.add(b.getName());
        }
        lstBook.setItems(books);

        ObservableList users = FXCollections.observableArrayList();
        for (User u : library.users) {
            users.add(u.getName());
        }
        lstUser.setItems(users);

    }
    public void initialize(){

        txtUserSearch.textProperty().addListener((observable, oldValue, newValue) -> {
            ObservableList users = FXCollections.observableArrayList();
            for (User u : library.users) {
                if(u.getName().contains(newValue)) users.add(u.getName());
            }
            lstUser.setItems(users);
        });

        txtBookSearch.textProperty().addListener((observable, oldValue, newValue) -> {
            ObservableList books = FXCollections.observableArrayList();
            ArrayList<Book> searchedBooks =  library.searchBook(newValue);
            for (Book b:searchedBooks) {
                books.add(b.getName());
            }
            lstBook.setItems(books);
        });

        lstBook.getSelectionModel().selectedItemProperty().addListener((observable, oldValue, newValue) -> {
            String bookName = newValue;
            for (Book b : library.books) {
                if (b.getName().equals(bookName))
                    txtBookID.setText(b.getID() + "");
            }
        });
        lstUser.getSelectionModel().selectedItemProperty().addListener((observable, oldValue, newValue) -> {
            String userName = newValue;
            for (User b : library.users) {
                if (b.getName().equals(userName))
                    txtUserID.setText(b.getID() + "");
            }
        });
    }

    @FXML void IssueBook(ActionEvent event) {
        int userID = Integer.parseInt(txtUserID.getText());
        int bookID = Integer.parseInt(txtBookID.getText());
        boolean isIssued = library.issueBook(userID,bookID);
        lblResult.setWrapText(true);

        if (isIssued) {
            lblResult.setStyle("-fx-text-fill: green");
            lblResult.setText(library.msgLog.get(library.msgLog.size() - 2 )+"\n"+library.msgLog.get(library.msgLog.size() - 1 ) );
        } else{
            lblResult.setStyle("-fx-text-fill: red");
            lblResult.setText(library.msgLog.get(library.msgLog.size() - 1 ) );
        }
    }

}
