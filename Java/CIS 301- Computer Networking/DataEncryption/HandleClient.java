
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class HandleClient implements Runnable {
	Socket socket;
	String username = "";
	boolean validUsername = false;
	ArrayList<customer> Customers;
	HashMap<String, String> userNpassword;
	PrintWriter out;
	BufferedReader in;

	HandleClient(Socket socket) {
		this.socket = socket;
	}

	public void run() {
		try {
			Customers = populateArray();
			userNpassword = populateHashMap(Customers);

			out = new PrintWriter(socket.getOutputStream(), true);
			in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

			System.out.println("Waiting for input!");
			String optionInput = in.readLine();
			System.out.println(optionInput);
			switch (optionInput) {
			case "1":
				boolean validated = loginValidation();
				if (validated) {
					customer c = findCustomer(username);

					BankOperation(c);
					updateFile();
				}
				break;
			case "2":
				String name = in.readLine();
				String fname = name.split(" ")[0];
				String lname = name.split(" ")[1];
				System.out.println(fname + " " + lname);

				String username = in.readLine();
				String password = in.readLine();
				System.out.println(username + " " + password);

				String depAmt = in.readLine();
				customer c = new customer(username, password, fname, lname, depAmt);
				Customers.add(c);
				BankOperation(c);
				updateFile();
				break;
			}
		} catch (Exception e) {
			System.out.println(e);
		}

	}

	private void BankOperation(customer c) throws IOException {
		String option = in.readLine();
		while (!option.equals("E")) {
			switch (option) {
			case "W":
				double amt = Double.valueOf(in.readLine());
				System.out.println("Request Withraw " + amt);
				double result = c.withdraw(amt);
				if (result == -1)
					out.println("Amount Exceed " + c.bal + "! Unable to Withdraw.");
				else
					out.println("Withdraw Successful ! Balance now is " + c.bal);
				break;
			case "D":
				double amount = Double.valueOf(in.readLine());
				c.deposit(amount);
				out.println("Deposit Successful ! Balance now is " + c.bal);
				break;
			case "C":
				System.out.println("check balance!");
				out.println("Current Balance is " + c.bal);
				break;
			}
			option = in.readLine();
		}
	}

	private void updateFile() {
		File file = new File("Users.txt");
		file.delete();
		try {
			file.createNewFile();
		} catch (IOException e) {
			e.printStackTrace();
		}

		try {
			FileWriter myWriter = new FileWriter("Users.txt");
			for (customer c : Customers) {
				myWriter.write(c.username + " " + c.password + " " + c.fName + " " + c.lname + " " + c.bal + '\n');
			}
			myWriter.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}

	private boolean loginValidation() throws IOException {
		boolean validated = false;
		while (true) {
			String input = in.readLine();
			// first validate the username
			if (input.contains("login_username")) {
				validUsername = validateUsername(input);

			}
			// if the user name is valid
			if (validUsername) {
				while (true) {
					input = in.readLine();
					if (input.equals("stop")) {
						break;
					} else {
						validated = checkPassword(input);
						if (validated)
							return validated;
					}
				}
				return validated;
			} else
				System.out.println("Wrong Username!");
		}

	}

	private boolean checkPassword(String input) throws IOException {
		// TODO Auto-generated method stub
		String password = input;
		if (!userNpassword.containsValue(password) & userNpassword.containsKey(username)) {
			out.println(-1);
			System.out.println("Login User " + username + " fail");
			return false;
		}

		else {
			out.println(1);
			System.out.println("Login User " + username + " successfully");
			return true;
		}

	}

	private boolean validateUsername(String input) {
		// TODO Auto-generated method stub
		username = input.split(" ")[1];
		if (!userNpassword.containsKey(username)) {
			out.println(-1);
			return false;
		} else {
			out.println(1);
			return true;
		}
	}

	private customer findCustomer(String username) {
		for (customer c : Customers) {
			if (c.username.equals(username)) {
				return c;
			}
		}
		return null;
	}

	private HashMap<String, String> populateHashMap(ArrayList<customer> customers) {
		HashMap<String, String> accounts = new HashMap<String, String>();
		;
		for (customer c : customers) {
			accounts.put(c.username, c.password);
		}
		return accounts;
	}

	@SuppressWarnings("resource")
	private ArrayList<customer> populateArray() throws FileNotFoundException {
		File data = new File("Users.txt");
		Scanner s = new Scanner(data);
		ArrayList<customer> customers = new ArrayList<>();
		while (s.hasNextLine()) {
			String info[] = s.nextLine().split(" ");
			customers.add(new customer(info[0], info[1], info[2], info[3], info[4]));
		}
		return customers;
	}
}
