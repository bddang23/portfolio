package lms.lms_milestone2;

import Library_OOP.Book;
import Library_OOP.Library;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

import java.util.ArrayList;

public class ReturnBookController {

    @FXML private ListView<String> lstBook;
    @FXML private TextField txtBookSearch;
    @FXML private TextField txtBookID;
    @FXML private Label lblResult;

    Library library;

    public void initData(Library lib){
        this.library=lib;
        library.getLog();
        ObservableList books = FXCollections.observableArrayList();
        ArrayList<Book> searchedBooks =  library.books;
        for (Book b:searchedBooks) {
            books.add(b.getName());
        }
        lstBook.setItems(books);
    }

    public void initialize(){
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
    }


    @FXML void returnBook(ActionEvent event) {
        boolean isReturned = library.returnBook(Integer.parseInt(txtBookID.getText()));

        if (isReturned){
            if (library.msgLog.get(library.msgLog.size()-1).contains("balance")) {
                lblResult.setStyle("-fx-text-fill: red");
                lblResult.setText(library.msgLog.get(library.msgLog.size() - 2) + "\n" + library.msgLog.get(library.msgLog.size() - 1));
            }
            else {
                lblResult.setStyle("-fx-text-fill: green");
                lblResult.setText(library.msgLog.get(library.msgLog.size()-1));}

        }else{
            lblResult.setStyle("-fx-text-fill: red");
            lblResult.setText( library.msgLog.get(library.msgLog.size()-1));

        }
    }

}
