
public class customer {
	String username;
	String password;
	String fName;
	String lname;
	double bal;

	public customer(String username, String password, String fName, String lname, String bal) {
		super();
		this.username = username;
		this.password = password;
		this.fName = fName;
		this.lname = lname;
		this.bal = Double.parseDouble(bal);

	}

	public double withdraw(double amt) {
		if (amt > bal) {
			;
			System.out.println("Withraw fail!");
			return -1;
		} else {
			;
			System.out.println("Withraw Success!");
			bal -= amt;
		}
		return bal - amt;

	}

	public double deposit(double amt) {
		System.out.println("Deposit Success!");
		bal += amt;
		return bal;
	}

}
