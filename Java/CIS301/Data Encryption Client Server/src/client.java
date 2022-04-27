/* Description: A simple TCP client that sends a radius value to the server and requests for 
 * 				corresponding area from the server.
 */

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class client {

	String username, password;
	static Scanner input = new Scanner(System.in);;
	final static String REGEX = "(^[a-zA-Z])((?=[a-zA-Z]{1,})(?=\\d{1,})(?=.*[!@#&()�[\\{\\}]:;',?/*~$^+=<>_]).{4,})(\\d$)";

	public static void main(String[] args) throws Exception {

		Socket socket = new Socket("192.168.56.1", 9000);
		PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
		BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

		System.out.println("-------BANK SYSTEM------");

		int option;

		System.out.println("1.	Existing User");
		System.out.println("2.	New User");
		System.out.print("Enter your option: ");
		option = input.nextInt();
		out.println(option);

		if (option == 1) {
			boolean validLogin = validate(out, in);
			if (validLogin) {
				printOption();
				String bankingOption = input.next().toUpperCase();
				if (bankingOption.equals("E"))
					out.println("E");
				while (!bankingOption.equals("E")) {
					switch (bankingOption) {
					case "W":
						out.println("W");
						System.out.print("Enter amount to withdraw: ");
						double amt = input.nextDouble();
						out.println(amt);
						break;
					case "D":
						out.println("D");
						System.out.print("Enter amount to deposit: ");
						double amount = input.nextDouble();
						out.println(amount);
						break;
					case "C":
						out.println("C");
						break;
					}
					System.out.println(in.readLine());
					System.out.println("--------------------------------------------");
					printOption();
					bankingOption = input.next().toUpperCase();
					if (bankingOption.equals("E"))
						out.println("E");
				}
			}

		} else if (option == 2) {
			input.nextLine(); // flush text
			System.out.print("Please enter your full name: ");
			String name = input.nextLine();
			out.println(name);
			System.out.println(name);

			System.out.print("Please enter your password:");
			boolean isValidPassword = false;
			String password;
			while (!isValidPassword) {
				password = input.nextLine();
				if (password.matches(REGEX)) {
					System.out.println("Register successfuly");
					String username = generateUsername(name);
					System.out.println("Your username is " + username);
					out.println(username);
					out.println(password);

					System.out.print("Please enter your first deposit: ");
					double depAmount = input.nextDouble();
					out.println(depAmount);

					bankOperation(out, in);
					isValidPassword = true;
				} else {
					System.out.println("a password that meets the following requirements:\r\n"
							+ "+ At least six charaters long\r\n" + "+ Atleast one special character\r\n"
							+ "+ At least two numbers\r\n" + "+ At least one upper case and one lowercase alphabet\r\n"
							+ "+ Starts with an alphabet and ends with a number");
					System.out.print("Try Again with Approriate Passwords: ");
				}
			}
		}

		input.close();
		socket.close();

	}

	private static void bankOperation(PrintWriter out, BufferedReader in) throws IOException {
		printOption();
		String bankingOption = input.next().toUpperCase();
		if (bankingOption.equals("E"))
			out.println("E");
		while (!bankingOption.equals("E")) {
			switch (bankingOption) {
			case "W":
				out.println("W");
				System.out.print("Enter amount to withdraw: ");
				double amt = input.nextDouble();
				out.println(amt);
				break;
			case "D":
				out.println("D");
				System.out.print("Enter amount to deposit: ");
				double amount = input.nextDouble();
				out.println(amount);
				break;
			case "C":
				out.println("C");
				break;
			}
			System.out.println(in.readLine());
			System.out.println("--------------------------------------------");
			printOption();
			bankingOption = input.next().toUpperCase();
			if (bankingOption.equals("E"))
				out.println("E");
		}
	}

	private static String generateUsername(String name) {
		String username = "";
		String fname = name.split(" ")[0];
		username += fname.substring(0, 1);

		String lname = name.split(" ")[1];
		username += lname;

		int numOfChar = name.replace(" ", "").length();
		username += numOfChar;

		return username;
	}

	private static boolean validate(PrintWriter out, BufferedReader in) throws NumberFormatException, IOException {
		String username, password;
		int ctr = 0;
		while (true) {
			if (ctr == 3) {
				System.out.println("Reach maximum attempts!");
				return false;
			}

			System.out.print("Please enter your username: ");
			username = input.next();
			out.println("login_username " + username);
			// check if there are appear to have the username
			// if have the username,let the user enter the password
			if (Integer.parseInt(in.readLine()) == -1) {
				System.out.println("Invalid Username!");
				ctr++;
				continue;
			} else {
				int countInvalid = 0;
				// if password exceed 3 time try, the whoel program break
				while (countInvalid < 3) {
					System.out.print("Please enter your passwords: ");
					password = input.next();
					out.println(password);
					if (Integer.parseInt(in.readLine()) == -1) {
						countInvalid++;
						if (countInvalid == 3) {
							System.out.println("Maximum Attempts! Terminated");
							out.println("stop");
							return false;
						} else {
							System.out.println("Try Again!");
							continue;
						}
					} else
						return true;
				}
			}
		}
	}

	public static void printOption() {
		System.out.println("W - Withdraw");
		System.out.println("D - Deposit");
		System.out.println("C - Check Balance");
		System.out.println("E - Exit");
		System.out.print("Enter your option: ");
	}
}
