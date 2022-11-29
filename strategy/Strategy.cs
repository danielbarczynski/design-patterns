using System;

abstract class Zawodnik
{  
    KopniecieTyp kopniecieTyp;
    SkokTyp skokTyp;

    public Zawodnik(KopniecieTyp kopniecieTyp, SkokTyp skokTyp)
    {
        this.kopniecieTyp = kopniecieTyp;
        this.skokTyp = skokTyp;
    }
    public abstract void przedstaw();
    public void uderzenie()
    {
        Console.WriteLine("Uderzenie");
    }

    public void kopniecie()
    {
        kopniecieTyp.kopniecie();
    }

    public void skok()
    {
        skokTyp.skok();
    }

    public void ustawKopniecieTyp(KopniecieTyp kopniecieTyp)
    {
        this.kopniecieTyp = kopniecieTyp;
    }

    public void ustawSkokTyp(SkokTyp skokTyp)
    {
        this.skokTyp = skokTyp;
    }
}

interface KopniecieTyp
{

    void kopniecie();

}

class KopniecieLod : KopniecieTyp
{
    public void kopniecie()
    {
        Console.WriteLine("Kopniecie lodowe");
    }

}
class KopniecieOgien : KopniecieTyp
{
    public void kopniecie()
    {
        Console.WriteLine("Kopniecie z ogniem");
    }
}

interface SkokTyp
{
    void skok();
}

class KrotkiSkok : SkokTyp
{
    public void skok()
    {
        Console.WriteLine("Krotki skok");
    }
}

class DlugiSkok : SkokTyp
{
    public void skok()
    {
        Console.WriteLine("Dlugi skok");
    }
}

class SubZero : Zawodnik
{
    public SubZero(KopniecieTyp kopniecieTyp, SkokTyp skokTyp) : base(kopniecieTyp, skokTyp)
    {
        ustawKopniecieTyp(kopniecieTyp);
        ustawSkokTyp(skokTyp);
    }

    override public void przedstaw()
    {
        Console.WriteLine("Jestem Sub-Zero!");
    }
}

class Skorpion : Zawodnik
{
    public Skorpion(KopniecieTyp kopniecieTyp, SkokTyp skokTyp) : base(kopniecieTyp, skokTyp)
    {
        ustawKopniecieTyp(kopniecieTyp);
        ustawSkokTyp(skokTyp);
        
    }
    override public void przedstaw()
    {
        Console.WriteLine("Jestem Skorpion!");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-- Mortal Kombat --");
        Console.WriteLine();

        KopniecieTyp kopniecieLod = new KopniecieLod();
        KopniecieTyp kopniecieOgien = new KopniecieOgien();
        SkokTyp krotkiSkok = new KrotkiSkok();
        SkokTyp dlugiSkok = new DlugiSkok();

        Zawodnik subZero = new SubZero(kopniecieLod, krotkiSkok);
        subZero.przedstaw();
        subZero.uderzenie();
        subZero.kopniecie();
        subZero.skok();
        subZero.ustawSkokTyp(dlugiSkok);
        subZero.skok();

        Console.WriteLine();

        Zawodnik skorpion = new Skorpion(kopniecieOgien, dlugiSkok);
        skorpion.przedstaw();
        skorpion.uderzenie();
        skorpion.kopniecie();
        skorpion.ustawKopniecieTyp(kopniecieLod);
        skorpion.kopniecie();
        subZero.skok();
    }
}