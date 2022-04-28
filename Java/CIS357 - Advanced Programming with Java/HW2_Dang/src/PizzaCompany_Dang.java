/* The Procedural Object-Oriented Pizza Company (P00P inc.)
 * This program design a GUI for ordering a pizza
 * by allowing user to add in different elements on the pizza
 * Then user can either submit it or reset the pizza
 *
 * @author  Binh Dang
 * @version 1.0
 * @since   2022-02-02
 */
import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.ImageView;
import javafx.scene.layout.*;
import javafx.stage.Stage;
import javafx.embed.swing.SwingFXUtils;
import javafx.scene.image.WritableImage;
import javafx.scene.layout.StackPane;
import javafx.stage.FileChooser;
import javax.imageio.ImageIO;
import java.awt.image.RenderedImage;
import java.io.File;
import java.io.IOException;
import java.util.*;

public class PizzaCompany_Dang extends Application {
    //instantiate the scene and the root for the application
    Scene scene;
    VBox root; //contain a label, and 2 vbox

    //this root is for the form and stackpane pizza
    HBox hbRoot;
    VBox vbForm; //contain 6 different vboxes and hboxes

    //pizza picture
    StackPane spPizza;//contain all the picture of pizza

    //Label for the app title
    Label lblTitle;

    //Elements needed for buttons
    HBox hbButtons; //hbox containn 2 button
    Button btnSubmit;
    Button btnReset;

    //elements for three size radio buttons
    VBox vbSizeRoot;//adding label and buttons
    HBox hbSize; // this contains the three radio buttons
    Label lblSize;
    RadioButton radSmall;
    RadioButton radMedium;
    RadioButton radLarge;
    ToggleGroup tglSize; //a toggle group for the buttons

    //elements for Crust
    VBox vbCrustRoot; //Vbox contain label and rad buttons
    HBox hbCrust; //hbox contain 3 radio buttons
    Label lblCrust;
    RadioButton radChicago;
    RadioButton radNewYork;
    ToggleGroup tglCrust; //toggle group for crust radio buttons

    //elements for Sauce
    HBox hbSauce;//contain the label along with the sauce toggle button
    Label lblSauce;
    ToggleButton tgbMarinara;
    ToggleButton tgbBBQ;
    ToggleButton tgbAlfredo;
    ToggleButton tgbChipotle;
    ToggleGroup tglSauce; //toggle group for the sauce

    //elements for Cheese
    HBox hbCheese; //contain label and a cheese combobox
    Label lblCheese;
    ComboBox cmbCheese;

    //elements for Toppings
    VBox vbToppingRoot; //contains all the label and buttons
    Label lblToppings;
    HBox hbToppings;//contain 2 vbox for left and right
    VBox vbToppingLeft;//contains all the topping on the left
    VBox vbToppingRight;//all the toppings on the right
    //initiate checkboxes for topping
    CheckBox chkMush;
    CheckBox chkOnion;
    CheckBox chkOlive;
    CheckBox chkPepper;
    CheckBox chkTomato;
    CheckBox chkJalapeno;
    CheckBox chkHam;;
    CheckBox chkChick;
    CheckBox chkPep;

    //Seasoning
    HBox hbSeasoning; //contain a seasoning check box
    CheckBox chkSeasoning;

    //blank label when submit successfully
    Label lblSubmit;

    //class pizza object
    Pizza customPizza;

    public static void main(String args[]){
        launch(args); //launch the programs
    }

    @Override
    public void start(Stage stage) throws Exception {
        customPizza = new Pizza(); //instantiate for pizza objrct

        //instantiate the root
        //and change its id,alignment,padding, and spacing
        root= new VBox();
        root.setId("base");
        root.setAlignment(Pos.TOP_CENTER);
        root.setPadding(new Insets(50));
        root.setSpacing(20);

        //set label and id for css.
        lblTitle = new Label("Build your own Pizza!");
        lblTitle.setId("Title");

        //add in label
        root.getChildren().add(lblTitle);

        //initiate hbRoot set the paddinging and approriate spacing
        hbRoot = new HBox();
        hbRoot.setPadding(new Insets(10));
        hbRoot.setSpacing(150);

        //initiate form and set its id, make it size 600x600
        vbForm = new VBox();
        vbForm.setId("Form");
        vbForm.setMaxSize(600,600);

        //call function build form that add everything in the form
        BuildForm();

        //add vform to root
        hbRoot.getChildren().add(vbForm);

        //declare stack pane
        spPizza = new StackPane();

        //build the default pizza
        BuildPizza();

        //added to hRoot
        hbRoot.getChildren().add(spPizza);

        root.getChildren().add(hbRoot);

        //initiate scene with height of 800, and width of 1200
        scene = new Scene(root,1200,800);

        //add css style sheet to the scene
        scene.getStylesheets().add("file:src/assets/stylesheets/styles.css");
        stage.setTitle("Procedural Object Oriented Programming (POOP) Pizza Store");
        stage.setScene(scene);
        stage.show();
    }

