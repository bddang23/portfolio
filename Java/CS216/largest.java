import java.util.Scanner;
public class largest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the amount of numbers: ");
		int n = input.nextInt();
		
		int[] num = new int[n];
		int i;
		
		for (i=0; i<n; i++) {
			System.out.print("Enter number " + (i+1) + ": ");
			num[i] = input.nextInt();
			
		}
		
		int max =num[0];
		for (i=1; i<n; i++) {
			if (num[i]>max)
				max=num[i];
		}
		System.out.println("The largest number is " + max);
		
	}

}