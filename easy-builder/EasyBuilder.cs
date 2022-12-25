Director director = new Director();
Builder concreteBuilder = new ConcreteBuilder();
Builder marbleBuilder = new MarbleBuilder();

director.Construct(concreteBuilder);
concreteBuilder.house.ShowHouse();

director.Construct(marbleBuilder);
marbleBuilder.house.ShowHouse();

class Director
{
    public void Construct(Builder builder)
    {
        builder.BuildWall();
        builder.BuildFloor();
        builder.BuildRoof();
    }
}

abstract class Builder
{
    public House house;

    public abstract void BuildWall();
    public abstract void BuildFloor();
    public abstract void BuildRoof();
}

public class House
{
    public string Type {get; set;}
    public string Wall { get; set; }
    public string Floor { get; set; }
    public string Roof { get; set; }
    
    public House(string type)
    {
        Type = type;
    }

    public void ShowHouse()
    {
        Console.WriteLine(Type);
        Console.WriteLine(Wall);
        Console.WriteLine(Floor);
        Console.WriteLine(Roof);
    }
}

class ConcreteBuilder : Builder
{
    public ConcreteBuilder()
    {
        house = new House("Concrete house");
    }
    public override void BuildWall()
    {
        house.Wall += "concrete wall ";
    }

    public override void BuildFloor()
    {
        house.Floor += "concrete floor ";
    }

    public override void BuildRoof()
    {
        house.Roof += "concrete roof";
    }
}

class MarbleBuilder : Builder
{
    public MarbleBuilder()
    {
        house = new House("Marble house");    
    }
    
    public override void BuildWall()
    {
        house.Wall += "marble wall ";
    }

    public override void BuildFloor()
    {
        house.Floor += "marble floor ";
    }

    public override void BuildRoof()
    {
        house.Roof += "marble roof";
    }
}