using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Setting
    {

        public static void Register()
        {
            List<AccountModel> acc = new List<AccountModel>();

            string name, password;
            int pp;
            bool p = true;

            while (p)
            {
                Console.Write("crypto@enter-nickname: ");
                name = Console.ReadLine();

                if (name.Length > 3)
                {
                    Console.Write($"crypto@{name}-brokerage-crypto password: ");
                    password = Console.ReadLine();
                    pp = int.Parse(password);

                    if (password.Length > 5)
                    {
                        Console.Write($"crypto@{name}-brokerage-crypto: you successfully registered.");

                        acc.Add(new AccountModel{Name = name, Password = pp});
                        p = false;

                        Console.Clear();
                        Crypto.Start(acc);
                    }
                    else
                    {
                        Console.Write($"[error] your password is too small.\n");
                    }
                }
            }
        }

        public static void AddCustomListing(List<AccountModel> obj)
        {
            string name, confirm, price;
            double p;

            List<CryptoModel> listing = new List<CryptoModel>();

            Console.Clear();
            Console.WriteLine("You are adding a new listing.\n");

            foreach (var list in obj)
            {
                Console.Write($"crypto@{list.Name}-enter-crypto-name: ");
            }

            name = Console.ReadLine();

            if (name.Length > 4)
            {
                foreach (var list in obj)
                {
                    Console.Write($"root@{list.Name}-enter-your-first-bid-to '{name}': ");
                }

                price = Console.ReadLine();
                p = Double.Parse(price);

                Console.Write($"\nThis is your listing:\nCrypto: {name}\nFirst Bid: {p}\n\nConfirm? Yes/No: ");
                confirm = Console.ReadLine().ToLower();

                if (confirm == "yes")
                {
                    listing.Add(new CryptoModel
                    {
                        Name = name,
                        Price = p
                    });

                    Console.Clear();
                    Crypto.ShowListing(listing);

                    foreach (var list in obj)
                    {
                        Console.Write($"\ncrypto@{list.Name}-enter-a-command: ");
                    }
                }
                else
                {
                    Console.Clear();
                    Crypto.ShowListing(listing);
                }
            }

            static List<CryptoModel> AddListing()
            {
                List<CryptoModel> m = new List<CryptoModel>();
                List<string> names = new List<string>() { "LTC Litecoin", "DOGE Dogecoin", "BTC Bitcoin", "ETH Ethereum" };

                for (int i = 0; i < 4; i++)
                {
                    m.Add(new CryptoModel
                    {
                        Id = i,
                        Name = names[i],
                        Price = 20
                    });
                }
                return m;
            }
        }
    }
}
