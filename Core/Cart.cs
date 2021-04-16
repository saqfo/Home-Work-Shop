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
        public Dictionary<string, int> counts = new Dictionary<string, int>();
        public int CountOfProducts { get; private set; } = 0;

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
            CountOfProducts++;
            return true;
        }

        public void SetCount(string id, int count)
        {

            setcount(id, count);
        }

        private void setcount(string id, int newCount)
        {
            counts[id] = newCount;
        }
    }
}