    //build the pizza function
    private void BuildPizza() {
    //clear the stack pane
        spPizza.getChildren().clear();

        //get the images from the custom Pizza object
        //then append it to the stackpane if it is not null
        for (ImageView elem: customPizza.getImages()) {
            if (elem!=null)
                spPizza.getChildren().add(elem);
        }
    }

    //function to build the form
    public void BuildForm() {
        //set spacing between the element
        vbForm.setSpacing(20);
        vbForm.setMaxSize(600,600);

        //create everythingg needed for size then append to the form
        configureSize();
        vbForm.getChildren().add(vbSizeRoot);


        //create everythingg needed for crust then append to the form
        configureCrust();
        vbForm.getChildren().add(vbCrustRoot);

        //create everythingg needed for Sauce then append to the form
        configureSauce();
        vbForm.getChildren().add(hbSauce);


        //create everythingg needed for Cheese then append to the form
        configureCheese();
        vbForm.getChildren().add(hbCheese);


        //create everythingg needed for Topping then append to the form
        configureTopping();
        vbForm.getChildren().add(vbToppingRoot);

        //create everythingg needed for seasining then append to the form
        configureSeasoning();
        vbForm.getChildren().add(hbSeasoning);

        //create everythingg needed for buttons then append to the form
        configureButtons();
        vbForm.getChildren().add(hbButtons);

        //initiate the label for submit
        //and make wrap text
        lblSubmit=new Label("");
        vbForm.setAlignment(Pos.CENTER);
        vbForm.getChildren().add(lblSubmit);
        lblSubmit.setWrapText(true);
    }

