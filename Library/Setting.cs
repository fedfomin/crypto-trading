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
            List<AccountModel> list = new List<AccountModel>();

            string name, password;
            int pp;
            bool p = true;

            while (p)
            {
                Console.Write("[sudo] choose a name for your brokerage account: ");
                name = Console.ReadLine();

                if (name.Length > 3)
                {
                    Console.Write($"root@{name}-brokerage-crypto password: ");
                    password = Console.ReadLine();
                    pp = int.Parse(password);

                    if(password.Length > 5)
                    {
                        Console.Write($"root@{name}-brokerage-crypto: you successfully registered.");

                        list.Add(new AccountModel
                        {
                            Name = name,
                            Password = pp
                        });

                        p = false;

                        Console.Clear();
                        Crypto.ShowListing(list);
                    }
                    else
                    {
                        Console.Write($"[sudo] your password is too small.");
                    }
                }
            }
        }

        public static List<CryptoModel> AddListing()
        {
            List<CryptoModel> m = new List<CryptoModel>();
            List<string> names = new List<string>() { "LTC Litecoin", "DOGE Dogecoin", "BTC Bitcoin", "ETH Ethereum" };

            for(int i = 0; i < 4; i++)
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

        public static void AddNewListing()
        {
            List<CryptoModel> list = new List<CryptoModel>();

            list.Add(new CryptoModel
            {

            });
        }

    }
}
