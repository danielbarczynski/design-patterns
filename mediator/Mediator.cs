using System;
using System.Collections.Generic;

public interface IUzytkownik
{
    void WyslijWiadomosc(string wiadomosc);
    void OdbierzWiadomosc(string wiadomosc);
}

public interface IMediator
{
    void DodajUzytkownika(IUzytkownik uzytkownik);
    void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca);
}

public class Mediator : IMediator
{
    List<IUzytkownik> uzytkownicy;

    public Mediator()
    {
        uzytkownicy = new List<IUzytkownik>();
    }

    public void DodajUzytkownika(IUzytkownik uzytkownik)
    {
        uzytkownicy.Add(uzytkownik);
    }

    public void WyslijWiadomosc(string wiadomosc, IUzytkownik nadawca)
    {
        nadawca.OdbierzWiadomosc(wiadomosc);
    }
}

public class Klient : IUzytkownik
{
    string login;
    IMediator Mediator;

    public Klient(IMediator Mediator, string login)
    {
        this.login = login;
        this.Mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc)
    {
        Mediator.WyslijWiadomosc(wiadomosc, this);
    }

    public void OdbierzWiadomosc(string wiadomosc)
    {
        Console.WriteLine("Użytkownik " + login + " otrzymal wiadomosc: " + wiadomosc);
    }
}

public class Dev : IUzytkownik
{
    string login;
    IMediator Mediator;

    public Dev(IMediator Mediator, string login)
    {
        this.login = login;
        this.Mediator = Mediator;
    }

    public void WyslijWiadomosc(string wiadomosc)
    {
        Mediator.WyslijWiadomosc(wiadomosc, this);
    }

    public void OdbierzWiadomosc(string wiadomosc)
    {
        Console.WriteLine("Programista " + login + " otrzymal wiadomosc: " + wiadomosc);
    }
}

class Program62
{
    static void Main(string[] args)
    {

        Mediator mediator = new Mediator();

        IUzytkownik ania = new Klient(mediator, "Ania");
        IUzytkownik geohot = new Dev(mediator, "Geohot");
        IUzytkownik nakamoto = new Dev(mediator, "Nakamoto");

        mediator.DodajUzytkownika(ania);
        mediator.DodajUzytkownika(geohot);
        mediator.DodajUzytkownika(nakamoto);

        nakamoto.WyslijWiadomosc("Prosze natychmiast wprowadzic poprawki na produkcje.");
        geohot.WyslijWiadomosc("Prosze natychmiast wprowadzic poprawki na produkcje.");
        ania.WyslijWiadomosc("Czekam az Nakamoto zaparzy kawe...");
        nakamoto.WyslijWiadomosc("Czekam az Nakamoto zaparzy kawe...");

    }
}