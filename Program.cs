using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_Shop.Core;
using HomeWork_Shop.Core.Tests;

namespace HomeWork_Shop
{
	class Program
	{
		static Shop shop = new Shop();
		static Cart cart = new Cart();

		//TODO: create dictionary with commands and theirs description
		//TODO: (not now) use fabric method(?) to use commands

		enum Commands
		{
			ADD_PRODUCT = 1,
			REMOVE_PRODUCT = 2,
			CHANGE_PRODUCT_NAME = 3,
			CHANGE_PRODUCT_PRICE = 4,
			GET_PRODUCT_COUNT = 5,
			BUY_PRODUCT = 6,
			GET_PRODUCT = 7,
			GET_ALL_PRODUCTS = 8,
			ADD_PRODUCT_TO_CART,
			GET_PRODUCTS_IN_CART,
			TEST
		}
		

		static void Main(string[] args)
		{
			Dictionary<Commands, string> CommandNames = new Dictionary<Commands, string>();
            
				CommandNames.Add(Commands.ADD_PRODUCT, ". Добавить продукт");
				CommandNames.Add(Commands.REMOVE_PRODUCT, ". Удалить продукт");
				CommandNames.Add(Commands.CHANGE_PRODUCT_NAME, ". Изменить имя продукта");
				CommandNames.Add(Commands.CHANGE_PRODUCT_PRICE, ". Изменить цену продукта");
				CommandNames.Add(Commands.GET_PRODUCT_COUNT, ". Показать остаток продуктов");
				CommandNames.Add(Commands.BUY_PRODUCT, ". Купить продукт");
			    CommandNames.Add(Commands.GET_PRODUCT, ". Найти продукт");
				CommandNames.Add(Commands.GET_ALL_PRODUCTS, ". Список всех продуктов");
				CommandNames.Add(Commands.ADD_PRODUCT_TO_CART, ". Добавить продукт в корзину");
				CommandNames.Add(Commands.GET_PRODUCTS_IN_CART, ". Список всех продуктов в корзине");
				CommandNames.Add(Commands.TEST, ". Tests");


			while (true)
			{
				Console.WriteLine("Выбирите действие : ");
				Console.WriteLine((int)Commands.ADD_PRODUCT + CommandNames[Commands.ADD_PRODUCT]);
				Console.WriteLine((int)Commands.REMOVE_PRODUCT + CommandNames[Commands.REMOVE_PRODUCT]);
				Console.WriteLine((int)Commands.CHANGE_PRODUCT_NAME + CommandNames[Commands.CHANGE_PRODUCT_NAME]);
				Console.WriteLine((int)Commands.CHANGE_PRODUCT_PRICE + CommandNames[Commands.CHANGE_PRODUCT_PRICE]);
				Console.WriteLine((int)Commands.GET_PRODUCT_COUNT + CommandNames[Commands.GET_PRODUCT_COUNT]);
				Console.WriteLine((int)Commands.BUY_PRODUCT + CommandNames[Commands.BUY_PRODUCT]);
				Console.WriteLine((int)Commands.GET_PRODUCT + CommandNames[Commands.GET_PRODUCT]);
				Console.WriteLine((int)Commands.GET_ALL_PRODUCTS + CommandNames[Commands.GET_ALL_PRODUCTS]);
				Console.WriteLine((int)Commands.ADD_PRODUCT_TO_CART + CommandNames[Commands.ADD_PRODUCT_TO_CART]);
				Console.WriteLine((int)Commands.GET_PRODUCTS_IN_CART + CommandNames[Commands.GET_PRODUCTS_IN_CART]);
				Console.WriteLine((int)Commands.TEST + CommandNames[Commands.TEST]);



				string value = Console.ReadLine();

				Commands commands = (Commands)Enum.Parse(typeof(Commands), value);


				switch (commands)
				{

					case Commands.ADD_PRODUCT:
						Addproduct();
						break;

					case Commands.REMOVE_PRODUCT:
						RemoveProduct();
						break;

					case Commands.CHANGE_PRODUCT_NAME:
						ChangeProductName();
						break;

					case Commands.CHANGE_PRODUCT_PRICE:
						ChangeProductPrice();
						break;

					case Commands.GET_PRODUCT_COUNT:
						GetProductCount();
						break;

					case Commands.BUY_PRODUCT:
						BuyProduct();
						break;

					case Commands.GET_PRODUCT:
						GetProduct();
						break;

					case Commands.GET_ALL_PRODUCTS:
						GetAllProducts();
						break;

					case Commands.ADD_PRODUCT_TO_CART:
						AddProductToCart();
						break;
					case Commands.GET_PRODUCTS_IN_CART:
						GetProductsInCart();
						break;

					case Commands.TEST:
						PerformTest();
						break;
				}


			}

		}



