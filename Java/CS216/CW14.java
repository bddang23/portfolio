import java.util.Scanner;
public class CW14 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the size of an array: ");
		int n = input.nextInt();
		int[] arr = new int[n];
		
		for (int i=0; i<n; i++) {
			System.out.print("Enter number " + (i+1) + ": ");
			arr[i] = input.nextInt();
			
		}
		
		for (int i = 1; i<arr.length; i++) {
			if (arr[i]>arr[i-1] && arr[i]>arr[i+1])
				System.out.println("Found peak at position " + (i+1));
		}
		
	}

}
