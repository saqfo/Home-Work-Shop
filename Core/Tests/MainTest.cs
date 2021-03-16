using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork_Shop.Core.Tests
{
	//instances should be newly created
    // экземпляры должны быть созданы заново
	[TestClass]
	public class MainTest
	{
		[TestMethod]
		public string GetShopError(IShop shop)
		{

			var id = shop.AddProduct("Some shit", "Real shit", 12, 7);

			var price = shop.GetProductPrice(id);

			if (price != 12)
			{
				return "Adding or getting price";
			}

			try
			{
				//TODO: check if product isn't exists
				shop.RemoveProduct("asfafsfa");
				return "Removing product";
			}           
			catch
			{
			}			
			

			
			try
			{
				//TODO: check if name\description is empty or count\price is negatice
				shop.AddProduct("", "", -5, -11);
				return "Adding product";
			}
			catch { }



			return "Everything is great";
		}
		[TestMethod]
		public string GetClientError(IClient client, IShop shop)
		{
			client.AddMoney(500);

			if (client.Money != 500)
			{
				return "Money";
			}

			client.AddMoney(70);

			if (client.Money != 570)
			{
				return "Money";
			}

			var id = shop.AddProduct("Some", "Some", 66, 2);

			var product = shop.GetProduct(id);

			client.AddToCart(product);

			if (client.ItemsInCartCount != 1)
			{
				return "Adding to cart";
			}

			client.DropAllInCart();

			if (client.ItemsInCartCount != 0)
			{
				return "Adding to cart";
			}

			client.AddToCart(product);
			client.RemoveFromCart(id);
			if (client.ItemsInCartCount != 0)
			{
				return "Removing from cart";
			}

			client.AddToCart(product);
			var id2 = shop.AddProduct("Some1", "Some1", 4, 2);
			var product2 = shop.GetProduct(id2);
			client.AddToCart(product2);

			if (client.ItemsInCartCount != 2)
			{
				return "Adding to cart";
			}

			client.RemoveFromCart(id2);
			if (client.ItemsInCartCount != 1)
			{
				return "Removing from cart";
			}
			try
			{
				client.RemoveFromCart("asfafaf");
				return "Removing from cart";
			}
			catch { }

			if (client.TotalPriceInCart != 66)
			{
				return "Total price";
			}

			client.BuyAllInCart();

			if (client.TotalPriceInCart != 0)
			{
				return "Buy all in cart";
			}

			if (client.ItemsInCartCount != 0)
			{
				return "Buy all in cart";
			}

			if (client.Money != 504)
			{
				return "Buy all in cart";
			}


			return "Everything is greate";
		}
	}
}