		static void PerformTest()
		{
			var shopTest = new MainTest();
			var shop = new Shop();
			var client = new Client();
			var testResult = shopTest.GetShopError(shop);
			Console.WriteLine(testResult);
			testResult = shopTest.GetClientError(client, shop);
			Console.WriteLine(testResult);
		}

		//TODO: divide each action to separated method
		// ДЕЛАТЬ: разделить каждое действие на отдельный метод

		static void Addproduct()
		{
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("Description: ");
			string desc = Console.ReadLine();
			Console.Write("Price: ");
			double price = double.Parse(Console.ReadLine());
			Console.Write("Count: ");
			int count = int.Parse(Console.ReadLine());

			Console.WriteLine("id: " + shop.AddProduct(name, desc, price, count));
		}

		static void RemoveProduct()
		{
			Console.WriteLine("Введите ID товара,для удаления : ");
			string IdRemove = Console.ReadLine();
			shop.RemoveProduct(IdRemove);
		}
		static void ChangeProductName()
		{
			Console.WriteLine("Введите ID товара,для изменения имени : ");
			string IdChangeProductName = Console.ReadLine();
			Console.WriteLine("Введите новое имя : ");
			string ChangeName = Console.ReadLine();
			shop.ChangeProductName(IdChangeProductName, ChangeName);
		}
		static void ChangeProductPrice()
		{
			Console.WriteLine("Введите ID товара,для изменения цены : ");
			string IdChangeProductPrice = Console.ReadLine();
			Console.WriteLine("Введите новую цену : ");
			double ChangePrice = double.Parse(Console.ReadLine());
			shop.ChangeProductPrice(IdChangeProductPrice, ChangePrice);
		}
		static void GetProductCount()
		{
			Console.WriteLine("Введите ID товара,что бы узнать количество");
			string GetProductCount = Console.ReadLine();
			Console.WriteLine(shop.GetProductCount(GetProductCount));
		}
		static void BuyProduct()
		{
			Console.WriteLine("Введите ID :");
			string IdBuy = Console.ReadLine();
			Console.WriteLine("Введите количество :");
			int countBuy = int.Parse(Console.ReadLine());
			Console.WriteLine("Введите сумму :");
			double moneyBuy = double.Parse(Console.ReadLine());

			Console.WriteLine(shop.BuyProduct(IdBuy, countBuy, moneyBuy));
		}

		static void GetProduct()
		{
			Console.Write("Введите ID : ");
			string IdWerify = Console.ReadLine();

			shop.GetProduct(IdWerify);
		}

		static void GetAllProducts()
		{
			Console.WriteLine(shop.GetAllProducts());
		}

		static void AddProductToCart()
        {			
			Console.WriteLine("Введите ID товара : ");
			string id = Console.ReadLine();
			Console.WriteLine("Введите кол-во товара: ");
			int count =Int32.Parse(Console.ReadLine());
			cart.Add(id, count);
		}

		static void GetProductsInCart()
        {
			string result = string.Empty;
			foreach (var item in cart.CartOfProducts)
			{
				result += $"Название: {item.Name} \t |Описание: {item.Description} \t |Цена: {item.Price} \t |Количество: {item.Count} \t |ID: {item.Id} \n";
			}
            Console.WriteLine(result);
		}

		 
	}
}
