using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_001
{
    class Program
    {
        //will 
        static bool correction;
        static Pair currentPair;

        static void Main(string[] args)
        {
            //Will be used to store user input
            string input = string.Empty;

            //loops until the user types quit
            while (true)
            {
                correction = true;
                //prompts user to type
                Console.Write("Enter a string with nested paranthese: ");
                //Get string from user
                input = Console.ReadLine();
                if (input.ToUpper() == "QUIT") { break; }

                //will loop until a there are no new corrections
                while (correction)
                {
                    correction = false;
                    input = Check(input);
                }
                //submits output
                Console.WriteLine("Corrected string: " + input);
            }
        }
        //checks for wrong paranthese
        private static string Check(string input)
        {
            //checking attributes s = start e = end
            int score;
            int s;
            int e;
            
            //loops through all the characters
            for (int i = 0; i < input.Length-1; i++)
            {
                //if the current character is an open paranthese we're starting a check
                if (input[i] == '(')
                {
                    //i will be the start of this paranthese set
                    s = i;
                    score = 1;
                    //loops through the remaining characters looking for the end of this paranthese set
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == '(') score++;
                        if (input[j] == ')') score--;
                        if(score == 0)
                        {
                            e = j;
                            if (input[s + 1] == '(' &&
                                input[e - 1] == ')')
                            {
                                input = input.Remove(e - 1,1);
                                input = input.Remove(s + 1,1);
                                correction = true;
                                return input;
                            }
                            else if(e-s == 1)
                            {
                                input = input.Remove(e,1);
                                input = input.Remove(s,1);
                                correction = true;
                                return input;
                            }
                            break;
                        }
                    }
                }
            }
            correction = false;
            return input;
        }
    }
}
