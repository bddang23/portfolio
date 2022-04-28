package controller;


import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import model.Library;

public class Main extends Application {
    Library library;
    public static Stage primaryStage;

    @Override
    public void start(Stage primaryStage) throws Exception{
        library = new Library();

        Main.primaryStage =primaryStage;
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/view/MainMenuPage.fxml"));
        Parent root = loader.load();

        MainMenuPage loginController = loader.getController();
        loginController.initData(library);
        primaryStage.setTitle("Main Menu");
        primaryStage.setScene(new Scene(root, 800   , 600));
        primaryStage.show();
    }



    public static void main(String[] args) {
        launch(args);
    }
}
