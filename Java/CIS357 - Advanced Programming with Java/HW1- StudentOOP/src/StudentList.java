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

class StudentList extends Students {
	ArrayList<Students> studentList;

	public StudentList() {
		studentList = new ArrayList<>();
	}
	
	public void showList() {
		System.out.println(String.format("%-20s %-20s %-20s", "Last","First","Course"));
		System.out.println("----------------------------------------------------");
		for(Students s :studentList) {
			System.out.println(String.format("%-20s %-20s %-20s", s.getLastName(),s.getFirstName(),s.getCourse().toString()));
		}
		System.out.println();
	}
	
	public void importFromFile(String fname) {
		 try {
		      File myObj = new File(fname);
		      Scanner myReader = new Scanner(myObj);

		      //read the file and put it into the arraylist
		      while (myReader.hasNextLine()) {
		    	  String name="";
		    	  name = myReader.nextLine();
		    	  String last = name.substring(0, name.indexOf(","));
		    	  String first = name.substring(name.indexOf(" "));
		    	  String classGrade = myReader.nextLine();
		    	  String subject = classGrade.substring(0, classGrade.indexOf(" "));
		    	  String grade = classGrade.substring(classGrade.indexOf(" ")+1);

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
		      myReader.close();
		      
		    } catch (FileNotFoundException e) {
		      System.out.println("An error occurred.");
		      e.printStackTrace();
		    }
	}
	
	public void generateReport(String fname) {
		  try {
		      FileWriter myWriter = new FileWriter(fname);
		    	      
		      ArrayList<Students> physics= new ArrayList<>();
		      ArrayList<Students> history= new ArrayList<>();
		      ArrayList<Students> math= new ArrayList<>();
		      int ctrA=0;
		      int ctrB=0;
		      int ctrC=0;
		      int ctrD=0;
		      int ctrF=0;
		      
		      for (int i =0; i <studentList.size();i++) {
		    	 if (studentList.get(i).getCourse() == Course.PHYSICS)
		    	 	 physics.add(studentList.get(i));
		    	 else  if (studentList.get(i).getCourse()== Course.HISTORY)
		    		 history.add(studentList.get(i));
		    	 else  if (studentList.get(i).getCourse()== Course.MATH)
		    		 math.add(studentList.get(i));
		    	 
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
		      
		      myWriter.write("Student Grade Summary \n");
		      myWriter.write("--------------------- \n");
		 
		      myWriter.write(printer(physics));

		      myWriter.write(printer(history));

		      myWriter.write(printer(math));
		            
		      myWriter.write("OVERALL GRADE DISTRIBUTION \n \n");
		      myWriter.write("A: \t" + ctrA +"\n");
		      myWriter.write("B: \t" + ctrB+"\n");
		      myWriter.write("C: \t" + ctrC+"\n");
		      myWriter.write("D: \t" + ctrD+"\n");
		      myWriter.write("F: \t" + ctrF);
		      myWriter.close();

		    } catch (IOException e) {
		      System.out.println("An error occurred.");
		      e.printStackTrace();
		    }
	}
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
	
	public String printer(ArrayList<Students> list) {
		String className = list.get(0).getCourse().toString() + " CLASS \n \n" ;
		String line0= String.format("%-40s %-5s %-10s %-10s", "Student", "Final" , "Final", "Letter");
		String line1= String.format("%-40s %-5s %-10s %-10s", "Name", "Exam" , "Average", "Grade");
		String line3 = "--------------------------------------------------------------------- \n";
		String line4="";
		 for(Students s: list) {
				 line4 += String.format("%-10s %-30s %-5.0f %-10.2f %-10s \n", s.getFirstName(),s.getLastName(), s.getFinal(),s.finalAverage(),letterGrade(s));
		 }
		return className + line0 + "\n" +line1 +"\n" +line3 +line4 +"\n \n";		
	}

	public static Comparator<Students> stuNameCompare = new Comparator<Students>() {
		public int compare(Students s1, Students s2) {
			if (s1.getLastName().compareTo(s2.getLastName())!=0)
				return s1.getLastName().compareTo(s2.getLastName());
			else 
				return s1.getFirstName().compareTo(s2.getFirstName());
		}
	};
	
	public void sortStudentList() {
		Collections.sort(studentList, stuNameCompare);
	}
}

