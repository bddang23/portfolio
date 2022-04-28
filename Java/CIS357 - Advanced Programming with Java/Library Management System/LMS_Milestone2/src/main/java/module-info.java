module lms.lms_milestone2 {
    requires javafx.controls;
    requires javafx.fxml;
    opens Library_OOP to javafx.base ;

    opens lms.lms_milestone2 to javafx.fxml;
    exports lms.lms_milestone2;
}