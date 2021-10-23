import java.util.Scanner;
public class Sum {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		int num1, num2;
		num1 = input.nextInt();
		num2 = input.nextInt();
		AddMethod(num1,num2);
		int sum = AddMethod(num1, num2);
		System.out.println(sum);		

	}
	public static int AddMethod(int num1, int num2) {
	    int res = num1 + num2;
		return res;
}
}
