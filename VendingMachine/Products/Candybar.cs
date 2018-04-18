using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    public class Candybar : IProduct {
        public void Consume() {
            Console.WriteLine($"You eat the {GetType().Name.ToLower()}, yumm!");
        }
    }
}
