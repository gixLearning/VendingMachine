using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    public class Soda : IProduct {
        public void Consume() {
            Console.WriteLine($"You drink some {GetType().Name.ToLower()}, slurp!");
        }
    }
}
