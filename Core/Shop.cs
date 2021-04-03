using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_Shop.Core
{

	public class Shop : IShop
	{  
		public double Money { get; set; }

		//TODO: get rid of static field products. Should be at at the instance of the Shop class
		public List<Product> products = new List<Product>();
		public Dictionary<string, int> counts = new Dictionary<string, int>();

		public Shop()
		{
			Init();
		}
		void Init()
		{
			AddProduct("ipad ", "black", 150, 400);
			AddProduct("airpods", "white", 100, 380);
			AddProduct("iphoneX", "gold", 350, 420);
			AddProduct("ipod  ", "gray", 200, 240);
			AddProduct("notepad", "yellow", 250, 360);
			AddProduct("notebook", "green", 300, 420);
		}



		/*
	      new Product{Name = "Book",Description = "Green",Price = 2,Count = 500,Id = "0001"},
		  new Product{Name = "Pen",Description = "Blue",Price = 4,Count = 400,Id = "0002"},
	      new Product{Name = "Boozer",Description = "Red",Price = 5,Count = 200,Id = "0003"},
		  new Product{Name = "Cat",Description = "White",Price = 6,Count = 300,Id = "0004",}
		*/

		Random random = new Random();

		public string AddProduct(string name, string description, double price, int count)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException();
			if (price < 0)
				throw new ArgumentException();
			if (count < 0)
				throw new ArgumentException();
			Product product = new Product();
			var id = random.Next(1000, 9999).ToString();
			product.Id = id;
			product.Name = name;
			product.Price = price;
			product.Description = description;
			SetCount(id, count);
			products.Add(product);
			return product.Id;

		}


		public Product GetProduct(string id)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			//TODO: always use brackets {} 
			if (product?.Id == id)
				//tODO: do not use console in other level except programm 
				Console.WriteLine($"Название: {product.Name}\t |Описание: {product.Description}\t |Цена: {product.Price}\t |Количество: {product.Count}\t |ID:{product.Id} \n");
			else throw new Exception("Такого ID не существует!");

			return product;
		}


		public void RemoveProduct(string id)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			if (product == null)
				throw new ArgumentException();
			products.Remove(product);
		}

		public void ChangeProductName(string id, string name)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			product.Name = name;
		}

		public void ChangeProductPrice(string id, double price)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			product.Price = price;
		}

		public int GetProductCount(string id)
		{
			return counts[id];
		}

		//TODO: add method GetProduct and use it instead of FirstOrDefaut
		public double BuyProduct(string id, int count, double money)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			if (product == null)
			{
				//TODO: throw exceptions instead of console
				Console.WriteLine("Такого товара не существует!");
				return money;
			}

			var productCount = GetProductCount(id);

			if (productCount < count)
				Console.WriteLine("Недостаточно товара!!!");
			else
			{
				double totalPrice = (product.Price * count);
				if (totalPrice > money)
					Console.WriteLine("Недостаточно денег");
				else
					money = money - totalPrice;
			}

			var newCount = productCount - count;
			SetCount(id, newCount);

			Console.WriteLine("Ваша сдача : ");
			return money;
		}

		private void SetCount(string id, int newCount)
		{
			counts[id] = newCount;
		}

		public string GetAllProducts()
		{
			string result = "";
			foreach (var item in products)
			{
				result += $"Название: {item.Name} \t |Описание: {item.Description} \t |Цена: {item.Price} \t |Количество: {item.Count} \t |ID: {item.Id} \n";
			}
			return result;
		}

		public double GetProductPrice(string id)
		{
			foreach (var item in products)
			{
				if (item.Id == id)
					return item.Price;
			}
			return -1;
		}
	}
}
