using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    internal class Chips : IProduct {
        public int Price { get; internal set; }
        public string Info { get; internal set; }

        public void Use() {
            Console.WriteLine($"You eat some {GetType().Name.ToLower()}, crunchy!");
        }

        public void Examine() {
            throw new NotImplementedException();
        }

        public bool Purchase(int money) {
            return money >= Price;
        }
    }
}
