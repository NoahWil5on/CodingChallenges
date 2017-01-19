using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_013
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            Console.WriteLine(IsRotation(s1, s2).ToString());
        }
        /// <summary>
        /// Checks if s2 is a rotation of s1
        /// by concatinating s2 with itself and 
        /// then checking if s1 is a substring of 
        /// the summed s2's
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected static bool IsRotation(string s1, string s2)
        {
            string sum = s2 + s2;
            if(IsSubstring(s1, sum))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if sub is a substring of full
        /// </summary>
        /// <param name="sub"></param>
        /// <param name="full"></param>
        /// <returns></returns>
        protected static bool IsSubstring(string sub, string full)
        {
            int start = 0;
            for(int i = 0; i < full.Length; i++)
            {
                if(!(i-start < sub.Length))
                {
                    return true;
                }
                if(sub[i-start] != full[i])
                {
                    start = i;
                }
            }
            return false;
        }
    }
}
