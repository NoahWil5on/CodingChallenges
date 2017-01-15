using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_010
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Compressor(s));
        }
        /// <summary>
        /// Takes string s and tries to compress it
        /// will take O(n) space complexity
        /// There is a slightley more optimal solution that 
        /// checks how large the "compressed" string will be
        /// so we can check if we even need to compress it or not
        /// it also allows us to initialize string builder with a finit length
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected static string Compressor(string s)
        {
            //My approach had the program avoid any non alphabetical characters
            //thus it was a little more verbose than the books solution
            StringBuilder sBuild = new StringBuilder();
            int start = 0;
            char chaser = s[0];
            //Here we check to make sure the starting character is even a character at all
            while (!IsCharacter(chaser))
            {
                start++;
                chaser = s[start]; 
            }
            int arrow = 0;

            //Then we can just loop through the string and check to see how many
            //repeating characters we have in a row
            for(int i = start; i < s.Length; i++)
            {
                if(chaser != s[i])
                {
                    if (IsCharacter(s[i]))
                    {
                        sBuild.Append(chaser.ToString() + arrow.ToString());
                        arrow = 1;
                        chaser = s[i];
                    }
                }
                else { arrow++; }
            }
            //because of the way I set up my for loop we have to do one more check once 
            //we get out of the loop, this could have been reworded to put everything back
            //into one for loop but it is only one more check
            if (chaser != s[s.Length-1])
            {
                if (IsCharacter(s[s.Length - 1]))
                {
                    sBuild.Append(chaser.ToString() + arrow.ToString());
                }
            }
            else
            {
                sBuild.Append(chaser.ToString() + arrow.ToString());
            }
            //return the shortest of the two strings
            return sBuild.Length <= s.Length ? sBuild.ToString() : s;
        }
        /// <summary>
        /// Simply check to make sure character c is an alphabetical character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected static bool IsCharacter(char c)
        {
            int a = 'a';
            int z = 'z';
            int A = 'A';
            int Z = 'Z';

            if ((c >= a && c <= z) || (c >= A && c <= Z))
                return true;
            return false;
        }
    }
}
