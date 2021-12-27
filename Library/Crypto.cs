using System;
using System.Collections.Generic;
using System.Management;

namespace Library
{
    public static class Crypto
    {
        public static void ShowListing(List<CryptoModel> obj)
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
                Console.WriteLine("Coins available to trade");
                foreach (var list in obj)
                {
                    Console.WriteLine($"Code: {list.Id} - Crypto: {list.Name} - Bid: {list.Price}");
                }
            }
            else
            {
                Console.WriteLine("Crypto list is empty.. add some.");
            }

            Console.Write("\n");
        }

        public static void Start()
        {
            List<CryptoModel> l = new List<CryptoModel>();

            bool x = true;
            string input, code;

            ShowListing(l);

            while (x)
            {
                Console.Write("crypto@enter-a-command: ");
                input = Console.ReadLine().ToLower();

                if (input.StartsWith("buy "))
                {
                    input = input.Replace("buy ", "").Trim();
                    code = input;
                    Console.WriteLine($"Output: {code}");
                }
                else if (input == "help")
                {
                    Console.WriteLine("List of commands");
                    Console.WriteLine("BUY (code)       Used to buy a crypto.");
                    Console.WriteLine("ADD              To add your own listing.");
                    Console.WriteLine("WALLET           To check your own wallet.");
                    Console.WriteLine("CLEAR            To clean your console.\n");
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
                else
                {
                    // some action?..
                }
            }
        }
    }
}
