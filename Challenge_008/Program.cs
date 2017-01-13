using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_008
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Pal3(s).ToString());
        }
        /// <summary>
        /// Takes string s and return whether it is a palindrome
        /// Time complexity: 0(nlog(n))
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected static bool Pal(string s)
        {      
            //Trim uppertize, and sort the string so we can
            //analyze it
            //I had issues when doing this because I was 
            //too stupid to realize these three things 
            //need to be done in a very specific order 
            s = s.ToUpper();
            s = new string(s.OrderBy(c => c).ToArray());
            s = s.Trim();

            //Counts up how many times it came across a 
            //non palindrome character, once is okay because
            //the string may have an odd amount of characters
            int wrong = 0;

            for (int i = 0; i < s.Length; i += 2)
            {
                //checks for each letter if it has a pair or not
                //if it doesnt have a pair we subtract one from i
                //so we can keep iterating and checking pairs
                if (s[i] != s[i + 1])
                { 
                    wrong++;
                    i--;
                }
                //after two wrong characters we know that the string
                //isnt just odd, its not a palindrome
                if (wrong > 1)
                    return false;

                //breaks early if string is an odd length
                if (i + 2 >= s.Length)
                    break;              
            }
            return true;
        }
        //Attempt 2 after reading the books hints
        /// <summary>
        /// return s if a permuation of string s is a palindrome
        /// Time complexity O(n)
        /// space complexity O(1)
        /// Don't ask me why I decided I needed an array of characters lol
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static protected bool Pal2(string s)
        {
            s = s.ToUpper();
            char[] cs = s.ToArray();
            int[] hash = new int[128];
            int odd = 0;
            foreach(char c in cs)
            {
                if (c != ' ')
                    hash[c]++;
            }
            for(int i = 0; i < hash.Length; i++)
            {
                if (hash[i] % 2 == 1)
                    odd++;
                if (odd > 1)
                    return false;
            }

            return true;
        }
        //attempt 3 Trying to use a bit vector...
        /// <summary>
        /// I wasn't able to figure it out (mainly because I was going about it wrong)
        /// But this is how the book had it set up and for the most part I completely understand
        /// everything that is being done and most importantly I'm learning
        /// still O(n) time complexity but less space complexity
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static protected bool Pal3(string s)
        {
            //just so upper and lower case characters
            //are considered the same thing
            s = s.ToLower();

            int bitVector = 0;

            //toggles on and off bits for each character in the array
            for(int i = 0; i < s.Length; i++)
            {
                int x = GetCharNumber(s[i]);
                bitVector = Toggle(bitVector, x);
            }
            //if 1 or less bits are turned on then we know we have a palindrome
            return (bitVector == 0) || CheckOneBitSet(bitVector);
        }
        protected static int GetCharNumber(char c)
        {
            int a = 'a';
            int z = 'z';
            int val = c;
            //if it is an alphabetical character
            if(val >= a && val <= z)
            {
                return val-'a';
            }
            //if it is not an alphabetical character
            return -1;
        }
        /// <summary>
        /// toggles the bit at a specified location
        /// </summary>
        /// <param name="bitVector">A bit vector</param>
        /// <param name="index">The index to toggle at</param>
        /// <returns></returns>
        protected static int Toggle(int bitVector, int index)
        {
            //index can be less than 0 if the numerical value 
            //of char c is less not an alphabetical character
            if (index < 0)
                return bitVector;

            int mask = 1 << index;

            // if 1 of them is 0 at index(bit vector) bit vector will then 
            //toggle to one at index
            if ((bitVector & mask) == 0)
                bitVector |= mask;
            //if bitvector is already 1 at x then it will toggle by ANDing the
            //inverse of mask
            else
                bitVector &= ~mask;

            return bitVector;
        }
        /// <summary>
        /// If only one bit is turned on then when we AND it with itself minus one 
        /// We should get a value of 0 otherwise we don't have a palindrome
        /// </summary>
        /// <param name="bitVector"></param>
        /// <returns></returns>
        protected static bool CheckOneBitSet(int bitVector)
        {
            return (bitVector & bitVector - 1) == 0;
        }
    }
}
