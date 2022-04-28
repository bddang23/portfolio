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

//import for later user
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;

//subclass StudentList where it do all the unction and logic of this program
class StudentList extends Students {
	private ArrayList<Students> studentList;

	//no arg constructor that create an empty array list
	public StudentList() {
		studentList = new ArrayList<>();
	}
	
	//should output a list of students with their first name , last name and course name
	public void showList() {
		System.out.println(String.format("%-20s %-20s %-20s", "Last","First","Course"));
		System.out.println("----------------------------------------------------");
		//for every element in the student list,
		//loop through and print the first, last name, and course them in
		for(Students s :studentList) {
			System.out.println(String.format("%-20s %-20s %-20s", s.getLastName(),s.getFirstName(),s.getCourse().toString()));
		}
		System.out.println();
	}
	
	//should read in a file and populate your arraylist. The format of this file is listed below.
	public void importFromFile(String fname) {
		 try {
		      File myObj = new File(fname); //instatiate obj for reading file
		      Scanner myReader = new Scanner(myObj);

		      //read the file and put it into the arraylist
		      while (myReader.hasNextLine()) {
		    	  //Read name on first line
		    	  String name="";
		    	  name = myReader.nextLine();
		    	  
		    	  //Read the second line and filter the data so look better
		    	  String last = name.substring(0, name.indexOf(","));
		    	  String first = name.substring(name.indexOf(" "));
		    	  String classGrade = myReader.nextLine();
		    	  String subject = classGrade.substring(0, classGrade.indexOf(" "));
		    	  String grade = classGrade.substring(classGrade.indexOf(" ")+1);

		    	  //64-100:
		    	  /*Depends on the subject, program will call different constructor for each 
		    	   subclass then later populate the arraylist*/
		    	  if (subject.contentEquals("History")) {
		    		  String[] point = grade.split(" ");
		    		  double attendance =  Double.parseDouble(point[0].trim());
		    		  double project = Double.parseDouble(point[1].trim());
		    		  double midterm = Double.parseDouble(point[2].trim());
		    		  double Final = Double.parseDouble(point[3].trim());
		    		  Students s = new HistoryStudent(first,last,attendance,project,midterm, Final);
			    	  studentList.add(s);
		    	  }
		    	  else if (subject.contentEquals("Math"))  {
		    		  
		    		  String[] point = grade.split(" ");

		    		  double quiz1 =  Double.parseDouble(point[0].trim());
		    		  double quiz2 =  Double.parseDouble(point[1].trim());
		    		  double quiz3 =  Double.parseDouble(point[2].trim());
		    		  double quiz4 =  Double.parseDouble(point[3].trim());
		    		  double quiz5 =  Double.parseDouble(point[4].trim());
		    		  double midterm1 = Double.parseDouble(point[5].trim());
		    		  double midterm2 = Double.parseDouble(point[6].trim());
		    		  double Final = Double.parseDouble(point[7].trim());
		    		  Students s = new MathStudent(first,last,quiz1 ,quiz2 ,quiz3 ,quiz4 ,quiz5 ,midterm1, midterm2, Final);
			    	  studentList.add(s);
			    	 
		    	  }
		    	  else if (subject.contentEquals("Physics")) {
		    		  String[] point = grade.split(" ");
		    		  double lab1 =  Double.parseDouble(point[0]);
		    		  double lab2 =  Double.parseDouble(point[1]);
		    		  double lab3 =  Double.parseDouble(point[2]);
		    		  double research = Double.parseDouble(point[3]);
		    		  double midterm = Double.parseDouble(point[4]);
		    		  double Final = Double.parseDouble(point[5]);
		    		  Students s = new PhysicsStudent(first,last,lab1,lab2,lab3,research,midterm, Final);
			    	  studentList.add(s);
		    	  }
		      }
		      
		      myReader.close(); //stop reading file
		      
		      //if student list is empty then print
		      if (studentList.isEmpty()) {
		    	  System.out.println("File is Empty! Please entered I and Try Again! \n");
		      }
		      if (studentList.size()==1) {
		    	  System.out.println("Only one entry! Let's try again \n");
		      }
		      
		    } catch (FileNotFoundException e) {
		    	//in case error occured print the statement
		      System.out.println("No File is Found!");
		    }
	}
	
