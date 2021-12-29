using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Setting
    {
        public static void AddCustomListing(List<CryptoModelList> obj)
        {
            Random r = new Random();
            int x = 900, y = r.Next(x);
            string name, price, confirm;
            double p;

            Console.Clear();

            Console.Write("You are adding a new listing.\nWhat will be your coin name?: ");
            name = Console.ReadLine();

            Console.Write($"What will be your first bid to '{name}': ");
            price = Console.ReadLine();
            p = double.Parse(price);

            Console.WriteLine($"\nYour listing will be:\nCrypto: {name}\nFirst bid: {p}");
            Console.Write("\ncrypto@do-you-confirm? yes/no: ");
            confirm = Console.ReadLine();

            if (confirm == "yes")
            {
                obj.Add(new CryptoModelList
                {
                    Id = y,
                    Name = name,
                    Price = p
                });

                Crypto.ShowListing(obj);
            }
            else
            {
                Console.Clear();
                Crypto.ShowListing(obj);
            }
        }

        public static List<CryptoModelList> AddListing()
        {
            List<CryptoModelList> m = new List<CryptoModelList>();
            List<string> names = new List<string>() { "LTC Litecoin", "DOGE Dogecoin", "BTC Bitcoin", "ETH Ethereum" };
            Random r = new Random();
            int x = 900, z = 3000, y, w;

            for (int i = 0; i < 4; i++)
            {
                y = r.Next(x);
                w = r.Next(z);
                m.Add(new CryptoModelList
                {
                    Id = y,
                    Name = names[i],
                    Price = w
                });
            }
            return m;
        }

        public static void CalculateVariation(CryptoModelList variation, double x, double y)
        {
            List<CryptoModelList> list = new List<CryptoModelList>();
            double result = x - (y / x) * 100;

            variation.Variation = result;
            list.Add(variation);
        }

        public static void ShowCommands()
        {
            Console.WriteLine("List of commands");
            Console.WriteLine("BUY (code)       Used to buy a crypto.");
            Console.WriteLine("ADD              To add your own listing.");
            Console.WriteLine("WALLET           To check your own wallet.");
            Console.WriteLine("CLEAR            To clean your console.\n");
        }
    }
}
