using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork_Shop.Core
{
    public class Cart : ICart
    {
        public List<Product> CartOfProducts { get; } = new List<Product>();

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (var item in CartOfProducts)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
        public bool Add(Product product)
        {
            CartOfProducts.Add(product);
            return true;
        }
    }
}