import javax.sound.sampled.*;
import java.io.File;
import java.io.IOException;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.

class Asansor{
    private int yolcuKapasitesi;//yaklaşık 6 yetişkin.

    public Asansor(int yolcuKapasitesi) {
        this.yolcuKapasitesi = yolcuKapasitesi;
    }
}
class Kullanici extends Asansor{


    public Kullanici(int yolcuKapasitesi) {
        super(yolcuKapasitesi);

    }

    public void asansorGirisCikisKontrol(int bulunduguKat, int hedefKati) {
        int i;
        System.out.println(bulunduguKat+". kat kapı kapanıyor.");
        sesCal("elevator_ding.wav");

        if(hedefKati > bulunduguKat){
            sesCal("yukariYon.wav");
            for (i = bulunduguKat; i <= hedefKati; i++) {
                System.out.print("\rAsansör şu anda " + i + ". katta...");
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
            System.out.println("\n"+hedefKati+".kat hedef kata ulaşıldı. Kapı açılıyor.");
            sesCal("elevator_ding.wav");
        }
        else {
            sesCal("asagiYon.wav");
            for (i = bulunduguKat; i >= hedefKati; i--) {
                System.out.print("\rAsansör şu anda " + i + ". katta...");
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
            System.out.println("\n"+hedefKati+".kat hedef kata ulaşıldı. Kapı açılıyor.");
            sesCal("elevator_ding.wav");
        }


    }


    public void sesCal(String dosyaAdi) {
        try {
            File sesDosyasi = new File(dosyaAdi);
            if (!sesDosyasi.exists()) {
                System.out.println("Ses dosyası bulunamadı: " + dosyaAdi);
                return;
            }

            AudioInputStream stream = AudioSystem.getAudioInputStream(sesDosyasi);
            Clip clip = AudioSystem.getClip();
            clip.open(stream);
            clip.start();

            // Sesin çalması bitene kadar bekle
            Thread.sleep(clip.getMicrosecondLength() / 1000);
        } catch (UnsupportedAudioFileException | IOException |
                 LineUnavailableException | InterruptedException e) {
            e.printStackTrace();
        }
    }

}
public class Main {
    public static void main(String[] args) {
    Kullanici k1 = new Kullanici(6);
    k1.asansorGirisCikisKontrol(12,3);
    }
}