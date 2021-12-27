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
            Console.WriteLine($"       ░▀█▄░▀▀█▀█▀░░▄█▀         ");
            Console.WriteLine("          ░▀▀█▄▄▄▄▄█▀▀░░");
            Console.WriteLine("");
            Console.WriteLine("");

            if (obj.Count > 0)
            {
                Console.WriteLine("Coins available to trade");
                foreach (var list in obj)
                {
                    Console.WriteLine($"Crypto: {list.Name} - Bid: {list.Price}");
                }
            }
            else
            {
                Console.WriteLine("Crypto list is empty.. add some.");
            }
        }

        public static void Start(List<AccountModel> obj)
        {
            //List<CryptoModel> l = Setting.AddListing(); // uncomment if you want some auto listing.
            List<CryptoModel> l = new List<CryptoModel>();

            bool x = true;
            string input, code;

            ShowListing(l);

            foreach (var list in obj)
            {
                Console.Write($"\ncrypto@{list.Name}-enter-a-command: ");
            }

            while (x)
            {
                input = Console.ReadLine();

                if (input.StartsWith("buy "))
                {
                    input = input.Replace("buy ", "").Trim();
                    code = input;
                    Console.WriteLine($"Output: {code}");
                }
                else if (input == "help")
                {
                    Console.WriteLine("List of commands");
                    Console.WriteLine("BUY              Used to buy a crypto.");
                    Console.WriteLine("ADD              To add your own listing.");
                    Console.WriteLine("WALLET           To check your own wallet.");
                    Console.WriteLine("CLEAR            To clean your console.");

                    foreach (var list in obj)
                    {
                        Console.Write($"\ncrypto@{list.Name}-enter-a-command: ");
                    }
                }
                else if (input == "add")
                {
                    Setting.AddCustomListing(obj);
                }
                else if (input == "clear")
                {
                    Console.Clear();
                    ShowListing(l);

                    foreach (var list in obj)
                    {
                        Console.Write($"\ncrypto@{list.Name}-enter-crypto-name: ");
                    }
                }
                else
                {
                    foreach (var list in obj)
                    {
                        Console.Write($"crypto@{list.Name}-enter-a-command: ");
                    }
                }
            }
        }
    }
}
