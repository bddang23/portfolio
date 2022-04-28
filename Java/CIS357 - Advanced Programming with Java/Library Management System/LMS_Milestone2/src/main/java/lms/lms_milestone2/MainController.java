package lms.lms_milestone2;

import Library_OOP.Library;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Modality;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

public class MainController implements Initializable {

    @FXML private Button btnAddBook;
    @FXML private Button btnAddUser;
    @FXML private Button btnIssue;
    @FXML private Button btnReturnBook;
    @FXML private Button btnUserDetail;
    @FXML private Button btnviewIBook;

    Library library;

    public void initialize(){
    library = new Library();
    }

    public Object loadScreen(String title,String url) throws IOException {
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource(url));
        Scene scene = new Scene(loader.load(),350,550);

        primaryStage.setTitle(title);
        primaryStage.setScene(scene);
        primaryStage.initOwner(LMSApp.primaryStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.show();
        return loader.getController();
    }

    @FXML void AddBook(ActionEvent event) throws IOException {
        AddBookController controller = (AddBookController) loadScreen("Add New Book","BookRecord.fxml");
        controller.initData(library);
    }

    @FXML void issueBook(ActionEvent event) throws IOException {
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("IssueBook.fxml"));
        Scene scene = new Scene(loader.load(),650,700);

        primaryStage.setTitle("Issue Book");
        primaryStage.setScene(scene);
        primaryStage.initOwner(LMSApp.primaryStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.show();
        IssueBookController controller = loader.getController();
        controller.initData(library);
    }

    @FXML void openNewUser(ActionEvent event) throws IOException {
        AddUserController controller = (AddUserController) loadScreen("Add New User","UserRegistration.fxml");
        controller.initData(library);
    }

    @FXML void returnBook(ActionEvent event) throws IOException {
        ReturnBookController controller = (ReturnBookController) loadScreen("Return Book", "ReturnBook.fxml");
        controller.initData(library);
    }

    @FXML void userDetail(ActionEvent event) throws IOException {
        UserDetailController controller = (UserDetailController) loadScreen("View User Detail","UserView.fxml");
        controller.initData(library);
    }

    @FXML  void viewIBook(ActionEvent event) throws IOException {
        IssuedBookTable controller = (IssuedBookTable) loadScreen("View Issued Book Detail","issuedBookTable.fxml");
        controller.initData(library);
    }

    public void initData(Library library) {
        this.library = library;
        library.getLog();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }
}