	/*method should accept a string parameter as a filename and export a detailed report of the student,
	 *  in the format shown in the sample output.
	 */
	public void generateReport(String fname) {
		  try {
		      FileWriter myWriter = new FileWriter(fname);//instantiate writer obj
		    	      
		      //differnet arraylist for each class and diffferent counter for every rade
		      ArrayList<Students> physics= new ArrayList<>();
		      ArrayList<Students> history= new ArrayList<>();
		      ArrayList<Students> math= new ArrayList<>();
		      int ctrA=0;
		      int ctrB=0;
		      int ctrC=0;
		      int ctrD=0;
		      int ctrF=0;
		      
		      /*loop through the whole studentList arraylist
		       * then added it to proper class arraylist as well as increase the counter or each grade
		       * as it analyze
		       */
		      for (int i =0; i <studentList.size();i++) {
		    	  //condition for adding to propper list
		    	 if (studentList.get(i).getCourse() == Course.PHYSICS)
		    	 	 physics.add(studentList.get(i));
		    	 else  if (studentList.get(i).getCourse()== Course.HISTORY)
		    		 history.add(studentList.get(i));
		    	 else  if (studentList.get(i).getCourse()== Course.MATH)
		    		 math.add(studentList.get(i));
		    	 
		    	 //condition for upgrade counter
		    	 if(letterGrade(studentList.get(i)).equals("A"))
		    			 ctrA++;
		    	 else if(letterGrade(studentList.get(i)).equals("B"))
	    			 	ctrB++;
		    	 else if(letterGrade(studentList.get(i)).equals("C"))
	    			 	ctrC++;
		    	 else if(letterGrade(studentList.get(i)).equals("D"))
	    			 	ctrD++;
		    	 else if(letterGrade(studentList.get(i)).equals("A"))
	    			 	ctrF++;
		    	 
		      }
		      
		      //Start Writing report on ile
		      myWriter.write("Student Grade Summary \n");
		      myWriter.write("--------------------- \n");
		 
		      //call printer function for printing to obh
		      myWriter.write(printer(physics));
		      myWriter.write(printer(history));
		      myWriter.write(printer(math));
		            
		      //Printing the overall score of three class with riht counter
		      myWriter.write("OVERALL GRADE DISTRIBUTION \n \n");
		      myWriter.write("A: \t" + ctrA +"\n");
		      myWriter.write("B: \t" + ctrB+"\n");
		      myWriter.write("C: \t" + ctrC+"\n");
		      myWriter.write("D: \t" + ctrD+"\n");
		      myWriter.write("F: \t" + ctrF);
		      myWriter.close();

		    } catch (FileNotFoundException e) {
		    	//in case there are error, say this!
		    	System.out.println("Error occured!");
		    } catch (IOException e) {
				// TODO Auto-generated catch block
		    	System.out.println("Error occured!");
			}
	}
	
	//This function take in a student onj
	//then later look and use the final average functon of that obj
	//to return a string of grade
	public String letterGrade(Students s) {
		String letterGrade ="F";
		if (s.finalAverage() >=90)
			letterGrade = "A";
		else if(s.finalAverage() >=80)
			letterGrade="B";
		else if (s.finalAverage()>=70) 
			letterGrade="C";
		else if (s.finalAverage()>=60) 
			letterGrade="D";
		return letterGrade;
	}
	
	//function printer that take in the arraylist
	//that populate every student final, and studentaverage along with letter grade
	public String printer(ArrayList<Students> list) {
		String className = list.get(0).getCourse().toString() + " CLASS \n \n" ;
		String line0= String.format("%-40s %-5s %-10s %-10s", "Student", "Final" , "Final", "Letter");
		String line1= String.format("%-40s %-5s %-10s %-10s", "Name", "Exam" , "Average", "Grade");
		String line3 = "--------------------------------------------------------------------- \n";
		String line4="";
		
		//a loop go through every studnets and print info
		 for(Students s: list) {
				 line4 += String.format("%-10s %-30s %-5.0f %-10.2f %-10s \n", s.getFirstName(),s.getLastName(), s.getFinal(),s.finalAverage(),letterGrade(s));
		 }
		 
		 //return a string that has necessary info for that class
		return className + line0 + "\n" +line1 +"\n" +line3 +line4 +"\n \n";		
	}

	//A comparator that is use for sorting
	public static Comparator<Students> stuNameCompare = new Comparator<Students>() {
		//if last name equal then compare the first name
		public int compare(Students s1, Students s2) {
			if (s1.getLastName().compareTo(s2.getLastName())!=0)
				return s1.getLastName().compareTo(s2.getLastName());
			else 
				return s1.getFirstName().compareTo(s2.getFirstName());
		}
	};
	
	/*should sort the list of students alphabetically based on their last name. 
	 * If the last names match, they should be sorted on the basis of their first name. 
	 * The method should sort the student list in-place. The method should not output anything,
	 *  however if the user were to invoke listStudents(), they should now see the student list in alphabetical order.
	 */
	public void sortStudentList() {
		Collections.sort(studentList, stuNameCompare);
	}
}

