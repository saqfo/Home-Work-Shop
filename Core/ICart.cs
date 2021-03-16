using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop.Core
{
    //TODO: interface 
    // ДЕЛАТЬ: интерфейс
    public interface ICart
    {

        List<Product> CartOfProducts { get; }

        double GetTotalPrice();

        bool Add(string id, int count);

    }
}
