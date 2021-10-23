import java.util.Scanner;
public class Method {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		int num = input.nextInt();
		FindNum(num);
	}
	public static void FindNum(int num){
		if (num>0)
			System.out.println(1);
		else if (num<0)
			System.out.println(-1);
		else
			System.out.println(0);
	}
	}
