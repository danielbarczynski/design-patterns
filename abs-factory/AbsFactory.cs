using System;
using System.Text;


enum Alphabets { Latin, Greek, Cyrillic };


abstract class Factory
{

    public abstract Numbers CreateNumbers();
    public abstract Letters CreateLetters();

    public static Factory chooseFactory(Alphabets alphabet)
    {
        switch (alphabet)
        {
            case Alphabets.Cyrillic:
                return new CyrillicFactory();         
            case Alphabets.Greek:
                return new GreekFactory();
            case Alphabets.Latin:
                return new LatinFactory();
            default: 
                throw new NotImplementedException();
        }
    }
}


//---------------------------------------------------------------------------------------


class LatinFactory : Factory
{
    public override Letters CreateLetters()
    {
        return new LatinaLetters();
    }
    public override Numbers CreateNumbers()
    {
        return new LatinaNumbers();
    }
}
class GreekFactory : Factory
{
    public override Letters CreateLetters()
    {
        return new GreekLetters();
    }
    public override Numbers CreateNumbers()
    {
        return new GreekNumbers();
    }
}
class CyrillicFactory : Factory
{
    public override Letters CreateLetters()
    {
        return new CyrillicLetters();
    }
    public override Numbers CreateNumbers()
    {
        return new CyrillicNumbers();
    }
}


//---------------------------------------------------------------------------------------

abstract class Letters
{
    public abstract string GetLetters();
}
abstract class Numbers
{
    public abstract string GetNumbers();
}


//---------------------------------------------------------------------------------------


class CyrillicNumbers : Numbers
{
    public override string GetNumbers()
    {
        return "1 2 3";
    }
}
class CyrillicLetters : Letters
{
    public override string GetLetters()
    {
        return "абвгд";
    }
}

class LatinaNumbers : Numbers
{
    public override string GetNumbers()
    {
        return "I II III";
    }
}
class LatinaLetters : Letters
{
    public override string GetLetters()
    {
        return "abcde";
    }
}
class GreekNumbers : Numbers
{
    public override string GetNumbers()
    {
        return "αʹ βʹ γʹ";
    }
}
class GreekLetters : Letters
{
    public override string GetLetters()
    {
        return "αβγδε";
    }
}


//---------------------------------------------------------------------------------------


public class Application
{
    public static void Main(String[] args)
    {
        Factory latinAlphabetFactory = Factory.chooseFactory(Alphabets.Latin);        
        Factory greekAlphabetFactory = Factory.chooseFactory(Alphabets.Greek);        
        Factory cyrillicAlphabetFactory = Factory.chooseFactory(Alphabets.Cyrillic);

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("{0} {1}", cyrillicAlphabetFactory.CreateLetters().GetLetters(), cyrillicAlphabetFactory.CreateNumbers().GetNumbers());
        Console.WriteLine("{0} {1}", latinAlphabetFactory.CreateLetters().GetLetters(), latinAlphabetFactory.CreateNumbers().GetNumbers());
        Console.WriteLine("{0} {1}", greekAlphabetFactory.CreateLetters().GetLetters(), greekAlphabetFactory.CreateNumbers().GetNumbers());
    }
}

