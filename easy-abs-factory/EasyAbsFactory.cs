var primarySchoolTest = new MathTest(new PrimarySchool());
primarySchoolTest.CreateTest();
System.Console.WriteLine(primarySchoolTest.number);

interface INumber {};
class EasyNumber : INumber { };
class HardNumber : INumber { };
// you can add IShape with the convention
abstract class MathTestFactory
{
    public abstract INumber CreateTest();
}

class PrimarySchool : MathTestFactory
{
    public override INumber CreateTest()
    {
        return new EasyNumber();
    }
}
// you can add SecondarySchool with the convention for HardNumber
class MathTest
{
    private MathTestFactory _mathTest;
    public INumber number;

    public MathTest(MathTestFactory mathTestFactory)
    {
        _mathTest = mathTestFactory;
    }

    public void CreateTest()
    {
        number = _mathTest.CreateTest();
    }
}