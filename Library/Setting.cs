using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Setting
    {
        public static void ShowListing(List<AccountModel> obj)
        {
            List<CryptoModel> m = AddListing();

            Console.WriteLine($"");
            Console.WriteLine($"                                 Welcome to the crypto market - Local Time: {DateTime.Now}\n");
            Console.WriteLine($" ______________________________                     ");
            Console.WriteLine($"| Crypto              Price    |                    ");
            Console.WriteLine($"|------------------------------|          ");

            if (m.Count > 0)
            {
                foreach (var list in m)
                {
                    Console.WriteLine($"  {list.Name}");
                    Console.WriteLine($"                      {list.Price}.00");
                }
            }
            else
            {
                Console.WriteLine("        Crypto list is empty.. add some.");
            }

            Console.WriteLine($"|______________________________|");
            Console.WriteLine($"\n\nUseful commands:\n1 - buy (name) - and HODL if you want to afford a lambo!\n2 - add - if you want to scam people by adding your own coin!\n");

            foreach (var list in obj)
            {
                Console.Write($"root@{list.Name}-welcome-to-crypto: ");
            }

            bool x = true;
            string input, code, name, confirm, price;
            double p;

            while (x)
            {
                input = Console.ReadLine();

                if (input.StartsWith("buy "))
                {
                    input = input.Replace("buy ", "").Trim();
                    code = input;
                    Console.WriteLine($"Output: {code}");
                }
                else if (input == "add")
                {
                    Console.Clear();
                    Console.WriteLine("You are adding a new listing.\n");

                    foreach (var list in obj)
                    {
                        Console.Write($"root@{list.Name}-welcome-to-crypto: enter your name: ");
                    }

                    name = Console.ReadLine();

                    if (name.Length > 4)
                    {
                        Console.Write($"Enter your first bid to {name}: ");

                        price = Console.ReadLine();
                        p = Double.Parse(price);

                        Console.Write($"\nThis is your listing:\nCrypto: {name}\nFirst Bid: {p}\n\nConfirm? Yes/No: ");

                        confirm = Console.ReadLine().ToLower();

                        if (confirm == "yes")
                        {
                            AddNewListing();
                        }
                        else
                        {
                            Console.Clear();
                            //ShowListing();
                        }
                    }
                }
                else if (input == "quit")
                {
                    Console.Clear();
                    //Start();
                }
            }
        }

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
                        ShowListing(list);
                    }
                    else
                    {
                        Console.Write($"[sudo] your password is too small.");
                    }
                }
            }
        }

        static List<CryptoModel> AddListing()
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
