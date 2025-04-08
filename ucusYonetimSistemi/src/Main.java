//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
class HavaAlani {
    private int id;
    private String isim;

    public HavaAlani(int id, String isim) {
        this.id = id;
        this.isim = isim;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getIsim() {
        return isim;
    }

    public void setIsim(String isim) {
        this.isim = isim;
    }
}

class HavaYoluSirketi extends HavaAlani{
    private int pilot;
    private int pilotDeneyimSuresi;

    public HavaYoluSirketi(int id, String isim, int pilot, int pilotDeneyimSüresi) {
        super(id, isim);
        this.pilot = pilot;
        this.pilotDeneyimSuresi = pilotDeneyimSuresi;
    }

    public int getPilot() {
        return pilot;
    }

    public void setPilot(int pilot) {
        this.pilot = pilot;
    }

    public int getPilotDeneyimSuresi() {
        return pilotDeneyimSuresi;
    }

    public void setPilotDeneyimSuresi(int pilotDeneyimSuresi) {
        this.pilotDeneyimSuresi = pilotDeneyimSuresi;
    }

    public void ucakTipi(int pilot){
        System.out.println("Bu uçak tipi "+pilot+" tane pilota ihtiyaç duyar.");
    }
    public void ucakDurumu(boolean cevap){
        if(cevap){
            System.out.println("Bu uçak çalışır durumdadır.");
        }
        else{
            System.out.println("Bu uçak bakımdadır.");
        }
    }
}

class Ucus extends HavaYoluSirketi{
    private int id;
    private String kalkacagiHavaAlani;
    private String inecegiHavaAlani;
    private String kalkisSaati;
    private String inisSaati;

    private String yrdPilot;

    public Ucus(int id, String isim, int pilot, int pilotDeneyimSüresi, String yrdPilot, String kalkacagiHavaAlani, String inecegiHavaAlani, String kalkisSaati, String inisSaati) {
        super(id, isim, pilot, pilotDeneyimSüresi);
       
        this.yrdPilot = yrdPilot;
        this.kalkacagiHavaAlani = kalkacagiHavaAlani;
        this.inecegiHavaAlani = inecegiHavaAlani;
        this.kalkisSaati = kalkisSaati;
        this.inisSaati = inisSaati;

    }

    @Override
    public int getId() {
        return id;
    }

    @Override
    public void setId(int id) {
        this.id = id;
    }

    public String getKalkacagiHavaAlani() {
        return kalkacagiHavaAlani;
    }

    public void setKalkacagiHavaAlani(String kalkacagiHavaAlani) {
        this.kalkacagiHavaAlani = kalkacagiHavaAlani;
    }

    public String getInecegiHavaAlani() {
        return inecegiHavaAlani;
    }

    public void setInecegiHavaAlani(String inecegiHavaAlani) {
        this.inecegiHavaAlani = inecegiHavaAlani;
    }

    public String getKalkisSaati() {
        return kalkisSaati;
    }

    public void setKalkisSaati(String kalkisSaati) {
        this.kalkisSaati = kalkisSaati;
    }

    public String getInisSaati() {
        return inisSaati;
    }

    public void setInisSaati(String inisSaati) {
        this.inisSaati = inisSaati;
    }


    public String getYrdPilot() {
        return yrdPilot;
    }

    public void setYrdPilot(String yrdPilot) {
        this.yrdPilot = yrdPilot;
    }
}

public class Main {
    public static void main(String[] args) {
    Ucus u1 = new Ucus(1,"THY",3,6,"var","Esenboga","Istanbul","10.00","11.00");
    u1.ucakTipi(3);
    }
}