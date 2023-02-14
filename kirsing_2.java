import java.util.Arrays;

public class kirsing_2 {
    public static void main(String[] args){
        ül1(args);
    }
    public static void ül1(String[] args){
        int[] arr={2,3,5,6};
        if(arr.length == 0){
            System.out.println("0");
        }
        else{ 
            if(arr.length == 1){
                System.out.println(arr[0]);
            }
            else{
                int vastus = arr[1] * arr[arr.length-1];
                System.out.println(vastus);
            }
        }
    }
}
