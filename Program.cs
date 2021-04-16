using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_Shop.Core;
using HomeWork_Shop.Core.Tests;

namespace HomeWork_Shop
{
	delegate void CommandHanlder();
	delegate void AccountStateHandler(string message);

	class Program
	{

		AccountStateHandler _del;
		public void RegisterHandler(AccountStateHandler del)
		{
			_del = del;
		}
		static void Display(string message)
		{
			Console.WriteLine(message);
		}

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

		class Shop_Class
		{
			Shop shop;
			Cart cart;

			public Shop_Class()
			{
				shop = new Shop();
				cart = new Cart();
			}

			public Dictionary<Commands, string> GetAllCommandsNames()
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

				return CommandNames;
			}

			public Dictionary<string, CommandHanlder> GetCommandHandlers()
			{
				var dict = new Dictionary<string, CommandHanlder>();

				CommandHanlder command = Addproduct;
				dict.Add("Add Product", command);
				command = RemoveProduct;
				dict.Add("Remove Product", command);
				command = ChangeProductName;
				dict.Add("Change Product Name", command);
				command = ChangeProductPrice;
				dict.Add("Change Product Price", command);
				command = GetProductCount;
				dict.Add("Get Product Count", command);
				command = BuyProduct;
				dict.Add("Buy Product", command);
				command = GetProduct;
				dict.Add("Get Product", command);
				command = GetAllProducts;
				dict.Add("Get All Products", command);
				command = AddProductToCart;
				dict.Add("Add Product ToCart", command);
				command = GetProductsInCart;
				dict.Add("Get Products In Cart", command);

				return dict;
			}

			public void Addproduct()
			{
				Display("Name: ");
				string name = Console.ReadLine();
				Display("Description: ");
				string desc = Console.ReadLine();
				Display("Price: ");
				double price = double.Parse(Console.ReadLine());
				Display("Count: ");
				int count = int.Parse(Console.ReadLine());

				Display("id: " + shop.AddProduct(name, desc, price, count));
			}

			public void RemoveProduct()
			{
				Display("Введите ID товара,для удаления : ");
				string IdRemove = Console.ReadLine();
				try
				{
					shop.RemoveProduct(IdRemove);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			public void ChangeProductName()
			{
				Display("Введите ID товара,для изменения имени : ");
				string IdChangeProductName = Console.ReadLine();
				Display("Введите новое имя : ");
				string ChangeName = Console.ReadLine();
				shop.ChangeProductName(IdChangeProductName, ChangeName);
			}
			public void ChangeProductPrice()
			{
				Display("Введите ID товара,для изменения цены : ");
				string IdChangeProductPrice = Console.ReadLine();
				Display("Введите новую цену : ");
				double ChangePrice = double.Parse(Console.ReadLine());
				shop.ChangeProductPrice(IdChangeProductPrice, ChangePrice);
			}
			public void GetProductCount()
			{
				Display("Введите ID товара,что бы узнать количество");
				string GetProductCount = Console.ReadLine();
                Console.WriteLine(shop.GetProductCount(GetProductCount));
			}
			public void BuyProduct()
			{
				Display("Введите ID :");
				string IdBuy = Console.ReadLine();
				Display("Введите количество :");
				int countBuy = int.Parse(Console.ReadLine());
				Display("Введите сумму :");
				double moneyBuy = double.Parse(Console.ReadLine());

                Console.WriteLine(shop.BuyProduct(IdBuy, countBuy, moneyBuy));
			}

			public void GetProduct()
			{
				Display("Введите ID : ");
				string IdWerify = Console.ReadLine();

				shop.GetProduct(IdWerify);
			}

			public void GetAllProducts()
			{
				Console.WriteLine(shop.GetAllProducts());
			}

			public void AddProductToCart()
			{

				Console.WriteLine(shop.GetAllProducts());
				Display("Введите ID товара : ");
				string id = Console.ReadLine();
				Display("Введите кол-во товара: ");
				int count = Int32.Parse(Console.ReadLine());

				if (shop.counts[id] >= count)
				{
					cart.Add(shop.GetProduct(id));
					cart.SetCount(id, count);
					shop.counts[id] -= count;
				}
				else
				{
					Display("Ошибка. Недостаточно товара на складе!");
				}
			}

			public void GetProductsInCart()
			{
				string result = string.Empty;
				foreach (var item in cart.CartOfProducts)
				{
					result += $"Название: {item.Name} \t |Описание: {item.Description} \t |Цена: {item.Price} \t |Количество: {cart.counts[item.Id]} \t |ID: {item.Id} \n";
				}
				Display(result);
			}
		}

		static void Main(string[] args)
		{
			Shop_Class shop = new Shop_Class();

			var allCommandNames = shop.GetAllCommandsNames();
			var allHandlers = shop.GetCommandHandlers();

			while (true)
			{
				Display("Выбирите действие : ");

				var values = Enum.GetValues(typeof(Commands)).Cast<Commands>();

				foreach (var val in values)
				{
					Display((int)val + allCommandNames[val]);
				}

				string value = Console.ReadLine();

				Commands commands = (Commands)Enum.Parse(typeof(Commands), value);
				CommandHanlder command;
				//TODO: use command handlers instead of switch
				switch (commands)
				{


					case Commands.ADD_PRODUCT:
						command = allHandlers["Add Product"];
						command();
						//Addproduct();
						break;

					case Commands.REMOVE_PRODUCT:
						command = allHandlers["Remove Product"];
						command();
						break;

					case Commands.CHANGE_PRODUCT_NAME:
						command = allHandlers["Change Product Name"];
						command();
						break;

					case Commands.CHANGE_PRODUCT_PRICE:
						command = allHandlers["Change Product Price"];
						command();
						break;

					case Commands.GET_PRODUCT_COUNT:
						command = allHandlers["Get Product Count"];
						command();
						break;

					case Commands.BUY_PRODUCT:
						command = allHandlers["Buy Product"];
						command();
						break;

					case Commands.GET_PRODUCT:
						command = allHandlers["Get Product"];
						command();
						break;

					case Commands.GET_ALL_PRODUCTS:
						command = allHandlers["Get All Products"];
						command();
						break;

					case Commands.ADD_PRODUCT_TO_CART:
						command = allHandlers["Add Product ToCart"];
						command();
						break;
					case Commands.GET_PRODUCTS_IN_CART:
						command = allHandlers["Get Products In Cart"];
						command();
						break;

					//case Commands.TEST:
					//	PerformTest();
					//	break;
					default:
						Display("Неизвестная команда!");
						break;
				}


			}

		}

		//static void PerformTest()
		//{
		//	var shopTest = new MainTest();
		//	var shop = new Shop();
		//	var client = new Client();
		//	var testResult = shopTest.GetShopError(shop);
		//	Console.WriteLine(testResult);
		//	testResult = shopTest.GetClientError(client, shop);
		//	Console.WriteLine(testResult);
		//}



	}
}
