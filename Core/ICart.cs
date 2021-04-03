using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
    public interface ICart
    {

        List<Product> CartOfProducts { get; }

        double GetTotalPrice();

        bool Add(Product product);

        int CountOfProducts { get; }

    }
}
