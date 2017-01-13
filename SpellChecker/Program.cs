using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("words.txt");
            List<string> corrects = new List<string>();
            string s = Console.ReadLine();
            s = s.ToLower();
            string read;
            while((read = reader.ReadLine()) != null)
            {
                read = read.ToLower();
                if (Away(s, read))
                    corrects.Add(read);
            }
            if(corrects.Count > 0)
            {

                foreach(string correct in corrects)
                {
                    if (s == correct)
                        return;
                }
                Console.WriteLine(s + " is not a word perhaps you meant:");
                foreach (string correct in corrects)
                {
                    Console.WriteLine(correct);
                }
            }
            else
            {
                Console.WriteLine("No Suggestions");
            }
        }
        /// <summary>
        /// checks if the 2 strings s1 and s2 are one or less edits away
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected static bool Away(string s1, string s2)
        {
            if (s1.Length == s2.Length)
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

            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
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
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (diff)
                        return false;
                    diff = true;
                }
            }
            return true;
        }
    }
}
