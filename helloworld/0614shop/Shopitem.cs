using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace _0614shop
{
    public class Shopitem
    {
        public string itemName;
        public int itemPrice;

        public void InitItem(string name,int price)
        {
            itemName = name;
            itemPrice = price;
        }
    }
}
