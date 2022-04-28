 /*Grade Report Generator
 * a system that stores student grade information for a university.
 * For 3 classes, History,Physics and Math. The program will take in input (import)
 * and process different functions like calculate the final average, show the students list
 * export to report file as well as sorting the list
 *
 * @author  Binh Dang
 * @version 1.0
 * @since   2022-02-02
 */

import java.util.*; // this import is needed to use Scanner
import java.io.*; //this import is needed for writer and reader

public class Student_Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		  //initializing a Scanner to read input from console
		Scanner s = new Scanner(System.in);
		
		//call printerInfo to show the option to the user!
		printInfo();
		
		//create an onject studentList for later user
		StudentList list = new StudentList();
		
		System.out.print("> ");
		//Make all the command that user type in uppercase 
		String command = s.nextLine().toUpperCase();
		
		//Only if the user type Q, else it will take in the command 
		while (!command.contentEquals("Q")) {
			//if user enter I, then it will take in file path name then process it add it in the arraylist
			if (command.contentEquals("I")) {
				System.out.print("Enter filename : "); 
				String fname = s.nextLine();
				list.importFromFile(fname);
			}
			
			//if user enter L, it will print out the list of student's full name with course they in
			else if(command.contentEquals("L")) {
				list.showList();
			}
			
			//if user enter E, System will request a input report file in order to print out to the report file
			else if(command.contentEquals("E")) {
				System.out.print("Enter filename : "); 
				String fname = s.nextLine();
				list.generateReport(fname);
			}
			
			//if user enter S, System will sort the whole list based on their last name then first name
			else if(command.contentEquals("S")) {
				list.sortStudentList();
			}
			
			////if user enter M, System will print out the list of menu option .  
			else if (command.contentEquals("M")) {
				printInfo();
			}
			
			//then system will take in  the next input
			System.out.print("> ");
			command = s.nextLine().toUpperCase();
			System.out.println();
		}
	}
	
	/* Function that print out 5 different options for user to choose
	 * 
	 */
	public static void printInfo() {
		String format = "%-10s %s";
		System.out.println("\t \t *** Report Generator ***");
		System.out.println(String.format(format,"I","Import students from file"));
		System.out.println(String.format(format,"L","Show student roster"));
		System.out.println(String.format(format,"E","Export a grade report"));
		System.out.println(String.format(format,"S","Sort Student List"));
		System.out.println(String.format(format,"M","Show this Menu"));
		System.out.println(String.format(format,"Q","Quit Program"));
		System.out.println();
		
	}
}