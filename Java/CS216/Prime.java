import java.util.Scanner;
public class Prime {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner(System.in);
		int num;
		System.out.print("Enter a number: "); 
		num = input.nextInt();
		boolean result = isPrime(num);
		int numReverse = Reverse(num);
		boolean resultReverse = isPrime(numReverse);
		if (result == true && resultReverse == true)
			System.out.println(num + " is a Emirp number");
		else
			System.out.println(num + " is NOT a Emirp number");
		
		
	}
	public static boolean isPrime(int num) {
		boolean Prime = true;
		for (int i = 2; i<= num/2; i++) {
			if (num%i == 0)
				Prime = false;
			break;
		}
		return Prime;
	}
	
	public static int Reverse(int num) {
		int reverse = 0;
		while(num != 0) {
		    int digit = num % 10;
		    num= num/10;
		    reverse = reverse * 10 + digit;
		}
		return reverse;
	}
}

