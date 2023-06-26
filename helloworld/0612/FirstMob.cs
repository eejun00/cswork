using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0612
{
    public class FirstMob : MonsterBase
    {
        public override void Initilize(string name, string type, int hp, int mp, int damage)
        {
            base.Initilize(name, type, hp, mp, damage);
        }

        public override void Print_MonsterInfo()
        {
            base.Print_MonsterInfo();
        }

        public void Print_OverloadingTest()
        {
            Console.WriteLine("함수 찍힌다");
        }

        public void Print_OverloadingTest(out int number)
        {
            Console.WriteLine("함수 찍힌다");
            number = 10;
        }
        //string mobName = "로이";
        //string mobType = "야수형";
        //int mobHp = 30;
        //int mobMp = 30;
        //int mobDamage = 5;

        //public virtual void PrintFirstMob()
        //{
        //    Console.WriteLine("저 몬스터의 이름은 {0}..!\n타입은 {1}으로 추정되는군..\n체력과 마나는 각각 {2}, {3},\n공격력은 {4} 정도 되보인다.",
        //        mobName, mobType, mobHp, mobMp, mobDamage);
        //    Console.WriteLine();
        //}
    }
    public class SecondMob
    {
        string mobName = "레이";
        string mobType = "야수형";
        int mobHp = 50;
        int mobMp = 20;
        int mobDamage = 3;

        public void PrintSecondMob()
        {
            Console.WriteLine("저 몬스터의 이름은 {0}..!\n타입은 {1}으로 추정되는군..\n체력과 마나는 각각 {2}, {3},\n공격력은 {4} 정도 되보인다.",
                mobName, mobType, mobHp, mobMp, mobDamage);
            Console.WriteLine();

        }
    }

    public class ThirdMob
    {
        string mobName = "에이전트H";
        string mobType = "인간형";
        int mobHp = 100;
        int mobMp = 50;
        int mobDamage = 10;

        public void PrintThirdMob()
        {
            Console.WriteLine("저 몬스터의 이름은 {0}..!\n타입은 {1}으로 추정되는군..\n체력과 마나는 각각 {2}, {3},\n공격력은 {4} 정도 되보인다.",
                mobName, mobType, mobHp, mobMp, mobDamage);
            Console.WriteLine();

        }
    }
}
