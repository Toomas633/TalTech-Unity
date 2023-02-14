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

    }
}
