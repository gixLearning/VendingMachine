using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    public class Candybar : IProduct {
        public int Price { get; internal set; }
        public string Info { get; internal set; }

        public void Use() {
            Console.WriteLine($"You eat the {GetType().Name.ToLower()}, yumm!");
        }

        public void Examine() {
            Console.WriteLine($"{GetType().Name}: {Info} Price of item: {Price}");
        }

        public bool Purchase(int money) {
            return money >= Price;
        }
    }
}
