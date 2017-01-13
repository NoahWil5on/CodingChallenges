using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_009
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine(Away(s1,s2).ToString());
        }
        /// <summary>
        /// Take 2 strings and check if they are one or less edit away
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected static bool Away(string s1, string s2)
        {
            //I used a bit vector because I can easily 
            //manipulate it to check how many differences
            //there are
            int bitVector = 0;

            //Turns on(in some cases turns off) all the used
            //characters in string 1
            for(int i = 0; i < s1.Length; i++)
            {
                bitVector = Toggle(bitVector, s1[i]);
            }
            //Turns off(in some cases turns on) all the used
            //characters in string 2
            for (int i = 0; i < s2.Length; i++)
            {
                bitVector = Toggle(bitVector, s2[i]);
            }
            //if the strings are the same length we are looking
            //for 2 or 0 differences
            if (s1.Length == s2.Length)
            {
                return (bitVector == 0) || IsDouble(bitVector);
            }
            //if the strings are different lengths we are looking
            //for 1 change
            else
            {
                return IsSingle(bitVector);
            }
        }
        /// <summary>
        /// Takes a bitVector and then toggles its value
        /// at index
        /// </summary>
        /// <param name="bitVector"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected static int Toggle(int bitVector, int index)
        {
            int mask = 1 << index-'a';
            //if different turn bitvector at index on
            if((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            //if same turn bitvector at index off
            else
            {
                bitVector &= ~mask;
            }
            return bitVector;
        }
        /// <summary>
        /// Check for a single change
        /// </summary>
        /// <param name="bitVector"></param>
        /// <returns></returns>
        protected static bool IsSingle(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }
        /// <summary>
        /// Check for 2 changes
        /// </summary>
        /// <param name="bitVector"></param>
        /// <returns></returns>
        protected static bool IsDouble(int bitVector)
        {
            int diff = 0;
            for(int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if((mask & bitVector) > 0)
                {
                    diff++;
                }
            }
            if(diff > 2)
            {
                return false;
            }
            return true;
        }
    }
}
