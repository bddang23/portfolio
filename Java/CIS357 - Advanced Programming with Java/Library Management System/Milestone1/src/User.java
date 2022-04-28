import java.time.LocalDate;
public class User {
    //declare approriate field for user
    private int ID;
    private String name;
    private String email;
    private String address;
    private LocalDate dateOfBirth;
    private boolean isStudent;
    private double balance;
    private static int userAdded=0;

    //a constructor for the user passingg in name, email, address, dob, and boolean isStudent
    public User(String name, String email, String address, LocalDate dateOfBirth, boolean isStudent) {
        ID = userAdded;
        this.name = name;
        this.email = email;
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.isStudent = isStudent;
        balance = 0.0;
        userAdded++;
    }

    @Override
    //overide toString method return id and name
    public String toString() {
        return "ID: " + ID + " name= " + name;
    }

    @Override
    //overide equals method to compare ID of the user
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof User)) return false;
        User user = (User) o;
        return ID == user.ID;
    }

    //line 41-77 is the getter and setter for each field
    public int getID() {
        return ID;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    public String getAddress() {
        return address;
    }
    public void setAddress(String address) {
        this.address = address;
    }
    public LocalDate getDateOfBirth() {
        return dateOfBirth;
    }
    public void setDateOfBirth(LocalDate dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }
    public boolean isStudent() {
        return isStudent;
    }
    public void setStudent(boolean student) {
        isStudent = student;
    }
    public double getBalance() {
        return balance;
    }
    public void setBalance(double balance) {
        this.balance = balance;
    }
}
