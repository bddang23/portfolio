import java.util.Scanner;

public class tuition {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input = new Scanner (System.in);
		System.out.println("Enter the year order ");
		int N = input.nextInt();
		double tuition = 10000;
		int ctr = 0;
		double tuition_N_year = 0;
		double totalAfterN = 0;
		while (ctr <= N + 4)
		{
			
			if (ctr == N)
			{
				tuition_N_year = tuition;
				System.out.println("Tuition in "+ N + " year is $" + tuition_N_year);
			}
			
			if ((ctr > N) || (ctr == N + 4))
			{
				totalAfterN += tuition;
				
				System.out.println("Total cost of four years’ worth of tuition after the " + N + "th year is $" + totalAfterN);
			}
			
			tuition += tuition * 0.05;
			ctr++;
		}
	
		

	}

}
