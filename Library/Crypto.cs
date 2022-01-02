using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;

namespace Library
{
    public static class Crypto
    {
        public static void ShowListing(List<CryptoModelList> obj)
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"        ░░▄▄█▀▀▀▀▀█▄▄░░        ");
            Console.WriteLine($"       ░▄█▀░░▄░▄░░░░▀█▄        ");
            Console.WriteLine($"       ░█░░░▀█▀▀▀▀▄░░░█         Welcome to your Crypto Wallet");
            Console.WriteLine($"        █░░░░█▄▄▄▄▀░░░█         Date: {DateTime.Now}");
            Console.WriteLine($"       ░█░░░░█░░░░█░░░█         ");
            Console.WriteLine($"       ░▀█▄░▀▀█▀█▀░░▄█▀          Commands");
            Console.WriteLine("          ░▀▀█▄▄▄▄▄█▀▀░░             ''help'' - to view a list of available commands.");
            Console.WriteLine("");
            Console.WriteLine("");

            if (obj.Count > 0)
            {
                Console.WriteLine($"Code    Coin            ");
                foreach (var list in obj)
                {
                    if(list.Variation > 0)
                    {
                        Console.WriteLine($"{list.Id}     {list.Name}    last bid: {list.Price} - +{list.Variation}%");
                    }
                    else
                    {
                        Console.WriteLine($"{list.Id}     {list.Name}    last bid: {list.Price} - {list.Variation}%");
                    }
                }

                Console.WriteLine("\n*Prices in US $");
            }
            else
            {
                Console.WriteLine("Crypto list is empty.. add some.");
            }

            Console.Write("\n");
        }

        public static void Start()
        {
            //List<CryptoModelList> l = new List<CryptoModelList>();
            List<CryptoModelList> l = Setting.AddListing();
            //List<WalletModelList> wallet = Setting.CryptoAddress();

            bool x = true;
            string input, confirm;
            int code;

            ShowListing(l);

            while (x)
            {
                Console.Write("crypto@enter-a-command: ");
                input = Console.ReadLine().ToLower();

                if (input.StartsWith("buy "))
                {
                    string quantity;
                    int qnty;
                    double result, price;

                    input = input.Replace("buy ", "").Trim();
                    code = int.Parse(input);

                    foreach (var list in l)
                    {
                        if (list.Id == code)
                        {
                            Console.Write($"bid@quantity-of '{list.Name}': ");
                            quantity = Console.ReadLine();
                            qnty = int.Parse(quantity);

                            result = qnty * list.Price;
                            
                            if(qnty >= 5 && list.Price >= 50)
                            {
                                Console.Write($"bid@you-are-about to buy {qnty} coins of '{list.Name}' for about {result}, confirm? yes/no: ");
                                confirm = Console.ReadLine().ToLower();

                                if (confirm == "yes")
                                {
                                    price = list.Price;
                                    list.Price = list.Price * 5;

                                    Setting.CalculateVariation(list, price, list.Price);

                                    Console.Clear();
                                    ShowListing(l);

                                    Console.WriteLine($"crypto@you-bought '{list.Name}' ({qnty} coins), check your margin profit in your crypto wallet");
                                }
                            }
                        }
                    }
                }
                else if(input == "buy")
                {
                    Console.WriteLine("crypto@correct-usage: buy (code)");
                }
                else if(input == "wallet")
                {

                }
                else if (input == "help") 
                {
                    Console.WriteLine("List of commands");
                    Console.WriteLine("BUY (code)       Used to buy a crypto.");
                    Console.WriteLine("ADD              To add your own listing.");
                    Console.WriteLine("WALLET           To check your own wallet.");
                    Console.WriteLine("CLEAR            To clean your console.");
                    Console.WriteLine("QUIT             To quit from the game.\n");
                }
                else if (input == "add")
                {
                    Setting.AddCustomListing(l);
                }
                else if (input == "clear")
                {
                    Console.Clear();
                    ShowListing(l);

                }
                else if(input == "q" || input == "quit")
                {
                    return;
                }
            }
        }
    }
}
