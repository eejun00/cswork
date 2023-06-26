using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0614
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<string, int> myInventory = new Dictionary<string, int>();
            //myInventory.Add("빨간 포션", 5);
            //myInventory.Add("골드", 500);
            //myInventory.Add("몰락한 왕의 검", 1);

            itemInfo redPotion = new itemInfo();
            itemInfo gold = new itemInfo();
            itemInfo sword = new itemInfo();
            redPotion.InitItem("빨간 포션", 5, 100);
            gold.InitItem("골드", 500, 1);
            sword.InitItem("몰락한 왕의 검", 1, 39800);

            Dictionary<string, itemInfo> myInventory2 = new Dictionary<string, itemInfo>();
            myInventory2.Add("빨간 포션", redPotion);
            myInventory2.Add("골드", gold);
            myInventory2.Add("몰락한 왕의 검", sword);


            foreach (var item in myInventory2)
            {
                Console.WriteLine("아이템 이름 : {0}, 아이템 갯수 : {1}, 아이템 가격 : {2}",
                    item.Value.itemName,item.Value.itemCount, item.Value.itemPrice);
            }

            Console.WriteLine("아이템 갯수 : {0}", myInventory2["빨간 포션"]);

        }

        public static void Desc001()
        {
            Print001 printClass = new Print001();
            //printClass.PrintMassage();

            Print001.staticMessage = "여기에 값이 들어가나?";
            Console.WriteLine(Print001.staticMessage);

            List<int> numbers = new List<int>();
            Console.WriteLine("내 리스트의 크기는 몇일까? -> {0}", numbers.Count);

            for (int i = 1; i <= 10; i++)
            {
                numbers.Add(i);
            }
            for (int i = 1; i<=10; i++)
            {
                if (i%2 ==0)
                {
                    numbers.Remove(i);
                }
            }


            foreach (int i in numbers)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("내 리스트의 크기는 몇일까? -> {0}", numbers.Count);
        }
    }
}
