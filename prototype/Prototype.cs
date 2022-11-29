using System;
using System.Collections.Generic;
using System.Text;


    public abstract class ProductPrototype
    {
        public decimal Price { get; set; }

        public ProductPrototype(decimal Price)
        {
            Console.WriteLine("Executing constructor"); // usunąłbym to
            this.Price = Price;
        }

        public ProductPrototype Clone()
        {
            return (ProductPrototype)MemberwiseClone();
        }
    }


    //----------------------------------------------------------


    public class Bread : ProductPrototype
    {
        public Bread(decimal Price) : base(Price) 
        {

        }

    }

public class Butter : ProductPrototype
    {
        public Butter(decimal Price) : base(Price) 
        {

        }
    }


    //----------------------------------------------------------


public class Supermarket
    {
        Dictionary<string, ProductPrototype> productList = new Dictionary<string, ProductPrototype>();

        public void AddProduct(string key, ProductPrototype productPrototype)
        {
            productList.Add(key, productPrototype);
        }

        public ProductPrototype GetClonedProduct(string key)
        {
            return productList[key].Clone();
        }
    }


    //----------------------------------------------------------


    class MainClass
    {
        public static void Main(string[] args)
        {
           
            Supermarket market = new();

            market.AddProduct("Bread", new Bread(9.50m));
            market.AddProduct("Butter", new Butter(5.30m));

            Console.WriteLine($"Bread: {market.GetClonedProduct("Bread").Price} zł > " +
            $"{decimal.ToDouble(market.GetClonedProduct("Bread").Price) * 0.9} zł");
            Console.WriteLine($"Bread: {market.GetClonedProduct("Bread").Price} zł");
            Console.WriteLine($"Butter: {market.GetClonedProduct("Butter").Price} zł");
        }
    }