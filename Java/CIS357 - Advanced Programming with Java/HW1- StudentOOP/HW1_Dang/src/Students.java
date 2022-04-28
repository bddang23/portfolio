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

public class Students {
	private String firstName;
	 private String lastName;
	 private Course course;
	 
	 //getter and setters for all main info
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return lastName;
	}
	public Course getCourse() {
		return course;
	}
	public void setCourse(Course course) {
		this.course = course;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	
	//no-arg constructor when create student without name
	public Students() {
		firstName ="";
		lastName="";
	}

	//arg constructoer that assigned name and last name
	public Students(String firstName, String lastName) {
		this.firstName = firstName;
		this.lastName = lastName;
	}

	//function that base class need for later use
	double finalAverage() {
		return 0;
	}
	
	//function get final for the subclass
	double getFinal() {
		return 0;
	}
}

//subclass Hstory class
class HistoryStudent extends Students {
	 private double Attendance, Project, Midterm, Final = 0;

	 //constructors assigned data to variable
	public HistoryStudent(String firstName, String lastName, double attendance, double project, double midterm, double final1) {
		super(firstName, lastName);
		Attendance = attendance;
		Project = project;
		Midterm = midterm;
		Final = final1;
		setCourse(Course.HISTORY);
	}

	//function return the final average using the logic provided
	 double finalAverage() {
		double rawFinal = Attendance*0.1+ Project*0.3 + Midterm *0.3+ Final*0.3;
		double FinalAverage = Math.sqrt(rawFinal) * 10;
		return FinalAverage;
	}
	 
	 //return final score when studentsList subclass call for printing
	 double getFinal() {
			return Final;
		}
}

//Physics subclass
class PhysicsStudent extends Students{
	 private double lab1, lab2,lab3, research, midterm, Final = 0;
	 
	 ////constructors assigned data to variable
	public PhysicsStudent(String firstname, String lastName, double lab1, double lab2, double lab3, double research, double midterm, double final1) {
		super(firstname, lastName);
		setCourse(Course.PHYSICS);
		this.lab1 = lab1;
		this.lab2 = lab2;
		this.lab3 = lab3;
		this.research = research;
		this.midterm = midterm;
		Final = final1;
	}
	
	//return final score when studentsList subclass call for printing
	double getFinal() {
		return Final;
	}

	//function return the final average using the logic provided
	 double finalAverage() {
		 double labs[] = {lab1,lab2,lab3}; 
		 double lowest = labs[0];
		 //find the lowest score
		 for (int i=1; i<labs.length; i++){
			 if (lowest > labs[i])
				 lowest = labs[i];
		 }
		 
		 double totalLabs=0;
		 
		 //later add up the 2 hihest score for finding average
		 for (int i=0;i<labs.length;i++) {
			 if(labs[i]!=lowest)
				 totalLabs += labs[i];
		 }
		 
		 double finalAverage = totalLabs/2 *0.2 + research*0.25+ midterm*0.25+ Final*0.3;
		 return finalAverage;
	 }
}

//Math subclass
class MathStudent extends Students{
	private double quiz1,quiz2,quiz3,quiz4,quiz5,midterm1,midterm2,Final = 0 ;
	
	//return final score when studentsList subclass call for printing
	double getFinal() {
		return Final;
	}

	 //constructors assigned data to variable
	public MathStudent(String first, String last, double quiz1, double quiz2, double quiz3, double quiz4, double quiz5,
			double midterm1, double midtem2, double final1) {
		super(first, last);
		this.quiz1 = quiz1;
		this.quiz2 = quiz2;
		this.quiz3 = quiz3;
		this.quiz4 = quiz4;
		this.quiz5 = quiz5;
		this.midterm1 = midterm1;
		this.midterm2 = midtem2;
		Final = final1;
		setCourse(Course.MATH);
		}

	//function return the final average using the logic provided
	double finalAverage() {
		 double total=0;
		 double averageQuiz = (quiz1+quiz2+quiz3+quiz4+quiz5)/5;
		 double finalAverage = averageQuiz *0.2 + midterm1*.25 + midterm2*0.25 + Final*0.3; 
		 return finalAverage;
	 }
}

enum Course{
			HISTORY,
			PHYSICS,
			MATH		
}	
