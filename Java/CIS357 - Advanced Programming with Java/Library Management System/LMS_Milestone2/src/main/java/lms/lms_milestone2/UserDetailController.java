package lms.lms_milestone2;

import Library_OOP.Library;
import Library_OOP.Transaction;
import Library_OOP.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;

public class UserDetailController {

    @FXML private ChoiceBox<String> cmbUser;
    @FXML private ListView<String> lstBook;
    @FXML private Label lblAddress;
    @FXML private Label lblDOB;
    @FXML private Label lblEmail;
    @FXML private Label lblName;
    @FXML private Label lblUserType;
    @FXML private Label lblBalance;
    @FXML private Button btnCollect;

    Library library;

    public void initData(Library library) {
        this.library = library;
        library.getLog();
        ObservableList user = FXCollections.observableArrayList();
        for (User u:library.users) {
            user.add(u.toString());
        }
        cmbUser.setItems(user);
    }

    public void initialize() {
        cmbUser.getSelectionModel().selectedItemProperty().addListener((observable, oldValue, newValue) -> {
            String user = newValue;
            for (int i =0;i<library.users.size();i++){
                if (user.contains(i+"")){
                    User u = library.getUser(i);
                    lblName.setText(u.getName());
                    lblAddress.setText(u.getAddress());
                    lblAddress.setWrapText(true);

                    lblEmail.setText(u.getEmail());
                    lblDOB.setText(u.getDateOfBirth().toString());

                    if (u.getBalance()>0) {
                        lblBalance.setStyle("-fx-text-fill: red");
                        btnCollect.setVisible(true);
                    }
                    else {
                        lblBalance.setStyle("-fx-text-fill: white");
                        btnCollect.setVisible(false);
                    }

                    lblBalance.setText(u.getBalance()+"");
                    if (u.getStudent()) lblUserType.setText("Student");
                    else lblUserType.setText("Faculty");


                    ObservableList currentChecked = FXCollections.observableArrayList();
                    //loop through book array
                    for (Transaction t: library.transactions) {
                        if (t.getUserID() == u.getID() & t.isStatus()){
                            currentChecked.add(library.getBook(t.getBookID()).getName());
                        }
                    }
                    lstBook.setItems(currentChecked);
                    break;
                }
            }
        });

    }

    @FXML public void CollectFine(ActionEvent event){
        for (User u : library.users){
            if(u.getName().contains(lblName.getText())){
                u.setBalance(0);
                lblBalance.setStyle("-fx-text-fill: lightgreen");
                lblBalance.setText(u.getBalance()+"");
            }
        }
    }
}


