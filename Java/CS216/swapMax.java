
public class swapMax {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] arr = {4, 9, 5, 2, 1, 7, 7, 2, 3, 6};
	
		for (int val: arr) 
			System.out.print(val + " ");
		System.out.println();
		
	
		swapMax(arr);
		
		for (int val: arr) 
			System.out.print(val + " ");
		System.out.println();
		
		
		}
	
	public static void swapMax(int[] arr) {
		int small = arr[0];
		int place = 0;
		for ( int i =1; i<arr.length;i++) {
			if (arr[i] < small) {
				small = arr[i];
				place = i;
			}
		}
		int copy = arr[0];
		arr[0]=small;
		arr[place]=copy;
		
	}	
	
	

}
