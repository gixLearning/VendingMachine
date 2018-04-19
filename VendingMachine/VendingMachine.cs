using System;
using System.Collections.Generic;
using VendingMachine.Products;

namespace VendingMachine {
    internal class VendingMachine {
        private readonly int[] denominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private List<IProduct> aviableProducts;
        private ConsoleKeyInfo keyInfo;
        private ConsoleKey key;

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
            Console.WriteLine(options);

            do {
                keyInfo = Console.ReadKey(true);

                if (Char.IsDigit(keyInfo.KeyChar)) {
                    int choice = Int32.Parse(keyInfo.KeyChar.ToString());

                    if(choice > options || choice < 1) {
                        continue;
                    } else {
                        IProduct newProduct = null;
                        if(aviableProducts[choice - 1] is Soda) {
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
                        } else {
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

                        if(response == ConsoleKey.Y) {
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

        internal void GetChange() {
            throw new NotImplementedException();
        }

        internal void ShowAviableProducts() {
            Console.WriteLine("### Aviable Items: ###");
            int option = 1;
            foreach (IProduct item in aviableProducts) {
                Console.WriteLine($"[{option}] {item.GetType().Name.ToLower(),-10}");
                option++;
            }
        }
    }
}