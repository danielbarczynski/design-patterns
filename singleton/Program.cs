using System;

namespace Singleton
{
    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.
    class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        private static Singleton? _instance;
        public static List<int> nums = new();

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public static void someBusinessLogic(int i)
        {
            nums.Add(i);
        }
    }

    class NotSingleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.

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
            // The client code.
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance(); // working on the same instance
            // Singleton s3 = new(); // can't do it because of private constructor

            Console.WriteLine(s1 == s2 ? true : false); // are the same
            Singleton.someBusinessLogic(1);
            Singleton.someBusinessLogic(2);
            // basically it works like static class

            foreach (var item in Singleton.nums)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("-------");

            NotSingleton ns1 = new();
            NotSingleton ns2 = new();

            Console.WriteLine(ns1 == ns2 ? true : false); // are the same
            ns1.someBusinessLogic(1);
            ns2.someBusinessLogic(2);

            foreach (var item in ns1.nums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
