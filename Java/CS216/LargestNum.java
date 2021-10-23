import java.util.Scanner;
public class LargestNum {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		int x, y,z;
		x = input.nextInt();
		y = input.nextInt();
		z = input.nextInt();
		int Max = max(x,y,z);
		System.out.println(Max);
	}
	public static int max(int num1, int num2, int num3) {
		int max;
		if (num1 > num2 && num1 > num3) {
			max = num1;
		}
		else if (num2 > num1 && num2 > num3) 
			max = num2;
		else 
			max = num3;
		return max;			
	}
}
