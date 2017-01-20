using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_014
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            HashSet<int> set = new HashSet<int>();

            //Fills the linked list
            while(true)
            {
                int next = 0;
                if(int.TryParse(Console.ReadLine(), out next))
                {
                    list.AddLast(next);
                }
                else
                {
                    break;
                }

            }
            //The real meat of the work
            foreach(int i in list)
            {
                set.Add(i);
            }
            list.Clear();
            foreach(int i in set)
            {
                list.AddLast(i);
                Console.WriteLine(i);
            }

        }
    }
}
