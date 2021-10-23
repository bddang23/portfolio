import java.util.Scanner;
public class PigLatin {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner input =  new Scanner(System.in);
		System.out.print("Enter a word: ");
		String word = input.next();
		pigLatin(word);
	}
	
	public static void pigLatin(String word) {
		int indexVowel = firstVowel(word);
		String afterVowel = word.substring(indexVowel);
		String beforeVowel = word.substring(0, indexVowel);
		String pigLatin = afterVowel + beforeVowel + "ay";
		System.out.println("In Pig-Latin is "+ pigLatin);
	}
	
	public static int firstVowel(String word) {
		int idx=0;
		
		while (idx < word.length()){
			char ch=word.charAt(idx);
			
			if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U' ) {
				return idx;
			}
			
			idx++;
		}
		return idx;
	}
	
	
}
