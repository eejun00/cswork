using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0612
{
    public class  MonsterBase
    {
        //캡슐화 -> 필드를 private로 처리해서 외부에서 접근 불가능하도록 하겠다
        // protected 는 상속받은 자식 클래스 에서는 쓸 수 있도록 하겠다는 의미
        protected string mobName;
        protected string mobType;
        protected int mobHp;
        protected int mobMp;
        protected int mobDamage; 

        public virtual void Initilize(string name,string type,int hp, int mp, int damage)
        {
            this.mobName = name;
            this.mobType = type;
            this.mobHp = hp;
            this.mobMp = mp;
            this.mobDamage = damage;
        }   //Initilize()

        public virtual void Print_MonsterInfo()
        {
            Console.WriteLine("이름 : {0}", mobName);
            Console.WriteLine("타입 : {0}", mobType);
            Console.WriteLine("체력 : {0}", mobHp);
            Console.WriteLine("마나 : {0}", mobMp);
            Console.WriteLine("데미지 : {0}", mobDamage);
        }
    }
}
