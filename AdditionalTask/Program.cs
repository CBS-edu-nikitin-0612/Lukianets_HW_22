using System;
using System.Collections;

namespace AdditionalTask
{
    internal class Program
    {
        internal class Cat
        {
            public override string ToString()
            {
                return base.GetType().Name;
            }
        }
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Add(7);
            al.Add("name");
            al.Add(new Cat());

            foreach (var item in al)
                Console.WriteLine(item);

            /* 
             * 1. Недостаток в том, что мы не можем работать с объектами в ArrayList, как с объектами конкретных классов/структур и пр. без дополнительного анализа на типю
             * Без проверки на тип можно пользоваться только тем, что даёт тип Object, т.к. ArrayList кладёт object-ы.
             * 2. Происходит boxing, если добавляем value тип => при больших колечествах списка и частом обращении к нему - влияет на быстродействие.
            */
        }
    }
}
