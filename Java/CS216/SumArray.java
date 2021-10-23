import java.util.Scanner;
public class SumArray {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int arr[] = {2,4,5,9,11,8,6,12,3,7};
		
		Scanner input =  new Scanner(System.in);
		int k = input.nextInt();
		
		for (int i =0; i<arr.length; i++) {
			for (int j=0; j<arr.length ; j++) {
				if (i != j)  {
					if (arr[i]+arr[j]==k) {
						System.out.print("(" + arr[i] + "," + arr[j] + ")");
					}
				}
			}
		}
	}
}
