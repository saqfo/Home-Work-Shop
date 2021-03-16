using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
	public class Shop : IShop
	{   //TODO: add balance of money and change it after buying something
		// ДЕЛАТЬ: добавить остаток денег и изменить его после покупки
		public double Money { get; set; }

		public static List<Product> products = new List<Product>();

		public Shop()
		{
			Init();	
		}
		//TODO: make like this
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
			if(price<0)            
				throw new ArgumentException();
			if (count < 0)
				throw new ArgumentException();
			Product product = new Product();
			product.Id = random.Next(1000,9999).ToString();
			product.Name = name;
			product.Price = price;
			product.Description = description;
			product.Count = count;
			products.Add(product);
			return product.Id;
				
		}
	
		//TODO: this method should find product if it doesn't exist throw error
		// ДЕЛАТЬ: этот метод должен найти продукт, если его не существует, выбросить ошибку

		public Product GetProduct(string id)
		{
		   Product product = products.FirstOrDefault(item => item.Id == id);
			 if (product?.Id == id)	
				Console.WriteLine($"Название: {product.Name}\t |Описание: {product.Description}\t |Цена: {product.Price}\t |Количество: {product.Count}\t |ID:{product.Id} \n");
			 else  throw new Exception("Такого ID не существует!");

			 return product;

			//TODO: delete it when method will be implemented
			//throw new NotImplementedException();
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
			Product product = products.FirstOrDefault(item => item.Id == id);
			return product.Count;
		}

		public double BuyProduct(string id, int count, double money)
		{
			Product product = products.FirstOrDefault(item => item.Id == id);
			if (product == null)
			{
				Console.WriteLine("Такого товара не существует!");
				return money;
			}
			
			if (product.Count < count)
				Console.WriteLine("Недостаточно товара!!!");
			else
			{
				double totalPrice = (product.Price * count);
				if (totalPrice > money)
					Console.WriteLine("Недостаточно денег");
				else
					money = money - totalPrice;
			}
			product.Count = product.Count - count;
			Console.WriteLine("Ваша сдача : ");
			return money;
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
