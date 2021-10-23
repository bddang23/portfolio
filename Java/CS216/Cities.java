import java.util.Scanner;
public class Cities {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input =  new Scanner(System.in);
		String s1 = input.next();
		String s2 = input.next();
		if(s1.compareTo(s2)<=0) {
			System.out.println(s1);
			System.out.println(s2);
		}
		else{
			System.out.println(s2);
			System.out.println(s1);
		}
		
		
	}

}
