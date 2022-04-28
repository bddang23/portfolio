import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import java.util.ArrayList;

//Pizza OOP
class Pizza {
    //set the required element for pizza object
    String strSize;
    int size;
    String strCrust;
    String strSauce;
    String strCheese;
    Boolean isSeasoned;
    ArrayList<String> strToppings;

    //constant image directory
    final String IMG_DIR = "file:src/assets/images/";

    //default constructoe that pre-set every element of the pizza
    public Pizza(){
        strSize = "400 x 400";
        size= 400;
        strCrust = "Chicago Style Deep Dish";
        strSauce = "Marinara";
        strCheese = "Normal";
        isSeasoned = true;
        strToppings=new ArrayList<>();
        strToppings.add("Mushrooms");
        strToppings.add("Pepper");
        strToppings.add("Pepperoni");
    }

    //function return array list of string cheese path including normal and extra
    private ArrayList<String> getCheesePath(){
        ArrayList<String> cheese = new ArrayList<>();
        //check string cheese, and add approriate path to arraylist
        if (strCheese.equals("Normal"))
            cheese.add(IMG_DIR+"cheese_normal.png");
        else if (strCheese.equals("Extra")){
            cheese.add(IMG_DIR+"cheese_normal.png");
            cheese.add(IMG_DIR+"cheese_extra.png");
        }
        else
            cheese.add("");
        return cheese;
    }

    //function get the path for crust picture
    private String getCrustPath(){
        String path = IMG_DIR;
        //depends on the user selected
        //return approriate path
        if (strCrust.equals("Chicago Style Deep Dish"))
            path += "crust_chicago.png";
        else
            path += "crust_nyc.png";
        return path;
    }

    //function return the sauce path picture
    private String getSaucePath(){
        String path = IMG_DIR;

        //if user selected approriate buttons
        //return approriate path
        if (strSauce.equals("Marinara"))
            path += "sauce_marinara.png";
        else if (strSauce.equals("BBQ"))
            path += "sauce_barbeque.png";
        else if (strSauce.equals("Alfredo"))
            path += "sauce_alfredo.png";
        else if (strSauce.equals("Chipotle"))
            path += "sauce_chipotle.png";

        return path;
    }

    //function retur the picture if the pizza is seasoned or not
    private String getSeasonedPath(){
        String path = IMG_DIR;
        //return the approriate path if user select season checkbox
        if (isSeasoned) {
            path += "seasoning.png";
            return path;
        }
        return "";

    }

    private String getToppingPath(String t){
        String path =IMG_DIR;
        //depend on the topping checkbox that user select return that specific path for teh specific toppingg
        switch (t){
            case "Mushrooms":
                path += "topping_mushroom.png";
                break;
            case "Chicken":
                path+="topping_chicken.png";
                break;
            case "Ham":
                path+="topping_ham.png";
                break;
            case "Jalapeno":
                path+="topping_jalapeno.png";
                break;
            case "Olive":
                path+="topping_olive.png";
                break;
            case "Onion":
                path+="topping_onion.png";
                break;
            case "Pepper":
                path+="topping_pepper.png";
                break;
            case "Pepperoni":
                path+="topping_pepperoni.png";
                break;
            case "Tomato":
                path+="topping_tomato.png";
                break;
            default:
                path="";
        }
        return path;
    }

    //turn a path to image view
    private ImageView loadImage(String path){
        //if path is not empty then return an imageView
        if (!path.isEmpty()){
            Image img = new Image(path);
            ImageView iv = new ImageView(img);
            return iv;
        }
        return null;
    }

    //get all the image view for the pizza
    public ArrayList<ImageView> getImages(){
        ArrayList<ImageView> ivPizza = new ArrayList<>();

        //load in the order of crust,sauce,cheese,toppings,seasoning
        //creat approriate imageview with loadPicture method
        ImageView ivCrust = loadImage(getCrustPath());
        ImageView ivSauce = loadImage(getSaucePath());

        //then add it to the Arraylist of Image View
        ivPizza.add(ivCrust);
        ivPizza.add(ivSauce);

        //add cheese if not none
        for (String cheese: getCheesePath()) {
            if (cheese.isEmpty())
                break;
            ImageView ivCheese = loadImage(cheese);
            ivPizza.add(ivCheese);
        }

        //loop through the str topping arraylist
        //if not empty then add in to the arraylist
        if(!strToppings.isEmpty()){
            for (String topping: strToppings) {
                ImageView ivTopping = loadImage(getToppingPath(topping));
                ivPizza.add(ivTopping);
            }
        }

        //if seasoning checkbox is checked then add theiv to the arraylist
        if(!getSeasonedPath().isEmpty()){
            ImageView ivSeasons = loadImage(getSeasonedPath());
            ivPizza.add(ivSeasons);
        }

        //then loop through the whole image view array
        //set them to approriate width
        for (ImageView iv: ivPizza) {
            if (iv!=null){
                iv.setFitWidth(size);
                iv.setPreserveRatio(true);
            }
        }

        return ivPizza;
    }

    @Override
    //return a string have all the pizza's info
    public String toString() {
        String report=strCrust +" style pizza size " + strSize + " with \n"
                     +strSauce + ", " + strCheese +" cheese. Topping \n" +
                     "including " + strToppings + ". Size is " +size +'\n';
        if (isSeasoned)
            report += ". Pizza also has seasoning on top!";
        return report;
    }
}
