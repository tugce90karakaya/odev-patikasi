//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
class Kemirgenler extends Hayvan {
    private String turAdi;
    private float agirlik;
    private int yas;

    public Kemirgenler(String turAdi, int yas, float agirlik) {
        super(turAdi, yas, agirlik);
        this.turAdi = turAdi;
        this.yas = yas;
        this.agirlik = agirlik;
    }

    @Override
    public float getAgirlik() {
        return agirlik;
    }

    @Override
    public void setAgirlik(float agirlik) {
        this.agirlik = agirlik;
    }

    @Override
    public int getYas() {
        return yas;
    }

    @Override
    public void setYas(int yas) {
        this.yas = yas;
    }

    @Override
    public String getTurAdi() {
        return turAdi;
    }

    @Override
    public void setTurAdi(String turAdi) {
        this.turAdi = turAdi;
    }

    @Override
    public void getDosage() {
        System.out.println(getTurAdi()+" için yem dozajı belirlenir.");
    }

    @Override
    public void getFeedSchedule() {
        System.out.println(getTurAdi()+" için yem zamanı belirlenir.");
    }
}

class Kedigiller extends Hayvan{
    private String turAdi;
    private float agirlik;
    private int yas;

    public Kedigiller(String turAdi, int yas, float agirlik) {
        super(turAdi, yas, agirlik);
        this.turAdi = turAdi;
        this.yas = yas;
        this.agirlik = agirlik;
    }

    @Override
    public String getTurAdi() {
        return turAdi;
    }

    @Override
    public void setTurAdi(String turAdi) {
        this.turAdi = turAdi;
    }

    @Override
    public int getYas() {
        return yas;
    }

    @Override
    public void setYas(int yas) {
        this.yas = yas;
    }

    @Override
    public float getAgirlik() {
        return agirlik;
    }

    @Override
    public void setAgirlik(float agirlik) {
        this.agirlik = agirlik;
    }

    @Override
    public void getDosage() {
        System.out.println(getTurAdi()+" için yem dozajı belirlenir.");
    }

    @Override
    public void getFeedSchedule() {
        System.out.println(getTurAdi()+" için yem zamanı belirlenir.");
    }
}

class Atlar extends Hayvan{

    private String turAdi;
    private float agirlik;
    private int yas;

    public Atlar(String turAdi, int yas, float agirlik) {
        super(turAdi, yas, agirlik);
        this.turAdi = turAdi;
        this.agirlik = agirlik;
        this.yas = yas;
    }

    @Override
    public String getTurAdi() {
        return turAdi;
    }

    @Override
    public void setTurAdi(String turAdi) {
        this.turAdi = turAdi;
    }

    @Override
    public float getAgirlik() {
        return agirlik;
    }

    @Override
    public void setAgirlik(float agirlik) {
        this.agirlik = agirlik;
    }

    @Override
    public int getYas() {
        return yas;
    }

    @Override
    public void setYas(int yas) {
        this.yas = yas;
    }

    @Override
    public void getDosage(){
        System.out.println(getTurAdi()+" için yem dozajı belirlenir.");
    }

    @Override
    public void getFeedSchedule() {
        System.out.println(getTurAdi()+" için yem zamanı belirlenir.");
    }
}

class Hayvan {

    private String turAdi;
    private float agirlik;
    private int yas;

    public Hayvan(String turAdi, int yas, float agirlik) {
        this.turAdi = turAdi;
        this.yas = yas;
        this.agirlik = agirlik;
    }

    public String getTurAdi() {
        return turAdi;
    }

    public void setTurAdi(String turAdi) {
        this.turAdi = turAdi;
    }

    public int getYas() {
        return yas;
    }

    public void setYas(int yas) {
        this.yas = yas;
    }

    public float getAgirlik() {
        return agirlik;
    }

    public void setAgirlik(float agirlik) {
        this.agirlik = agirlik;
    }

    public void getDosage(){
        System.out.println("Hayvan için yem dozajı belirlenir.");
    }

    public void getFeedSchedule (){
        System.out.println("Hayvan için yem verme zamanı belirlenir.");
    }
}

public class Main {
    public static void main(String[] args) {
        Atlar at = new Atlar("At",3,70.7f);
        at.getDosage();
        Kedigiller kaplan = new Kedigiller("Kaplan",4,89.7f);
        kaplan.getFeedSchedule();
    }
}
