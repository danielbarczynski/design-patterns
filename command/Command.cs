using System;

public interface IPolecenie
{
    void wykonaj();
}

public class KomendaWlacz : IPolecenie
{
    Lampa lampa;
    public KomendaWlacz(Lampa _lampa)
    {
        lampa = _lampa;
    }
    public void wykonaj()
    {
        lampa.wlacz();
    }
}

public class KomendaWylacz : IPolecenie
{
    Lampa lampa;
    public KomendaWylacz(Lampa _lampa)
    {
        lampa = _lampa;
    }
    public void wykonaj()
    {
        lampa.wylacz();
    }
}

public class Lampa
{
    //public string? stan; // remedium na metode sprawdz
    public bool stan;
    public void wlacz()
    {
        stan = true;
        Console.WriteLine("Lampa włączona");
    }

    public void wylacz()
    {
        stan = false;
        Console.WriteLine("Lampa wyłączona");
    }
    public bool sprawdz()
    {
        //if (stan == "on")
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return stan;
    }
}

public class Pilot
{
    private IPolecenie polecenie;

    public void ustawPolecenie(IPolecenie _polecenie)
    {
        polecenie = _polecenie;
    }

    public void wcisnijGuzik()
    {
        polecenie.wykonaj();
    }
}

class Program61
{
    static void Main(string[] args)
    {
        Pilot pilot = new Pilot();
        Lampa lampa = new Lampa();
        IPolecenie wlacz = new KomendaWlacz(lampa);
        IPolecenie wylacz = new KomendaWylacz(lampa);

        Console.WriteLine(lampa.sprawdz() ? "Lampa włączona" : "Lampa wyłączona"); // jak w js'ie, czyli bool true zwraca pierwszy string

        pilot.ustawPolecenie(wlacz);
        pilot.wcisnijGuzik();

        pilot.ustawPolecenie(wylacz);
        pilot.wcisnijGuzik();
    }
}
