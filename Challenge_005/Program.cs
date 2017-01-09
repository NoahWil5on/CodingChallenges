using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_005
{
    class Program
    {
        static void Main(string[] args)
        {
            //My Solution O(n)
            /////////////////////////////////////////////////

            /*int[] hashTable = new int[1000];
            string s = Console.ReadLine();

            for(int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = -1;
            }
            foreach(char c in s)
            {
                if(hashTable[c.GetHashCode()%1000] == -1)
                {
                    hashTable[c.GetHashCode()%1000] = 1;
                }
                else
                {
                    Console.WriteLine("This is not unique");
                    return;
                }
            }
            Console.WriteLine("unique string");*/

            //Revised after reading book
            /////////////////////////////////////////////////

            /*bool[] hash = new bool[128];
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (hash[c])
                {
                    Console.WriteLine("Not Unique");
                    return;
                }
                hash[c] = true;

            }
            Console.WriteLine("unique string");*/

            //Books solution
            /////////////////////////////////////////////////

            string input = Console.ReadLine();
            int checker = 0;

            for(int i = 0; i < input.Length; i++)
            {
                int val = input[i] - 'a';
                if((checker & (1 << val)) > 0)
                {
                    Console.WriteLine("Not unique");
                    return;
                }
                checker |= (1 << val);
            }
            Console.WriteLine("Unique");

        }
    }
}
