
public class Unique {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] num = {1,2,2,3,4};
		Unique(num);
		
		
		}
	
	public static void Unique(int[] num) {
		System.out.print(num[0]);
		for ( int i =1; i < num.length; i++) {
			boolean firstTime = true;
			for (int j =0; j<i;j++) {
				if (num[i]==num[j]) {
					firstTime = false;
					break;
				}
			}
			if (firstTime == true)
				System.out.print(num[i]);
		}
	}
}
