using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
	public interface IClient
	{
		ICart Cart { get; }
		double Money { get; }
		int ItemsInCartCount { get; }
		double TotalPriceInCart { get; }
		void AddMoney(double summ);
		void AddToCart(Product product, int count);
		void RemoveFromCart(string id);

		void BuyAllInCart();
		void DropAllInCart();
	}
}
