using System;

namespace Proxy
{
    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
        public string Data;
        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
            Data = "WSEI data";
        }

        public string GetData()
        {
            return Data;
        }
    }

    public class ProxyClient : IClient
    {
        string _pass = "dobrehaslo";        
        bool _authenticated;

        public ProxyClient(string password)
        {
            if (password == _pass)
            {       
                Console.WriteLine("Correct password. ProxyClient: Initialized");
                _authenticated = true;
            }
            else
            {
                Console.WriteLine("ProxyClient: Wrong password. Access denied");
                _authenticated = false;
            }
        }

        public string GetData()
        {
            if (_authenticated == true)
            {
                RealClient client = new RealClient();
                return client.Data;
            }
            else 
            {
                return "Sorry, you do not have access to any data";
            }         
        }
    }

    class Program42
    {
        static void Main(string[] args)
        {
            ProxyClient proxy1 = new ProxyClient("zlehaslo");
            Console.WriteLine(proxy1.GetData());

            Console.WriteLine();

            ProxyClient proxy2 = new ProxyClient("dobrehaslo");
            Console.WriteLine(proxy2.GetData());         
        }
    }
}