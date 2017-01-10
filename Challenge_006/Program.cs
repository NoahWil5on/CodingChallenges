using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_006
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt user to get the 2 strings we will check against eachother
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            //runs funtion that checks if the strings are permutations of eachother
            if (PermutationBook(s1, s2))
            {
                Console.WriteLine("Permutations");
                return;
            }
            Console.WriteLine("Not permutations");
        }
        /// <summary>
        /// Takes two strings as inputs and then checks if the strings
        /// are permutations of eachother
        /// has run time of O(2n) arguable O(n + 1) which both are
        /// technically just O(n)
        /// </summary>
        /// <param name="s1">string 1</param>
        /// <param name="s2">string 2</param>
        /// <returns></returns>
        protected static bool Permutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            //create two hash tables to store string data
            int[] s1Array = new int[128];
            int[] s2Array = new int[128];

            //fill the hashtables with the string data
            for(int i = 0; i < s1.Length; i++)
            {
                s1Array[s1[i]]++;
                s2Array[s2[i]]++;
            }
            //if any bucket in s1Array is not equal to s2Array bucket then the two
            //strings are not permutations of eachother
            for (int i = 0; i < s1Array.Length; i++)
            {
                if(s1Array[i] != s2Array[i])
                {
                    return false;
                }
            }

            //if by now the function has not returned false then the two strings are permutations of eachother
            return true;
        }
        /// <summary>
        /// This implements one of the books hints and should have a run time of O(n*log(n))
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected static bool PermutationSort(string s1, string s2)
        {
            //if the two strings don't have the same lengths they can't
            //be permutations of eachother
            if(s1.Length != s2.Length)
            {
                return false;
            }
            //Orders both strings (takes O(n*log(n)) time
            s1 = new string(s1.OrderBy(c => c).ToArray());
            s2 = new string(s2.OrderBy(c => c).ToArray());

            //with the both strings ordered, if either strings
            //have a different character in the same spot then
            //the strings cannot be permutations of eachother
            /*for(int i = 0; i < s1.Length; i++)
            {
                if(s1[i] != s2[i])
                {
                    return false;
                }
            }*/
            
            //with an ammendment based from the book:
            return s1.Equals(s2);
        }
        /// <summary>
        /// The same as my solution with half the space complexity 
        /// because rather than using and comparing two hashtables 
        /// we just use one, however not any less of time complexity
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected static bool PermutationBook(string s1, string s2)
        {
            //two strings of different lengths cannot be
            //permutations of eachother
            if (s1.Length != s2.Length) return false;

            //create hashtable to store string data
            int[] stringArray = new int[128];

            //we count how many of each character we find
            for(int i = 0; i < s1.Length; i++)
            {
                stringArray[s1[i]]++;
            }
            //we subtract how many of each character we find
            //if we subtract too many characters we know the 
            //two strings had different amounts of at least one
            //type of character
            for(int i = 0; i < s2.Length; i++)
            {
                stringArray[s2[i]]--;
                if(stringArray[s2[i]] < 0)
                {
                    return false;
                }
            }

            //if there are no negative values, that means there are no positive values as well
            return true;
        }
    }
}
