using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_007
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(SpaceKiller2(s));
        }
        /// <summary>
        /// My solution
        /// Takes one string
        /// time complexity is O(n) I believe the space complexity is O(n)
        /// as well because the string the string builder is building will increase in size
        /// with size of the original string (unlike the hashtables that were subject to a finite
        /// start size that never changed)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected static string SpaceKiller(string s)
        {
            StringBuilder stringBuild = new StringBuilder();
            //splits apart the string so we have spaces to put all the %20
            string[] stringArray = s.Split(' ');

            //just loop through and stich it all back together
            for(int i = 0; i < stringArray.Length; i++)
            {
                stringBuild.Append(stringArray[i]);
                //of course we dont want %20 at the end so we skip the last iteration
                if(i != stringArray.Length - 1)
                {
                    stringBuild.Append("%20");
                }
            }
            //andddd return
            return stringBuild.ToString();
        }
        /// <summary>
        /// I feel they wanted something different done with this problem so I am 
        /// going to make a solution number 2
        /// still same space and time complexity
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected static string SpaceKiller2(string s)
        {
            char[] c = s.ToArray();
            int spaces = 0;

            //Just puts %20 whenever it finds a space
            //spaces * 2 just makes up for the space the length of %20 is taking up
            for (int i = 0; i < s.Length; i++)
            {
                //breaks early if i + spaces * 2 to avoid exceptions
                if (i + spaces * 2 >= s.Length)
                    break;
                if (s[i] == ' ')
                {
                    c[i + spaces * 2] = '%';
                    c[i + 1 + spaces * 2] = '2';
                    c[i + 2 + spaces * 2] = '0';
                    spaces++;
                }
                else
                {
                    c[i + spaces * 2] = s[i];
                }
            }
            //puts the char array back into the string
            s = new string(c);
            return s;
        }     
                
    }
}
