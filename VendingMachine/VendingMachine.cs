using System;
using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine {

    internal class VendingMachine {
        private readonly int[] denominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private List<IProduct> aviableProducts;
        private ConsoleKey key;
        private ConsoleKeyInfo keyInfo;
        public int CurrentDepositedMoney { get; set; }

        public VendingMachine() {
            aviableProducts = new List<IProduct> {
                new Soda() { Price = 15, Info = "Sparkly soda!" },
                new Chips() { Price = 25, Info = "Crispy chips!" },
                new Candybar() { Price = 35, Info = "Awesome candy!" }

            };
        }

        internal void BuyItems(List<IProduct> purchasedProducts) {
            int options = aviableProducts.Count;
            bool exit = false;

            do {
                keyInfo = Console.ReadKey(true);

                if (Char.IsDigit(keyInfo.KeyChar)) {
                    int choice = Int32.Parse(keyInfo.KeyChar.ToString());

                    if (choice <= options && choice >= 1) {
                        IProduct newProduct = null;
                        if (aviableProducts[choice - 1] is Soda) {
                            newProduct = new Soda() { Price = aviableProducts[choice - 1].Price };
                        }
                        if (aviableProducts[choice - 1] is Chips) {
                            newProduct = new Chips() { Price = aviableProducts[choice - 1].Price };
                        }
                        if (aviableProducts[choice - 1] is Candybar) {
                            newProduct = new Candybar() { Price = aviableProducts[choice - 1].Price };
                        }

                        if (newProduct.Purchase(CurrentDepositedMoney)) {
                            purchasedProducts.Add(newProduct);
                            CurrentDepositedMoney -= newProduct.Price;
                        }
                        else {
                            Console.WriteLine("You have not deposited enough money to buy that item");
                            continue;
                        }

                        ConsoleKey response;
                        do {
                            Console.WriteLine($"You bought some {newProduct.GetType().Name}");
                            Console.Write("Do you wish to use this product now? (y/n)");
                            response = Console.ReadKey(false).Key;
                            if (response != ConsoleKey.Enter) {
                                Console.WriteLine();
                            }
                        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                        if (response == ConsoleKey.Y) {
                            newProduct.Use();
                            purchasedProducts.Remove(newProduct);
                        }
                        break;
                    }
                }

                if (keyInfo.Key != ConsoleKey.Enter) {
                    Console.WriteLine();
                }
                exit = keyInfo.Key == ConsoleKey.X;
            } while (!exit);
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

        internal void ExamineItems() {
            int options = aviableProducts.Count;
            bool exit = false;

            ShowAviableProducts();
            Console.WriteLine("Please choose an item to examine:");

            do {
                keyInfo = Console.ReadKey(true);
                if (Char.IsDigit(keyInfo.KeyChar)) {
                    int choice = Int32.Parse(keyInfo.KeyChar.ToString());
                    if (choice <= options && choice >= 1) {
                        aviableProducts[choice - 1].Examine();
                    }
                }

                exit = keyInfo.Key == ConsoleKey.X;
            } while (!exit);
            Console.ReadKey();
        }
        internal void GetChange() {
            Console.WriteLine($"Your total change: {CurrentDepositedMoney}");
            int change = CurrentDepositedMoney;

            int v1000 = 0;
            int v500 = 0;
            int v100 = 0;
            int v50 = 0;
            int v20 = 0;
            int v10 = 0;
            int v5 = 0;
            int v1 = 0;

            while (change >= 1000) {
                v1000++;
                change -= 1000;
            }
            if (v1000 != 0) {
                Console.WriteLine($"{v1000} 1000-bills");
            }

            while (change >= 500) {
                v500++;
                change -= 500;
            }
            if (v500 != 0) {
                Console.WriteLine($"{v500} 500-bills");
            }

            while (change >= 100) {
                v100++;
                change -= 100;
            }
            if (v100 != 0) {
                Console.WriteLine($"{v100} 100-bills");
            }

            while (change >= 50) {
                v50++;
                change -= 50;
            }
            if (v50 != 0) {
                Console.WriteLine($"{v50} 50-bills");
            }

            while (change >= 20) {
                v20++;
                change -= 20;
            }
            if (v20 != 0) {
                Console.WriteLine($"{v20} 20-bills");
            }

            while (change >= 10) {
                v10++;
                change -= 10;
            }
            if (v10 != 0) {
                Console.WriteLine($"{v10} in 10:- coins");
            }

            while (change >= 5) {
                v5++;
                change -= 5;
            }
            if (v5 != 0) {
                Console.WriteLine($"{v5} in 5:- coins");
            }

            while (change >= 1) {
                v1++;
                change -= 1;
            }
            if (v1 != 0) {
                Console.WriteLine($"{v1} in 1:- coins");
            }
        }

        internal void ShowAviableProducts() {
            Console.WriteLine("### Aviable Items: ###");
            int option = 1;
            foreach (IProduct item in aviableProducts) {
                Console.WriteLine($"[{option}] {item.GetType().Name,-10}");
                option++;
            }
        }
    }
}