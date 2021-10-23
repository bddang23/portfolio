import java.util.Scanner;
public class Avg {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the amount of numbers: ");
		int n = input.nextInt();
		
		int[] num = new int[n];
		int i;
		int total = 0;
		for (i=0; i<n; i++) {
			System.out.print("Enter number " + (i+1) + ": ");
			num[i] = input.nextInt();
			total += num[i];
		}
		
		double average = total/n*1.0;
		int count=0;
		for (i=0; i<n; i++) {
			if (num[i]>average)
				count++;
		}
		System.out.println("The average is "+ average);
		System.out.println(count + " numbers are larger than " +average);;
		
			
		
	}

}
