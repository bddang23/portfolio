import java.util.Scanner;
public class array {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] arr = {1,2,3,4,5,6,7};
		Print(arr);
		ShiftK(arr,3);
		Print(arr);
System.out.println(arr.length);
	}
	public static void Print(int arr[]) {
	//int temp = arr[0];
	//arr[0]=arr[arr.length-1];
	//arr[arr.length-1]=temp;
	for (int val: arr)
		System.out.print(val + " ");
	System.out.println();
	}
	
	public static void ShiftK(int[] arr, int k) {
		int[] copy = new int[k];
		
		for (int i=0;i<k;i++)
			copy[i]=arr[i];
		
		for (int i=0,j=k;i<k+1 && k<arr.length;i++,j++) {
			arr[i]=arr[j];
		}
		
		for (int i=k+1, j=0 ; i<arr.length && j<copy.length; i++,j++) {
			arr[i]=copy[j];
		}	
			
		
		
		
	}
}
