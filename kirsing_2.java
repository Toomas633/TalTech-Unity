import org.junit.platform.console.shadow.picocli.CommandLine.ExitCode;

public class kirsing_2 {
    public static void main(String[] args){
        ül3(args);
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
    public static void ül2(String[] args){
        String es="kapsas", te="sibul";
        String vastus = "";
        if(es.charAt(es.length()-1) == te.charAt(0)){
            vastus = es.substring(0,es.length()-1) + te.substring(1, te.length());
        }
        else{
            vastus = es + te.substring(1, te.length());
        }
        System.out.println(vastus);
    }
    public static void ül3(String[] args){
        int [] arr = {2,3,3,4,4,2,3,4};
        //int [] arr = {1,1,3,2,1,2,2,2};
        boolean vastus = false, lõpp = false;
        while(lõpp != true){
            for(int i = 0; i < arr.length-2; i++){
                if(arr[i]+1 == arr[i+1]){
                    if(arr[i+1]+1 == arr[i+2]){
                        vastus = lõpp =true;
                    }
                    else vastus = lõpp = false;
                }
                else vastus = lõpp = false;
            }
            lõpp = true;
        }
        System.out.println(vastus);
    }
}
