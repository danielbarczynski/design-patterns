Director director = new Director();
Builder concreteBuilder = new ConcreteBuilder();
Builder marbleBuilder = new MarbleBuilder();

director.Construct(concreteBuilder);
Console.WriteLine(concreteBuilder.product.name);

director.Construct(marbleBuilder);
Product product = marbleBuilder.product;
Console.WriteLine(product.name);

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
    public Product product;

    public Builder()
    {
        product = new Product();
    }

    public abstract void BuildWall();
    public abstract void BuildFloor();
    public abstract void BuildRoof();
}

public class Product
{
    public string name = "";
    public Product()
    {
        name = "The house of: ";
    }
}

class ConcreteBuilder : Builder
{
    public override void BuildWall()
    {
        product.name += "concrete wall ";
    }

    public override void BuildFloor()
    {
        product.name += "concrete floor ";
    }

    public override void BuildRoof()
    {
        product.name += "concrete roof";
    }
}

class MarbleBuilder : Builder
{
    public override void BuildWall()
    {
        product.name += "marble wall ";
    }

    public override void BuildFloor()
    {
        product.name += "marble floor ";
    }

    public override void BuildRoof()
    {
        product.name += "marble roof";
    }
}