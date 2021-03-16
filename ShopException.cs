using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Shop
{
    public class ShopException : Exception
    {
        public TypeOfException Massage { get; set; }

        public ShopException(TypeOfException Massage)
        {
            this.Massage = Massage;
        }
    }

    public enum TypeOfException
    {
        PRODUCT_IS_NOT_EXIST = 1,
        NOT_ENOUGH_MONEY = 2,
    }
}
