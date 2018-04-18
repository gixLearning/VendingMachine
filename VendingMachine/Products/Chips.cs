using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    internal class Chips : IProduct {
        public void Consume() {
            Console.WriteLine($"You eat some {GetType().Name.ToLower()}, crunchy!");
        }
    }
}
