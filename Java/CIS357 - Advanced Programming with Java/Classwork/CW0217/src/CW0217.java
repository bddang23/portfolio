import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import jdk.internal.org.objectweb.asm.Handle;



public class CW0217 extends Application {
    Scene scene;
    VBox root;
    Label lblMessage;
    Button btnClickMe;
    TextField txtName;
    Button b1;
    Label l2;
StackPane stack;

    ImageView iv = new ImageView();

    public static void main(String args[]){
        launch(args);
    }
    @Override
    public void start(Stage stage) throws Exception {
        lblMessage = new Label("Hello, ");

        btnClickMe = new Button("Click Me!");
        txtName = new TextField();
        root = new VBox();
        root.setAlignment(Pos.CENTER);
        root.setPadding(new Insets(50));
        root.setSpacing(20);

        Button btn = new Button("button");
        btn.setId("btn");

        root.getChildren().addAll(lblMessage,txtName,btnClickMe,btn);
stack=new StackPane();
        l2= new Label("lbl");
        b1= new Button("btn");
        stack.getChildren().addAll(b1,l2);
        root.getChildren().add(stack);

        scene = new Scene(root,600,600);
        scene.getStylesheets().add("style.css");
        stage.setScene(scene);
        stage.show();


        btnClickMe.setOnAction(e -> {
            String name = txtName.getText();
            lblMessage.setText("Hello, "+name);
            Image img = new Image("file:image.png");
            iv.setImage(img);
            iv.setFitWidth(300);
            iv.setPreserveRatio(true);
            root.getChildren().add(iv);
        });
    }
}