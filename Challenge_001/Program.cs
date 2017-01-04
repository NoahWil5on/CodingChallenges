using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_001
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get string from user
            string input = Console.ReadLine();

            //string paranthese attributes
            List<int> positionsOpen = new List<int>();
            List<int> positionsClose = new List<int>();

            //Records positions of each paranthese in string
            for(int i = 0; i < input.Length; i++){
                if(input[i] == '('){ positionsOpen.Add(i); }
                if(input[i] == ')'){ positionsClose.Add(i); }
            }
            //Ends program if the string is invalid
            if(positionsClose.Count != positionsOpen.Count) {
                Console.WriteLine("The entered string is invalid");
                return;
            }

            //Checks all the paranthese in the string
            for(int i = 0; i < positionsOpen.Count; i++){
                //makes sure current check will not result in an
                //index out of range exception
                if(positionsOpen[i] == 0){
                    continue;
                    //We already checked if the string was valid or not
                    //so we really should only need to check for the case
                    //of positionOpen and we don't have to worry about 
                    //positionClose
                }

                //checks to see if a set of parantheses is not essential
                if(input[positionsOpen[i-1]] == '(' &&
                    input[positionsClose[positionsClose.Count-i]] == ')'){
                    //Removes characters from input
                    input = input.Remove(positionsClose[positionsClose.Count - i]);
                    input = input.Remove(positionsOpen[i - 1],1);
                }
            }
            //submits output
            Console.WriteLine(input);
        }
    }
}
