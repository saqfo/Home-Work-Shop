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
            double TotalPrice = 0;
            foreach (var item in CartOfProducts)
            {
                TotalPrice += item.Price;
            }
            return TotalPrice;
        }
        public bool Add(string id , int count)
        {
            if (Shop.products.FirstOrDefault(p => p.Id == id) == null)
            {
                throw new ShopException(TypeOfException.PRODUCT_IS_NOT_EXIST);
            }
            var productInCart = Shop.products.FirstOrDefault(p => p.Id == id);
            if (productInCart.Count < count)
            {
                throw new ShopException(TypeOfException.PRODUCT_IS_NOT_EXIST);
            }
            productInCart.Count =productInCart.Count-count;
            Product product = new Product()
            {
                Id = id,
                Name = productInCart.Name,
                Description = productInCart.Description,
                Count = count,
                Price = productInCart.Price
            };
          

            CartOfProducts.Add(product);
            return true;
        }
    }
}