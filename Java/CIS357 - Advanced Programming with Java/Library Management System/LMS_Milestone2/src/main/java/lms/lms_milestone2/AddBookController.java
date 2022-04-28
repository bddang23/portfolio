package lms.lms_milestone2;

import Library_OOP.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.Alert;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class AddBookController {

    @FXML private ChoiceBox<String> cmbGenre;
    @FXML private ListView<String> lstPublisher;
    @FXML private TextField txtAuthor;
    @FXML private TextField txtISBN;
    @FXML private TextField txtName;
    @FXML private TextField txtYear;

     Library library;

    public void initialize(){
        ObservableList<String> publisher = FXCollections.observableArrayList("Pearson","Scholastic","Macmillan","Wiley","Simon & Schuster").sorted();
        lstPublisher.setItems(publisher);
        ObservableList<String> genre = FXCollections.observableArrayList( "Education", "Adventure", "Thriller","History").sorted();
        cmbGenre.setItems(genre);
    }
    public void initData(Library library){
        this.library=library;
        library.getLog();
    }
    @FXML void RegisterBook(ActionEvent event) {
        String name =txtName.getText();
        String author = txtAuthor.getText();
        String publisher = lstPublisher.getSelectionModel().getSelectedItem();
        String genre = cmbGenre.getValue();
        String ISBN = txtISBN.getText();
        Long year = Long.parseLong(txtYear.getText());

        Book b = new Book(name,author,publisher,genre,ISBN,year);
        library.addBook(b);

        //get thide the form
        Stage primaryStage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        primaryStage.hide();

        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Registration Successful");
        alert.setHeaderText(library.msgLog.get(library.msgLog.size()-1));
        alert.show();
    }
}
