using System;
using System.Collections.Generic;

public class Zycie
{

    public string Czas; // @update: czyli to miala byc prawdopodobnie metoda wywolywana z Zycia... wowczas moj Main mialby 50 linijek krocej xD 

    //update2:a nie chwila jak sprawdzałem poczatkowy kod to jest zycie.Czas = "1885"; czyli to jednak ma byc zmienna. to juz nic nie rozumiem. ide spac

    public Pamiatka zapiszPamiatke()
    {
        Console.WriteLine("stan zapisany");

        return new Pamiatka(Czas);
    }

    public void przywrocPamiatke(Pamiatka pamiatka)
    {
        Czas = pamiatka.Czas;
        Console.WriteLine($"Przyrwócono rok: {Czas}");
    }
}

public class Pamiatka : Zycie
{
    private string czas;

    public Pamiatka(string czas)
    {
        Czas = czas;
    }

    public string pobierzCzas()
    {
        return $"Skok do roku: {Czas}"; // teraz w sumie zauwazylem, ze ta metoda powinna po prostu zwracac czas i inne metody powinny z niej korzystac, juz szczerze mowiac nie chce mi sie calego wzorca zmieniac, ale mniej wiecej wiem jakby mial wygladac
    }
}


class MainClass
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Powrot do przyszlosci (Back to the Future)");
        Console.WriteLine();

        List<Pamiatka> zapisaneStany = new List<Pamiatka>();
        Zycie zycie = new Zycie();


        zycie.Czas = "1985"; // @update: ahaaaaa Czas odnosi sie do metody nie stringa... i wszystko jasne
        Pamiatka pamiatka1 = new Pamiatka("1985"); // cos mi sie wydaje ze nawet niepotrzebnie wywoluje ta pamiatke, bo tego zycie.Czas w ogole nie uzywam. ale tak jak wczesniej wspomnialem musialbym caly wzorzec zmieniac. 
        Console.WriteLine(pamiatka1.pobierzCzas());
        zapisaneStany.Add(zycie.zapiszPamiatke());

        zycie.Czas = "1955";
        Pamiatka pamiatka2 = new Pamiatka("1955");
        Console.WriteLine(pamiatka2.pobierzCzas());
        zapisaneStany.Add(zycie.zapiszPamiatke());

        zycie.Czas = "2015";
        Pamiatka pamiatka3 = new Pamiatka("2015");
        Console.WriteLine(pamiatka3.pobierzCzas());
        zapisaneStany.Add(zycie.zapiszPamiatke());

        zycie.Czas = "1885";
        Pamiatka pamiatka4 = new Pamiatka("1885");
        Console.WriteLine(pamiatka4.pobierzCzas());
        zapisaneStany.Add(zycie.zapiszPamiatke());

        zycie.przywrocPamiatke(zapisaneStany[0]);

    }
}