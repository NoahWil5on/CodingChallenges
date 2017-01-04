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

                input = Invalid(input);
                //submits output if the string isn't considered invalid or empty
                if (input != "INVALID INPUT")
                {
                    //will loop until a there are no new corrections
                    while (correction)
                    {
                        correction = false;
                        input = Check(input);
                    }
                    //in the case of an empty string
                    if (input == string.Empty)
                        Console.WriteLine("EMPTY STRING");
                    //beautiful finished work
                    else {
                        Console.WriteLine("Corrected string: " + input);
                    }
                }
                //in the case of an invalid string
                else
                {
                    Console.WriteLine(input);
                }
            }
        }
        //Checks for invalid inputs
        private static string Invalid(string input)
        {
            //checking attributes s = start e = end
            int score;

            //checks a couple invalid cases that would cause errors later down the road
            if (input.Length == 1 && (input[0] == ')' || input[0] == '(')) return "INVALID INPUT";
            if(input[0] == ')') return "INVALID INPUT";
            if(input[input.Length-1] == '(') return "INVALID INPUT";

            //loops through all the characters forward to check for invalids
            for (int i = 0; i < input.Length - 1; i++)
            {
                //if the current character is an open paranthese we're starting a check
                if (input[i] == '(')
                {
                    score = 0;
                    //loops through the remaining characters looking for the end of this paranthese set
                    for (int j = i; j < input.Length; j++)
                    {
                        //simple formula to find where paranthese are nested
                        if (input[j] == '(') score++;
                        if (input[j] == ')') score--;
                        //if the score == 0 then the loop has been closed which is good
                        if(score == 0)
                        {
                            break;
                        }
                        //if we get to the end and the loop hasn't been closed the input is invalid
                        if (score != 0 && j == input.Length-1)
                        {
                            return "INVALID INPUT";
                        }
                    }
                }
            }
            //Works the same as the last loop but this one is checking the other direction
            for (int i = input.Length-1; i > 0; i--)
            {
                //if the current character is an open paranthese we're starting a check
                if (input[i] == ')')
                {
                    score = 0;
                    //loops through the remaining characters looking for the end of this paranthese set
                    for (int j = i; j > -1; j--)
                    {
                        //same formula as before but reversed
                        if (input[j] == '(') score--;
                        if (input[j] == ')') score++;
                        //if the score == 0 then the loop has been closed which is good
                        if (score == 0)
                        {
                            break;
                        }
                        //if we get to the end and the loop hasn't been closed the input is invalid
                        if (score != 0 && j == 0)
                        {
                            return "INVALID INPUT";
                        }
                    }
                }
            }
            //if there are no issues the string will be returned as it was
            return input;
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
                        //formula to find where paranthese are nested
                        if (input[j] == '(') score++;
                        if (input[j] == ')') score--;
                        //when score == 0 the paranthese end has been found
                        if(score == 0)
                        {
                            e = j;
                            //check to see if there are non essential paranthese
                            if (input[s + 1] == '(' &&
                                input[e - 1] == ')')
                            {
                                //removes those non essential paranthese
                                //and states that a correction has been made
                                input = input.Remove(e - 1,1);
                                input = input.Remove(s + 1,1);
                                correction = true;
                                return input;
                            }
                            //checks for the case of empty paranthese in which case we 
                            //just remove the pair
                            else if(e-s == 1)
                            {
                                input = input.Remove(e,1);
                                input = input.Remove(s,1);
                                correction = true;
                                return input;
                            }
                            //because the length of the string is changing only one check is being done at a time
                            break;
                        }                    
                    }
                }
            }
            //If there are no more corrections to be made the string will be 
            //returned as it was and corrections will be set to false
            //indicated the end of the loop
            correction = false;
            return input;
        }
    }
}
