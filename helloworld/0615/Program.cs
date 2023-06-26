using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0615
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            
        }

        public void Desc001()
        {
        //내가 정의한 enum 타입 변수를 선언해 볼것임
            ItemType_JY itemType;
            
            itemType = ItemType_JY.POTION;
            Console.WriteLine("enum type은 무엇이라고 출력이 될까?? -> {0}", itemType);
            
            switch (itemType)
            {
                case ItemType_JY.POTION:
                    Console.WriteLine("이 아이템의 타입은 포션입니다.");
                    break;
                case ItemType_JY.GOLD:
                    Console.WriteLine("이 아이템의 타입은 골드입니다.");
                    break;
                case ItemType_JY.WEAPON:
                    Console.WriteLine("이 아이템의 타입은 무기입니다.");
                    break;
                case ItemType_JY.ARMOR:
                    Console.WriteLine("이 아이템의 타입은 방어구입니다.");
                    break;
                default:
                    Console.WriteLine("이 아이템의 타입은 정의되지 않았습니다.");
                    break;
            }
        }

        
    }
}