    public void configureSize() {
        //initiatae vbox for the size
        vbSizeRoot = new VBox();
        vbSizeRoot.setId("Size");
        vbSizeRoot.setAlignment(Pos.CENTER);
        vbSizeRoot.setSpacing(20);

        //hbox for all the radio buttons
        hbSize = new HBox();
        hbSize.setSpacing(10);
        hbSize.setAlignment(Pos.TOP_CENTER);


        lblSize = new Label("Choose your size");

//initiate all the buttons and set Medium selected by default
        radSmall = new RadioButton("Small");
        radMedium = new RadioButton("Medium");
        radMedium.setSelected(true);
        radLarge = new RadioButton("Large");

        //set the approriate toggle group
        tglSize = new ToggleGroup();
        tglSize.getToggles().addAll(radSmall,radMedium, radLarge);

        //add event whenver the button clicked
        //it change the size of pizza
        //then call the funnction build pizza to make it complete
        tglSize.selectedToggleProperty().addListener((observable,oldValue,newValue)->{
            RadioButton selected = (RadioButton) newValue;
            if (selected.getText().equals("Small")){
                customPizza.size=350;
                customPizza.strSize="350 x 350";
            }
            else if (selected.getText().equals("Medium")){
                customPizza.size=400;
                customPizza.strSize="400 x 400";
            }
            else if (selected.getText().equals("Large")){
                customPizza.size=450;
                customPizza.strSize="450 x 450";
            }
            BuildPizza();
        });

        //add everything to hbox and vboxRoot
        hbSize.getChildren().addAll(radSmall,radMedium,radLarge);
        vbSizeRoot.getChildren().addAll(lblSize,hbSize);
    }
    public void configureCrust(){
        //create a vbox for crust with approriate setting
        vbCrustRoot = new VBox();
        vbCrustRoot.setId("Crust");
        vbCrustRoot.setAlignment(Pos.TOP_CENTER);
        vbCrustRoot.setSpacing(20);

        //initiate hbox for the crust along with label
        hbCrust = new HBox();
        hbCrust.setSpacing(10);
        hbCrust.setAlignment(Pos.TOP_CENTER);
        lblCrust=new Label("Choose Your Crust");

        //instatiate 2 radio buttons and let the chicago seep dish style selected
        radChicago =  new RadioButton("Chicago Style Deep Dish");
        radChicago.setSelected(true);
        radNewYork = new RadioButton("New York Thin Crust");

        //add toggle ggroup for buttons
        tglCrust = new ToggleGroup();
        tglCrust.getToggles().addAll(radChicago,radNewYork);

        //add event listeners to the buttons
        //every time somethings selected change the value of the pizza object crust
        //and build it again
        tglCrust.selectedToggleProperty().addListener((observable, oldValue, newValue) -> {
            RadioButton selected = (RadioButton) newValue;
            customPizza.strCrust =selected.getText();
            BuildPizza();
        });

        //add it to approriate hbox and vbox
        hbCrust.getChildren().addAll(radChicago,radNewYork);
        vbCrustRoot.getChildren().addAll(lblCrust,hbCrust);
    }
    public void configureSauce(){
 //instantiate hbox along gwith the label to add in
        hbSauce = new HBox();
        hbSauce.setId("Sauce");
        lblSauce = new Label("Choose Your Sauce \t");

        //instatiate all the toggle buttons for sauce and set marinara selected
        tgbMarinara = new ToggleButton("Marinara");
        tgbMarinara.setSelected(true);
        tgbBBQ = new ToggleButton("BBQ");
        tgbAlfredo= new ToggleButton("Alfredo");
        tgbChipotle= new ToggleButton("Chipotle");

        //add it to toggle group
        tglSauce= new ToggleGroup();
        tglSauce.getToggles().addAll(tgbMarinara,tgbBBQ,tgbAlfredo,tgbChipotle);

        //add event listeners to the sauce buttons
        //everytime sauce is clicked its changed the pizza object and print the pizza out again
        tglSauce.selectedToggleProperty().addListener((observable, oldValue, newValue) -> {
            ToggleButton selected = (ToggleButton) newValue;
            if (selected!=null)
                customPizza.strSauce=selected.getText();
            else
                customPizza.strSauce="";
            BuildPizza();
        });

        //add everything to the hbox
        hbSauce.getChildren().addAll(lblSauce,tgbMarinara,tgbBBQ,tgbAlfredo,tgbChipotle);
    }
    public void configureCheese(){
        //initiate hbox with the label
        hbCheese= new HBox();
        hbCheese.setId("Cheese");
        lblCheese =  new Label("Choose Cheese Level \t");

        //make an arraylist of cheese with none, normal, and extra
        ArrayList<String> cheese = new ArrayList<>();
        cheese.add("None");
        cheese.add("Normal");
        cheese.add("Extra");

        //declare a combo box and add all the cheese using arraylist
        cmbCheese = new ComboBox();
        cmbCheese.getItems().addAll(cheese);
        cmbCheese.getSelectionModel().select(1);

        //add event listeners everytime the listbox get changed
        //change the strCheese in the object pizza
        //and rebuild the whole pizza
        cmbCheese.getSelectionModel().selectedItemProperty().addListener((observable, oldValue, newValue) -> {
            String selected = (String) newValue;
            customPizza.strCheese=selected;
            System.out.println(newValue);
            BuildPizza();
        });

        //add all the elemnts to the hbox
        hbCheese.getChildren().addAll(lblCheese,cmbCheese);
    }
    public void configureTopping(){
        //initiate the topping root
        //and change its setting
        vbToppingRoot = new VBox();
        vbToppingRoot.setId("Topping");
        vbToppingRoot.setAlignment(Pos.TOP_CENTER);
        vbToppingRoot.setSpacing(20);

        //initiate label
        lblToppings = new Label("Choose Your Toppings:");

        //create hbox contain two vbox of topping
        hbToppings =new  HBox() ;
        hbToppings.setAlignment(Pos.TOP_CENTER);

        //initiate 2 vbox
        vbToppingLeft = new VBox() ;
        vbToppingRight = new VBox() ;

        //initiate the checkbox for topping
        //set mushrooms, Pepper, and pepperoni selected
        chkMush = new CheckBox("Mushrooms");
        chkMush.setSelected(true);

        chkOnion = new CheckBox("Onion");
        chkOlive = new CheckBox("Olive");
        chkPepper = new CheckBox("Pepper");
        chkPepper.setSelected(true);

        chkTomato = new CheckBox("Tomato");
        chkJalapeno = new CheckBox("Jalapeno");
        chkHam = new CheckBox("Ham");
        chkChick = new CheckBox("Chicken");

        chkPep = new CheckBox("Pepperoni");
        chkPep.setSelected(true);

        //vbtopping left and right
        vbToppingLeft.getChildren().addAll(chkMush,chkOnion,chkOlive,chkPepper,chkTomato);
        vbToppingRight.getChildren().addAll(chkJalapeno,chkHam,chkChick,chkPep);

        //the next 2 loops loop through every checkbox
        //add the event listeners when users clicked checked box
        //add it to the string arraylist
        //rebuild the whole pizza
        for (Node n:vbToppingLeft.getChildren()) {
            CheckBox chk = (CheckBox) n;
            chk.selectedProperty().addListener((observable, oldValue, newValue) -> {
                if (newValue)
                    customPizza.strToppings.add(chk.getText());
                else
                    customPizza.strToppings.remove(chk.getText());

                BuildPizza();
            });
        }
        for (Node n:vbToppingRight.getChildren()) {
            CheckBox chk = (CheckBox) n;
            chk.selectedProperty().addListener((observable, oldValue, newValue) -> {
                if (newValue)
                    customPizza.strToppings.add(chk.getText());
                else
                    customPizza.strToppings.remove(chk.getText());

                BuildPizza();
            });
        }

        //add every vbox and label,and hbox to the right placce
        hbToppings.getChildren().addAll(vbToppingLeft,vbToppingRight);
        vbToppingRoot.getChildren().addAll(lblToppings,hbToppings);

    }
    public void configureSeasoning(){
        //initiate seaoning hbox and change it allignment
        hbSeasoning = new HBox();
        hbSeasoning.setId("Seasoning");
        hbSeasoning.setAlignment(Pos.CENTER);

        //create the chkSeasoning and make it default true
        chkSeasoning = new CheckBox("Add Seasoning?");
        chkSeasoning.setSelected(true);

        //add the event listener by if it checked change the isSeasoned in pizza obj
        //build a new pizza picture
        chkSeasoning.selectedProperty().addListener((observable, oldValue, newValue) -> {
            if (newValue)
                customPizza.isSeasoned=true;
            else
                customPizza.isSeasoned=false;

            BuildPizza();
        });

        //addthe checkbox to the hbox
        hbSeasoning.getChildren().add(chkSeasoning);
    }
    private void configureButtons() {
        //create a hbox with approriate settinggs
        hbButtons = new HBox();
        hbButtons.setAlignment(Pos.TOP_CENTER);
        hbButtons.setSpacing(20);

        //initiate buttons submit and reset
        btnSubmit = new Button("Submit");
        btnReset = new Button("Reset");
        btnReset.setId("Reset");//set id for css

        //add the event listene for submit buttons
        //call the capture and save rhe display to file
        //then set the text for the label when it save successfully
        btnSubmit.setOnMouseClicked(event -> {
            lblSubmit.setText("Order Ready! Your pizza is delivered at "+captureAndSaveDisplay(spPizza));

        });

        //event listeners for the buttons reset
        btnReset.setOnMouseClicked(event -> {
           //make the defeult checkboxes and toggle buttons selected
            radMedium.setSelected(true);
            radChicago.setSelected(true);
            tgbMarinara.setSelected(true);

            //set every topping deselect
            for (Node n:vbToppingLeft.getChildren()) {
                CheckBox chk = (CheckBox) n;
                   chk.setSelected(false);
            };
            for (Node n:vbToppingRight.getChildren()) {
                CheckBox chk = (CheckBox) n;
                chk.setSelected(false);
            }

            //set mushrooms, pepper, and peperoni, seasoning checkbox selected
            chkMush.setSelected(true);
            chkPepper.setSelected(true);
            chkPep.setSelected(true);
            chkSeasoning.setSelected(true);

            //make the label empty
            lblSubmit.setText("");

            //set a new pizza object
            Pizza newPizza =new Pizza();
            customPizza=newPizza;

            BuildPizza(); //build the default pizza
        });
        hbButtons.getChildren().addAll(btnSubmit,btnReset);
    }

    //method implementation
    public String captureAndSaveDisplay(StackPane pizzaLayers){

        // Adapted from: https://stackoverflow.com/questions/38028825/javafx-save-view-of-pane-to-image/38028893

        FileChooser fileChooser = new FileChooser();
        //Set extension filter
        fileChooser.getExtensionFilters().add(new FileChooser.ExtensionFilter("png files (*.png)", "*.png"));
        //Prompt user to select a file
        File file = fileChooser.showSaveDialog(null);

        if(file != null){
            try {
                //Set the capture area
                WritableImage writableImage = new WritableImage((int)pizzaLayers.getWidth(),(int)pizzaLayers.getHeight());
                pizzaLayers.snapshot(null, writableImage);
                RenderedImage renderedImage = SwingFXUtils.fromFXImage(writableImage, null);
                //Write the snapshot to the chosen file
                ImageIO.write(renderedImage, "png", file);
                return file.getAbsolutePath();
            } catch (IOException ex) { ex.printStackTrace(); }
        }
        return null;
    }

}