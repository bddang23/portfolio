package lms.lms_milestone2;

import Library_OOP.Library;
import Library_OOP.Transaction;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import java.time.LocalDate;
import java.util.ArrayList;

public class IssuedBookTable {

    @FXML private TableColumn<Transaction, Integer> colBook;
    @FXML private TableColumn<Transaction, LocalDate> colDate;
    @FXML private TableColumn<Transaction, Integer> colUser;
    @FXML private TableView<Transaction> tblIssuedBook;
    public Library library;

    public void initData(Library library){
        this.library=library;
        ArrayList<Transaction> transactionsArr = library.transactions;
        ObservableList<Transaction> transactions = FXCollections.observableArrayList(transactionsArr);
        tblIssuedBook.setItems(transactions);
        colBook.setCellValueFactory(new PropertyValueFactory<>("bookID"));
        colUser.setCellValueFactory(new PropertyValueFactory<>("userID"));
        colDate.setCellValueFactory(new PropertyValueFactory<>("issueDate"));
    }
}
