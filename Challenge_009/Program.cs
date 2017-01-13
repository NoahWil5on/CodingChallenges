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
            Console.WriteLine(Away2(s1,s2).ToString());
        }
        
        protected static bool Away2(string s1, string s2)
        {
            if(s1.Length == s2.Length)
            {
                return OneReplace(s1, s2);
            }
            if (s1.Length - 1 == s2.Length)
            {
                return OneInsert(s1, s2);
            }
            if (s1.Length == s2.Length - 1)
            {
                return OneInsert(s2, s1);
            }
            return false;
        }
        protected static bool OneInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;

            bool diff = false;

            while(index1 < s1.Length && index2 < s2.Length)
            {
                if(s1[index1] != s2[index2])
                {
                    if (diff)
                        return false;
                    diff = true;
                    index1++;
                }
                else
                {
                    index2++;
                    index1++;
                }
            }
            return true;
        }
        protected static bool OneReplace(string s1, string s2)
        {
            bool diff = false;
            for(int i = 0; i < s1.Length; i++)
            {
                if(s1[i] != s2[i])
                {
                    if (diff)
                        return false;
                    diff = true;
                }
            }
            return true;
        }
        //Turns out that this does not work at all because I failed to consider order
        //or the fact that characters that turn themselves on and then off ruin the 
        //whole system (I'm an idiot)
        /*/// <summary>
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
        }*/
    }
}
