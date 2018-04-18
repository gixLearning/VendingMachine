using System;
using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine {
    internal class VendingMachine {
        private readonly int[] denominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private Dictionary<IProduct, int> aviableProducts;
        private ConsoleKey key;

        public int CurrentDepositedMoney { get; set; }

        public VendingMachine() {
            aviableProducts = new Dictionary<IProduct, int> {
                { new Soda(), 25 },
                { new Chips(), 30 },
                { new Candybar(), 20 }
            };
        }

        internal void BuyItems() {
            do {
                key = Console.ReadKey(true).Key;
                if (key != ConsoleKey.Enter) {
                    Console.WriteLine();
                }
            } while (key != ConsoleKey.X);
        }

        internal void DepositMoney() {
            int option = 1;
            Console.WriteLine("Please choose an amount to despoit:");
            Console.WriteLine("Press [X] to exit depositing money");
            foreach (int item in denominations) {
                Console.Write($"[{option}] {item:C0} ");
                option++;
            }
            Console.WriteLine();

            do {
                key = Console.ReadKey(true).Key;

                switch (key) {
                    case ConsoleKey.D1: {
                        CurrentDepositedMoney += 1;
                        Console.WriteLine($"Deposited {denominations[0]:C0}");
                        break;
                    }

                    case ConsoleKey.D2: {
                        CurrentDepositedMoney += 5;
                        Console.WriteLine($"Deposited {denominations[1]:C0}");
                        break;
                    }

                    case ConsoleKey.D3: {
                        CurrentDepositedMoney += 10;
                        Console.WriteLine($"Deposited {denominations[2]:C0}");
                        break;
                    }

                    case ConsoleKey.D4: {
                        CurrentDepositedMoney += 20;
                        Console.WriteLine($"Deposited {denominations[3]:C0}");
                        break;
                    }

                    case ConsoleKey.D5: {
                        CurrentDepositedMoney += 50;
                        Console.WriteLine($"Deposited {denominations[4]:C0}");
                        break;
                    }

                    case ConsoleKey.D6: {
                        CurrentDepositedMoney += 100;
                        Console.WriteLine($"Deposited {denominations[5]:C0}");
                        break;
                    }

                    case ConsoleKey.D7: {
                        CurrentDepositedMoney += 500;
                        Console.WriteLine($"Deposited {denominations[6]:C0}");
                        break;
                    }

                    case ConsoleKey.D8: {
                        CurrentDepositedMoney += 1000;
                        Console.WriteLine($"Deposited {denominations[7]:C0}");
                        break;
                    }
                }
            } while (key != ConsoleKey.X);
        }

        internal void ShowAviableProducts() {
            Console.WriteLine("### Aviable Items: ###");
            int option = 1;
            foreach (KeyValuePair<IProduct, int> item in aviableProducts) {
                Console.WriteLine($"[{option}] {item.Key.GetType().Name,-10} Price: {item.Value:C0}");
                option++;
            }
        }
    }
}