using System;
using System.Collections.Generic;

namespace Naukaa46_Observer_
{
    public enum Genre
    {
        Sport,
        Politics,
        Economy,
        Science
    }

    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
    }

    public class NewsAgency : ISubject
    {
        public string NewsHeadline;
        public Genre State;

        public void setNewsHeadline(Genre state, string news)
        {
            NewsHeadline = news;
            State = state;
        }

        private List<IObserver> Observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this.Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this.Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }
    }

    class DailyEconomy : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as NewsAgency).State == Genre.Sport)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł w kategorii {Genre.Sport} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Politics)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł w kategorii {Genre.Politics} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Economy)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł w kategorii {Genre.Economy} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Science)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł w kategorii {Genre.Science} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }

    }

    class NewYorkTimes : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as NewsAgency).State == Genre.Sport)
            {
                Console.WriteLine($"NewYorkTimes publikuje artykuł w kategorii {Genre.Sport} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Politics)
            {
                Console.WriteLine($"NewYorkTimes publikuje artykuł w kategorii {Genre.Politics} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Economy)
            {
                Console.WriteLine($"NewYorkTimes publikuje artykuł w kategorii {Genre.Economy} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Science)
            {
                Console.WriteLine($"NewYorkTimes publikuje artykuł w kategorii {Genre.Science} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }

    class NationalGeographic : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as NewsAgency).State == Genre.Sport)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł w kategorii {Genre.Sport} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Politics)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł w kategorii {Genre.Politics} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Economy)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł w kategorii {Genre.Economy} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
            if ((subject as NewsAgency).State == Genre.Science)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł w kategorii {Genre.Science} \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }

    class Program46
    {
        static void Main(string[] args)
        {
            var newsAgency = new NewsAgency();

            var dailyEconomy = new DailyEconomy();
            var newYork = new NewYorkTimes();
            var nationalGeographic = new NationalGeographic();

            newsAgency.setNewsHeadline(Genre.Economy, "USA is going bancrupt!");
            newsAgency.Attach(dailyEconomy);
            newsAgency.Attach(newYork);
            newsAgency.Notify();

            Console.WriteLine();

            newsAgency.setNewsHeadline(Genre.Science, "Life on Alpha Centauri");
            newsAgency.Attach(nationalGeographic);
            newsAgency.Detach(dailyEconomy);
            newsAgency.Notify();

            Console.WriteLine();

            newsAgency.setNewsHeadline(Genre.Sport, "Adam Małysz is the greatest sportsman in the history of mankind");
            newsAgency.Detach(nationalGeographic);
            newsAgency.Notify();

            Console.WriteLine();

            newsAgency.setNewsHeadline(Genre.Economy, "CD Project RED value has grown by 500% in 2020");
            newsAgency.Attach(dailyEconomy);
            newsAgency.Detach(nationalGeographic);
            newsAgency.Notify();

            Console.WriteLine();

            newsAgency.setNewsHeadline(Genre.Science, "Kirkendall effect causing airplanes' engine deteriorate");          
            newsAgency.Attach(nationalGeographic);
            newsAgency.Detach(dailyEconomy);
            newsAgency.Notify();

            Console.WriteLine();

            newsAgency.setNewsHeadline(Genre.Economy, "Texas is going bancrupt!");
            newsAgency.Detach(nationalGeographic);
            newsAgency.Notify();
        }
    }
}

//DailyEconomy publikuje artykuł "USA is going bancrupt!"
//NewYorkTimes publikuje artykuł "USA is going bancrupt!"

//NewYorkTimes publikuje artykuł "Life on Alpha Centauri"
//NationalGeographic publikuje artykuł "Life on Alpha Centauri"

//NewYorkTimes publikuje artykuł "Adam Małysz is the greatest sportsman in the history of mankind"

//DailyEconomy publikuje artykuł "CD Project RED value has grown by 500% in 2020"
//NewYorkTimes publikuje artykuł "CD Project RED value has grown by 500% in 2020"

//NewYorkTimes publikuje artykuł "Kirkendall effect causing airplanes' engine deteriorate"
//NationalGeographic publikuje artykuł "Kirkendall effect causing airplanes' engine deteriorate"

//NewYorkTimes publikuje artykuł "Texas is going bancrupt!"

//Sport,
//Politics,
//Economy,
//Science