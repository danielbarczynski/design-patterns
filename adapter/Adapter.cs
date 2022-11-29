using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WzorzecAdapter
{
    /* UDAŁO SIĘ! Znaczy udało mi się w końcu rozgryźć o co tu chodzi. 
    Wciąż nie wiem jak zapisać to jako tablice, żeby mi drukowało osobe jedna pod drugą, 
    ale pogłówkuję jeszcze nad tym. Póki co wysyłam taką wersję.
    UPDATE: Usunąłem całą zawartość kodu z xml, bo mi przeszkadzał
    UPDATE2: Udało się wydrukować dane jedno pod drugim! */

    public class UsersApi
    {
        public async Task<string> GetUsersCsvAsync()
        {
            string csv = "AdamNowak,KatarzynaKowalska,WojciechJankowski";
            // to chyba źle, ale nie mam pojęcia jak to inaczej zapisać
            // próbowałem dla ułatwienia od razu jako array zapisać, ale nic z tego
            //update: dobra już wiem o co chodzi
            return await Task.Fromresult(csv);

        }

    }

    public interface ICsv
    {
        List<string> GetUserNames();
    }

    public class CsvAdapter : ICsv
    {
        private UsersApi adaptee;

        public CsvAdapter(UsersApi adaptee)
        {
            this.adaptee = adaptee;
        }
        public List<string> GetUserNames()
        {
            string csv = adaptee.GetUsersCsvAsync().GetAwaiter().Getresult();

            List<string> users = new List<string>();
            List<string[]> userss = new List<string[]>();
            //update: tablica, by nie drukowało danych jako jednego stringa
            userss.Add(csv.Split(','));

            foreach (var x in userss)
            {
                foreach (var xx in x)
                {
                    users.Add(xx);
                    Console.WriteLine(xx);
                }
            }

            return users;

        }
    }

    public class Program
    {

        static void Main(string[] args)
        {

            UsersApi userApi = new UsersApi();
            CsvAdapter csvAdapter = new CsvAdapter(userApi);

            List<string> users = csvAdapter.GetUserNames();
        }

    }
}