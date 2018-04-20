using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    public class Soda : IProduct {
        public int Price { get; internal set; }
        public string Info { get; internal set; }

        public void Use() {
            Console.WriteLine($"You drink some {GetType().Name.ToLower()}, slurp!");
        }

        public void Examine() {
            Console.WriteLine($"{GetType().Name}: {Info} Price of item: {Price}");
        }

        public bool Purchase(int money) {
            return money >= Price;
        }
    }
}
