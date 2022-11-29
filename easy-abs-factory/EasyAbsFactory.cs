using System;
using System.Collections.Generic;


interface IShape { }
class Simple : IShape { }
class Hard : IShape { }

interface INumber { }
class RealNumber : INumber { }
class ComplexNumber : INumber { }

abstract class MathTestFactory
{
    public abstract IShape CreateShape();
    public abstract INumber CreateNumber();
}

class PrimarySchoolTestFactory : MathTestFactory
{
    public override IShape CreateShape()
    {
        return new Simple();
    }

    public override INumber CreateNumber()
    {
        return new RealNumber();
    }
}

class HighSchoolTestFactory : MathTestFactory
{
    public override IShape CreateShape()
    {
        return new Hard();
    }

    public override INumber CreateNumber()
    {
        return new ComplexNumber();
    }
}

class MathTest
{

    private MathTestFactory mathTestFactory;

    public IShape shape;
    public INumber number;

    public MathTest(MathTestFactory mathTestFactory)
    {
        this.mathTestFactory = mathTestFactory;
    }

    public void GenerateTest()
    {
        this.shape = this.mathTestFactory.CreateShape();
        this.number = this.mathTestFactory.CreateNumber();
    }

}


/* ############################################## */


class MainClass
{
    public static void Main(string[] args)
    {

        MathTest mathTest;

        mathTest = new MathTest(new PrimarySchoolTestFactory());
        mathTest.GenerateTest();
        Console.WriteLine(mathTest.shape);
        Console.WriteLine(mathTest.number);

        Console.WriteLine();

        mathTest = new MathTest(new HighSchoolTestFactory());
        mathTest.GenerateTest();
        Console.WriteLine(mathTest.shape);
        Console.WriteLine(mathTest.number);

    }
}