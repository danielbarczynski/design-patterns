using System;

namespace Singleton
{
    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.
    sealed class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        private static Singleton? _instance;
        public List<int> nums = new();

        public static Singleton GetInstance // can be also method
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        
        }

        public void someBusinessLogic(int i)
        {
            nums.Add(i);
        }
    }

    class NotSingleton
    {
        public List<int> nums = new();

        public void someBusinessLogic(int i)
        {
            nums.Add(i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance;
            Singleton s2 = Singleton.GetInstance; // working on the same instance
            // Singleton s3 = new(); // can't do it because of private constructor

            Console.WriteLine(s1 == s2 ? true : false); // are the same
            
            s1.someBusinessLogic(1);
            s2.someBusinessLogic(2);

            foreach (var item in s1.nums) //* prints 1 and 2 for s1 and s2
            {
                Console.WriteLine(item);
            }

            // ------------------------------------------------
            
            Console.WriteLine("-------");

            NotSingleton ns1 = new();
            NotSingleton ns2 = new();

            Console.WriteLine(ns1 == ns2 ? true : false); // are the same
            ns1.someBusinessLogic(1);
            ns2.someBusinessLogic(2);

            foreach (var item in ns1.nums) // prints only 1 or 2
            {
                Console.WriteLine(item);
            }
        }
    }
}
