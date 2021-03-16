using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
	//TODO: implement
	public class Client : IClient
	{
		public ICart Cart { get; set; } = new Cart();

		public double Money { get; set; }

		public int ItemsInCartCount
        {
            get
            {
				return Cart.CartOfProducts.Count;
            }
        }

		public double TotalPriceInCart
        {
            get
            {
				return Cart.GetTotalPrice();
            }
        }

		public void AddMoney(double summ)
		{
			this.Money += summ;
		}

		public void AddToCart(Product product)
		{
			if (product == null)
				throw new ArgumentNullException();

			Cart.Add(product.Id, product.Count);
		}

		public void BuyAllInCart()
		{
			if (Money < TotalPriceInCart)
				throw new ShopException(TypeOfException.NOT_ENOUGH_MONEY);
			Money -= TotalPriceInCart;
			DropAllInCart();
		}

		public void DropAllInCart()
		{
			Cart.CartOfProducts.Clear();
		}

		public void RemoveFromCart(string id)
		{
			var product = Cart.CartOfProducts.FirstOrDefault(item => item.Id == id);
			if (product == null)
				throw new ShopException(TypeOfException.PRODUCT_IS_NOT_EXIST);
			Cart.CartOfProducts.Remove(product);
		}
	}
}
