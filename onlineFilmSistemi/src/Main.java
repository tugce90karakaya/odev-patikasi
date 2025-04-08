//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
class Uygulama{
    private boolean abonelikDurumu = false;

    public void filmListele(){
        System.out.println("Filmler listelenir");
    }
    public void filmSirala(){
        System.out.println("Filmler siralanir.");
    }
    public void aboneOl(){
        System.out.println("Kullanıcı abone oldu.");
        abonelikDurumu = true;
    }
    public void filmKirala(){
        if(abonelikDurumu){
            System.out.println("Film bedeli ... tl dir. Tutar hesabınızdan düşülür.");
        }
        else{
            System.out.println("Abone olmadan film kiralanamaz. Film kiralamak için abone olunuz.");
        }
    }

    public void filmSatinAl(){
        if(abonelikDurumu == true|| abonelikDurumu == false){
            System.out.println("Normal kullanıcılar ve abone olan kullanıcılar film satın alabilir.");
        }
    }

    public void filmTalepEt(){
        System.out.println("Film mevcut değilse talep edilebilir.");
    }
}
class Kullanici extends Uygulama{

    public Kullanici() {
    }

    public void krediSatinAl(){
        System.out.println("Abonelik için kredi satın alınır.");
    }
}
public class Main {
    public static void main(String[] args) {
        Kullanici k1 = new Kullanici();
        k1.aboneOl();
        k1.filmKirala();
    }
}