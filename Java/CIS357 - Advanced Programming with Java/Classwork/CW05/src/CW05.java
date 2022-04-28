import java.util.HashMap;
import java.util.HashSet;

public class CW05 {
    public static void main(String[] args) {
        int arr[]={1,5,7,-7,-1,0,6,89,-83,13};
        int sum =13;

        findPairs(arr,sum);
    }

    public static void findPairs(int[] arr, int sum) {
        HashSet<Integer> set = new HashSet<>();
        System.out.print("Pairs with sum "+ sum + " are ");
        for (int i =0;i<arr.length;i++){
            if (set.contains(sum-arr[i])) {
                System.out.print("(" + arr[i] + "," + (sum - arr[i]) + ") ");
                set.add(arr[i]);
            }
            else
                set.add(arr[i]);
        }
    }
}
