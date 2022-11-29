using System;

interface Stan
{
    void alert();
}

class Powiadomienia : Stan
{
    // klasa do przelaczania miedzy stanami, do zmienienia

    private Stan aktualnyStan;

    public Powiadomienia()
    {
        aktualnyStan = new Dzwonek();
        // ma wyswietlic ktores ze stanow jako domyslny 
    }

    public void ustawStan(Stan stan)
    {
        aktualnyStan = stan;
        // zmienienie aktualnego stanu na ten podany w parametrze
    }

    public void alert()
    {
       aktualnyStan.alert();
        // wyswietlenie stanu z funckji
    }
}

class Dzwonek : Stan
{
    public void alert()
    {
        Console.WriteLine("dzwonek...");
    }
}

class Wibracja : Stan
{
    public void alert()
    {
        Console.WriteLine("wibracje...");
    }

}

class Wyciszenie : Stan
{
    public void alert()
    {
        Console.WriteLine("wyciszenie...");
    }
}


class Program60
{
    public static void Main(string[] args)
    {
        Powiadomienia powiadomienia = new Powiadomienia();
       
        powiadomienia.alert();
        powiadomienia.ustawStan(new Wibracja());
        powiadomienia.alert();
        powiadomienia.ustawStan(new Dzwonek());
        powiadomienia.alert();
        powiadomienia.ustawStan(new Wyciszenie());
        powiadomienia.alert();
        powiadomienia.alert();
        powiadomienia.ustawStan(new Wibracja());
        powiadomienia.alert();

    }
}