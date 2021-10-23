import java.util.Scanner;
public class demoTest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		 Scanner input = new Scanner(System.in); //initializing a Scanner to read input from console
	        
	
	        System.out.print("Enter length : ");
	        int Length = input.nextInt();
	        
	  
	        int List[] = new int [Length];
	        
	        System.out.print("Enter numbers : ");
	        for(int i=0;i<Length;i++)
	        	List[i] = input.nextInt();
	        
	        if (Length == 0 || Length ==1 ) {
	        	 System.out.println("yes");
	         }
	        else {
	        	boolean check = isSuiGeneris(List);
	        	if (check == true)
	        		 System.out.println("yes");
	        	else 
	        		 System.out.println("no");
	        }
	        
	}
	
	public static boolean isSuiGeneris (int[] num) {
		boolean firstTime = true;
		for ( int i =0; i < num.length; i++) {
		
			for (int j =0; j<i;j++) {
				if (num[i]==num[j]) {
					firstTime = false;
					return firstTime;
				}
			}
		
	}
		return firstTime;	
}
}
