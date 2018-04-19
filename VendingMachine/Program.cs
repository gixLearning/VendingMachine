using System;
using System.Text;
using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine {

    internal class Program {
        private static ConsoleKey key;
        private static bool showMenu;

        private static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            DisplayVendingMachineTitle();

            VendingMachine vendingMachine = new VendingMachine();
            List<IProduct> purchasedProducts = new List<IProduct>();

            bool exitMachine = false;
            showMenu = true;

            do {
                if (showMenu) {
                    DisplayVendingOptions();
                    showMenu = false;
                }

                key = Console.ReadKey(true).Key;

                switch (key) {
                    case ConsoleKey.S: {
                        Console.Clear();
                        DisplayVendingMachineTitle();
                        vendingMachine.ShowAviableProducts();
                        showMenu = true;
                        break;
                    }
                    case ConsoleKey.B: {
                        Console.Clear();
                        DisplayVendingMachineTitle();
                        vendingMachine.ShowAviableProducts();
                        Console.WriteLine($"\nDeposited money: {vendingMachine.CurrentDepositedMoney:C0}\n");
                        Console.WriteLine("Please select what to buy: ");
                        vendingMachine.BuyItems(purchasedProducts);
                        showMenu = true;
                        break;
                    }
                    case ConsoleKey.D: {
                        vendingMachine.DepositMoney();
                        Console.Clear();
                        DisplayVendingMachineTitle();
                        showMenu = true;
                        break;
                    }
                    //case ConsoleKey.U: {
                    //    UseItem(purchasedProducts);
                    //    showMenu = true;
                    //    break;
                    //}
                    case ConsoleKey.X: {
                        exitMachine = true;
                        break;
                    }
                }
            } while (!exitMachine);

            Console.WriteLine("Exited machine");

            vendingMachine.GetChange();

            Console.Read();
        }

        //private static void UseItem(List<IProduct> products) {
        //    if(products.Count == 0) {
        //        Console.WriteLine("You haven't purchased any items yet.");
        //        Console.ReadKey();
        //    } else {
        //        Console.WriteLine("### Purchased items: ###");
        //        int option = 1;
        //        foreach (IProduct item in products) {
        //            Console.WriteLine($"[{option}] {item.GetType().Name.ToLower(),-10}");
        //            option++;
        //        }
        //    }
        //}

        private static void DisplayVendingMachineTitle() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("║ ♦ ♦ The Vending Machine ♦ ♦ ║");
            Console.WriteLine("╚═════════════════════════════╝");
            Console.ResetColor();
        }

        private static void DisplayVendingOptions() {
            Console.WriteLine("\n[S] Show items [B] Buy items [D] Deposit money [X] Exit\n");
        }
    }
}