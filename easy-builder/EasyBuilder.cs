using System;


class Director
{

    public void construct(Builder builder)
    {
        builder.build_part_a(); // metoda build nr1
        builder.build_part_b();
        builder.build_part_c();
    }

}

abstract class Builder
{

    public Product product;

    public Builder()
    {
        product = new Product();
    }

    public abstract void build_part_a();// metoda build nr2

    public abstract void build_part_b();

    public abstract void build_part_c();

}
public class Product
{

    public string name = "";

    public Product() // if deleted there is only abc
    {
        name = "produkt";
    }

}

class ConcreteBuilder1 : Builder
{

    public override void build_part_a()// metoda build nr3
    {
        product.name += "a";
    }

    public override void build_part_b()
    {
        product.name += "b";
    }
    public override void build_part_c()
    {
        product.name += "c";
    }

}


class ConcreteBuilder2 : Builder
{

    public override void build_part_a()
    {
        product.name += "A";
    }

    public override void build_part_b()
    {
        product.name += "B";
    }
    public override void build_part_c()
    {
        product.name += "C";
    }

}

public class Program24
{
    static void Main(string[] args)
    {

        Director director = new Director();

        Builder concrete_builder = new ConcreteBuilder1();

        director.construct(concrete_builder);
        Product product = concrete_builder.product;
        Console.WriteLine(product.name);

        Builder concrete_builder2 = new ConcreteBuilder2(); //zmodyfikowane przeze mnie, działa :)

        director.construct(concrete_builder2);
        product = concrete_builder2.product;
        Console.WriteLine(product.name);

    }
}