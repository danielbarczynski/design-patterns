using System;

//finished prodcuct (#3)
public class Computer
{
    private string Type { get; set; } // lack of get;set; beacuse of #1
    public string MotherBoard { get; set; }
    public string Processor { get; set; }
    public string Disc { get; set; }
    public string Screen { get; set; }
    public double Price { get; set; }

    public Computer(string computerType) // konstruktor, zawsze ta sama nazwa co klasa, nigdy nic nie zwracaja, nie trzeba pisac void
        // on ma pomoc przy tworzeniu obiektu a nie zajmowac sie liczeniem wartosci #2, (#1)
    {
        Type = computerType;
        Price = 0; // price wzieta z góry, więc tylko string computerType
    }

    public void DisplayConfiguration() // #3 mainly that's why, (#4)
    {
        Console.WriteLine("Typ: " + Type);
        Console.WriteLine("Plyta glowna: " + MotherBoard);
        Console.WriteLine("Procesor: " + Processor);
        Console.WriteLine("Dysk: " + Disc);
        Console.WriteLine("Monitor: " + Screen);
        Console.WriteLine("Cena: " + Price);
    }
}

//director, second class, order to build !!! kierownik powiela te same metody co budowniczy
public class ComputerShop
{
    public void ConstructComputer(ComputerBuilder computerBuilder)// void, cuz it is not named public ComputerShop, same as#4, dlaczego nie ma zmiennej?
    {// class instead of variable?
        computerBuilder.BuildMotherBoard();// to samo, czemu? (#5), wykorzystanie metodd z klasy poniżej w metodzie de facto
        computerBuilder.BuildProcessor();
        computerBuilder.BuildDisc();
        computerBuilder.BuildScreen();
    }
}
//kontrakt dla builder'a
public abstract class ComputerBuilder // odwolanie do powyzej, klasa zawierająca metody, third class
{
    public Computer Computer { get; set; } // to jest konstruktor w sumie tak jak #1, (#6)
    public abstract void BuildMotherBoard();//#5, metoda nic nie zwracajaca
    public abstract void BuildProcessor();
    public abstract void BuildDisc();
    public abstract void BuildScreen();
}
//konkretny builder, tutaj juz budujemy
public class OfficeComputerBuilder : ComputerBuilder // dziedziczy po metodach powyżej, forth class
{
    public OfficeComputerBuilder()//konstruktor
    {
        Computer = new Computer("biurowy"); // użycie computerType #2 oraz Comptuer Computer #6
    }

    public override void BuildMotherBoard() // override void ponieważ jest abstract
    {
        Computer.MotherBoard = "Asus Prime A320M-E";
        Computer.Price += 259.90;
    }
    public override void BuildProcessor()
    {
        Computer.Processor = "AMD Ryzen 5 2600";
        Computer.Price += 589.00;
    }
    public override void BuildDisc()
    {
        Computer.Disc = "Goodram CX400 250 GB SATA3";
        Computer.Price += 149.99;
    }
    public override void BuildScreen()
    {
        Computer.Screen = "BenQ GW2270H (1920x1080)";
        Computer.Price += 369.00;
    }
}

public class GamingComputerBuilder : ComputerBuilder//fith class
{
    public GamingComputerBuilder()
    {
        Computer = new Computer("gamingowy");
    }

    public override void BuildMotherBoard()
    {
        Computer.MotherBoard = "Gigabyte X570 Aorus Elite";
        Computer.Price += 895.60;
    }
    public override void BuildProcessor()
    {
        Computer.Processor = "Intel i7 9700K";
        Computer.Price += 1829.00;
    }
    public override void BuildDisc()
    {
        Computer.Disc = "Samsung 970 EVO Plus 2TB M.2";
        Computer.Price += 2028.45;
    }
    public override void BuildScreen()
    {
        Computer.Screen = "HP Z4W65A4 (3840x1600)";
        Computer.Price += 4927.75;
    }
}

public class ProfessionalComputerBuilder : ComputerBuilder//sixth class
{
    public ProfessionalComputerBuilder()
    {
        Computer = new Computer("profesjonalny");
    }
    public override void BuildMotherBoard()
    {
        Computer.MotherBoard = "Supermicro MBD X11DPH";
        Computer.Price += 2755.30;
    }
    public override void BuildProcessor()
    {
        Computer.Processor = "Intel Xeon Gold 5120";
        Computer.Price += 7999.00;
    }
    public override void BuildDisc()
    {
        Computer.Disc = "Seagate Skyhawk 14TB 3.5";
        Computer.Price += 2101.75;
    }
    public override void BuildScreen()
    {
        Computer.Screen = "Eizo CG319X (4096x2160)";
        Computer.Price += 20749.00;
    }
}

//client
public class Program21//seventh class
{
    static void Main(string[] args) // przekladanie z kierownika do budowniczego ponizej
    {
        ComputerShop computerShop = new ComputerShop();  // never used computer class

        ComputerBuilder OfficeComputer = new OfficeComputerBuilder(); // budujemy od typu, new OfficeComp... instead of new ComputerBuilder
        computerShop.ConstructComputer(OfficeComputer);// ^ bo to nowa klasa z klasy?, dziedziczaca po ComputerBuilder
        OfficeComputer.Computer.DisplayConfiguration();// wyswietlenie consolewriteline

        ComputerBuilder GamingComputer = new GamingComputerBuilder();// tworzenie
        computerShop.ConstructComputer(GamingComputer); // budowanie
        GamingComputer.Computer.DisplayConfiguration(); // wyswietlanie

        ComputerBuilder ProfessionalComputer = new ProfessionalComputerBuilder();
        computerShop.ConstructComputer(ProfessionalComputer);
        ProfessionalComputer.Computer.DisplayConfiguration();
    }
}