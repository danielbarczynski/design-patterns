using System;
using System.Collections.Generic;

namespace Naukaa43_composite_
{
    public interface Kompozyt
    {
        void DodajElement(Kompozyt element);
        void UsunElement(Kompozyt element);
        void Renderuj();
    }

    public class Lisc : Kompozyt
    {        
        public string nazwa { get; set; }

        public void Renderuj()
        {
            Console.WriteLine(nazwa + " renderowanie...");
        }

        public void DodajElement(Kompozyt element)
        {
           
        }
        public void UsunElement(Kompozyt element)
        {
            
        }
    }

    public class Wezel : Kompozyt
    {

        private List<Kompozyt> Lista = new List<Kompozyt>();

        public string nazwa { get; set; }

        public void Renderuj()
        {
            Console.WriteLine(nazwa + " rozpoczęcie renderowania");

            foreach (var element in Lista)
            {
                
                element.Renderuj();
            }

            Console.WriteLine(nazwa + " zakończenie renderowania");
        }

        public void DodajElement(Kompozyt element)
        {
            Lista.Add(element);
        }
        public void UsunElement(Kompozyt element)
        {
            Lista.Remove(element);
        }
    }

    public class Korzen : Kompozyt
    {     
        private List<Kompozyt> Lista = new List<Kompozyt>();
        public string nazwa { get; set; }

        public void Renderuj()
        {
            Console.WriteLine(nazwa + " rozpoczęcie renderowania");

            foreach (var element in Lista)
            {
                element.Renderuj();
            }

            Console.WriteLine(nazwa + " zakończenie renderowania");
        }

        public void DodajElement(Kompozyt element)
        {
            Lista.Add(element);
        }
        public void UsunElement(Kompozyt element)
        {
            Lista.Remove(element);
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Korzen korzen = new Korzen();   
            korzen.nazwa = "Korzeń";

            Wezel wezel2 = new Wezel();
            wezel2.nazwa = "Węzeł 2";
            Wezel wezel3 = new Wezel();
            wezel3.nazwa = "Węzeł 3";
            Wezel wezel33 = new Wezel();
            wezel33.nazwa = "Węzeł 3.3";

            Lisc lisc1 = new Lisc();
            lisc1.nazwa = "Liść 1";
            Lisc lisc2 = new Lisc();
            lisc2.nazwa = "Liść 2";
            Lisc lisc3 = new Lisc();
            lisc3.nazwa = "Liść 3";

            korzen.DodajElement(lisc1);
            korzen.DodajElement(wezel2);
            wezel2.DodajElement(lisc1);
            wezel2.DodajElement(lisc2);
            wezel2.DodajElement(lisc3);
            korzen.DodajElement(wezel3);
            wezel3.DodajElement(lisc1);
            wezel3.DodajElement(lisc2);
            wezel3.DodajElement(wezel33);
            wezel33.DodajElement(lisc1);

            korzen.Renderuj();

        }
    }
}