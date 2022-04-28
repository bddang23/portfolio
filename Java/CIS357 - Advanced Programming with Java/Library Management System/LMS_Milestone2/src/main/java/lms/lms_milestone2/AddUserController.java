package lms.lms_milestone2;

import Library_OOP.Library;
import Library_OOP.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.*;
import javafx.stage.Stage;

import java.time.LocalDate;

public class AddUserController{
    ToggleGroup tglUser;
    Library library;

    @FXML private DatePicker DoB;
    @FXML private RadioButton radFaculty;
    @FXML private RadioButton radStudent;
    @FXML private TextField txtAddress;
    @FXML private TextField txtEmail;
    @FXML private TextField txtName;

     public void initData(Library library) {
        this.library = library;
        library.getLog();
    }
    @FXML void registerUser(ActionEvent event) {
        String name = txtName.getText();
        String email = txtEmail.getText();
        String address = txtAddress.getText();
       Boolean userType = radStudent.isSelected();
        LocalDate DateofBirth = DoB.getValue();
        User u = new User(name,email,address, DateofBirth,userType);

        library.addUser(u);
        //hide the form
        Stage primaryStage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        primaryStage.hide();

        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Registration Successful");
        alert.setHeaderText(library.msgLog.get(library.msgLog.size()-1));
        alert.show();

    }
    @FXML
    void initialize(){
        tglUser = new ToggleGroup();
        tglUser.getToggles().setAll(radFaculty,radStudent);
        radStudent.setSelected(true);
    }

}
