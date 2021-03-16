using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{

    class Cart : ICart
    {

        List<Product> Products { get; }

        double GetTotalPrice();
        {
        double TotalPrice;

          foreach (var item in Products)
        	  {
                TotalPrice += item.price;
        	  }
          return TotalPrice;
        }
void Add(Product product);
{
    Products.Add(product);
}

    }
}