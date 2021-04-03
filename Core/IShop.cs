using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
    public interface IShop
    {
        string AddProduct(string name, string description, double price, int count);
        void RemoveProduct(string id);
        void ChangeProductName(string id, string name);
        void ChangeProductPrice(string id, double price);
        int GetProductCount(string id);
        Product GetProduct(string id);
        double GetProductPrice(string id);
        //returns change from summ. Throw error if it's not enough money
        // возвращает изменение из суммы. Выкидывать ошибку если не хватает денег
        double BuyProduct(string id, int count, double money);
        //returns the string that represents full info of products list such as price, name, description etc
        // возвращает строку, которая представляет полную информацию о списке продуктов, такую ​​как цена, название, описание и т. д.
        string GetAllProducts();
    }
}
