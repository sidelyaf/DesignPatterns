using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ProxyApi proxyApi = new ProxyApi();
 
            GetCurrentPrice(proxyApi, true);

            GetCurrentPrice(proxyApi, false);
            Console.ReadLine();
        }

        private static void GetCurrentPrice(ProxyApi proxyApi, bool isGold)
        {
            int _price = proxyApi.GetCurrentGoldPrices(isGold);

            if (_price > 0)
            {
                Console.WriteLine($"Current gold price is : {_price}");
            }
            else
            {
                Console.WriteLine("No call to the api");
            }
            Console.WriteLine();
        }
    }

    public interface IPrice
    {
        int GetPrice();
    }

    public class GoldPrices : IPrice
    {
        public int GetPrice()
        {
            Random random = new Random();
            return random.Next(999, 99999);
        }
    }

    public class ProxyApi
    {
        IPrice _price;

        public int GetCurrentGoldPrices(bool price)
        {
            if (price)
            {
                _price = new GoldPrices();
                return _price.GetPrice();
            }
            return 0;
        }
    }
}
