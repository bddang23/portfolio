import javafx.application.Application;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

public class CW4 extends Application {
    Scene scene;
    StackPane giftCard;
    Label lblMessage;
    Button btnReset;
    Button btnOpen;
    StackPane root;
    ImageView ivClose = new ImageView();
    ImageView ivOpen = new ImageView();

    public static void main(String args[]){
        launch(args);
    }
    @Override
    public void start(Stage stage) throws Exception {

        root = new StackPane();
        root.setAlignment(Pos.CENTER);

        btnReset= new Button("Reset");

        giftCard=new StackPane();
        Image imgOpen = new Image("file:src/assets/images/gift_open.jpg");
        ivOpen.setImage(imgOpen);
        ivOpen.setFitWidth(400);
        ivOpen.setPreserveRatio(true);
        giftCard.getChildren().addAll(ivOpen,btnReset);
        StackPane.setAlignment(btnReset,Pos.BOTTOM_CENTER);


        Image imgClose = new Image("file:src/assets/images/gift_closed.jpg");
        ivClose.setImage(imgClose);
        ivClose.setFitWidth(400);
        ivClose.setPreserveRatio(true);

        btnOpen=new Button();
        btnOpen.setId("btnOpen");
        btnOpen.setMaxWidth(Double.MAX_VALUE);
        btnOpen.setMaxHeight(Double.MAX_VALUE);

        root.getChildren().addAll(giftCard,ivClose,btnOpen);

        scene = new Scene(root,350,600);
        stage.setTitle("Giftcard Generator");
        scene.getStylesheets().add("file:src/assets/stylesheets/style.css");
        stage.setScene(scene);
        stage.show();

        btnOpen.setOnAction(event -> {
            root.getChildren().removeAll(btnOpen,ivClose);
            int[] prize = {15,25,50,100};
            int pos = (int) (Math.random()*(4-0))+0;
            lblMessage= new Label(String.format("You Won $%d",prize[pos]));
            giftCard.getChildren().add(lblMessage);
        });

        btnReset.setOnAction(e -> {
            giftCard.getChildren().remove(lblMessage);
            root.getChildren().addAll(ivClose,btnOpen);
        });
    }
}