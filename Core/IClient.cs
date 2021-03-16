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
		//TODO: this field shows how much money customer has
		// ДЕЛАТЬ: это поле показывает, сколько денег у клиента
		double Money { get; }
		int ItemsInCartCount { get; }
		double TotalPriceInCart { get; }
		void AddMoney(double summ);
		void AddToCart(Product product);
		//TODO: after this action money of the client should be checked and if everything is ok be reduced or throw Exception
		// ДЕЛАТЬ: после этого действия нужно проверить деньги клиента и, если все в порядке, уменьшить или выбросить Exception

		void RemoveFromCart(string id);

		void BuyAllInCart();
		//TODO: after this action cart should be refreshed
		// ДЕЛАТЬ: после этого действия необходимо обновить корзину
		void DropAllInCart();
	}
}
