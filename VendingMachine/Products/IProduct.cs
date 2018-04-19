using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products {
    public interface IProduct {
        int Price { get; }
        string Info { get; }
        void Use();
        bool Purchase(int money);
        void Examine();
    }
}
