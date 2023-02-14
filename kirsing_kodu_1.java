public class kirsing_kodu_1 {
    public static void main(String[] args){
        // vastav ülesanne mida käivitatakse ül1, ...2, ...3, ...4 vastavalt
        ül1(args);
    }
    public static void ül1(String[] args){
        String sisend="paaritu";
        char a, b, c;
        int keskmine=0;
        if(sisend.length() <= 1){
            System.out.println("Sõne on: " + sisend);
        }
        else {
            if(sisend.length() % 2 == 0){ //kas sõne pikkus on paaris või paaritu
                keskmine = sisend.length()/2;
                a = sisend.charAt(keskmine-1);
                b = sisend.charAt(keskmine);
                System.out.println("Kaks keskmist sümbolit on: "+a+" "+b);
            }
            else{
                keskmine = (sisend.length()-1)/2;
                a = sisend.charAt(keskmine-1);
                b = sisend.charAt(keskmine);
                c = sisend.charAt(keskmine+1);
                System.out.println("Kolm keskmist sümbolit on: "+a+" "+b+" "+c);
            }        
        }
    }
}
