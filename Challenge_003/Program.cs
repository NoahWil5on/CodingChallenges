using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_003
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            Console.Write("Turn: ");
            string before = Console.ReadLine();

            //output
            Console.Write("Into: ");
            string after = Console.ReadLine();

            //will be used to insure the same string is never printed twice in a row
            string temp = before;
            
            //returns if the lengths aren't of equal value in order to prevent errors
            if(before.Length != after.Length) { Console.WriteLine("Strings must be of equal length"); return; }

            Console.WriteLine(before);
    
            for (int i = 0; i < after.Length; i++)
            {
                //moves one character up each iteration to change to new string
                before = after.Substring(0, i + 1) + before.Substring(i + 1, before.Length - i - 1);

                //makes sure it's a new string and not just like the last time through
                if(temp != before)
                    Console.WriteLine(before);

                temp = before;
            }
        }
    }
}
