using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library
{
    public static class Setting
    {
        public static void AddCustomListing(List<CryptoModelList> obj)
        {
            string name, price, confirm;
            double p;
            Random r = new Random();
            int x = 900;
            int y = r.Next(x);

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
            double result = x - (y / x) * 100;
            List<CryptoModelList> m = new List<CryptoModelList>();
            variation.Variation = result;
            m.Add(variation);
        }

        public static List<WalletModelList> CryptoAddress()
        {
            List<WalletModelList> wallet = new List<WalletModelList>();

            var rsaServer = new RSACryptoServiceProvider(1024);
            var publicKeyXml = rsaServer.ToXmlString(false);

            var rsaClient = new RSACryptoServiceProvider(1024);
            rsaClient.FromXmlString(publicKeyXml);

            var data = Encoding.UTF8.GetBytes("Data To Be Encrypted");

            var encryptedData = rsaClient.Encrypt(data, false);
            var decryptedData = rsaServer.Decrypt(encryptedData, false);

            wallet.Add(new WalletModelList
            {
                Key = decryptedData
            });

            return wallet;
        }
    }
}
