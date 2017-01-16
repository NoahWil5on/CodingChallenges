using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_011
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[,] matrix = new string[length, length];

            for(int i = 0; i < length; i++)
            {
                string[] s = Console.ReadLine().Split(' ');
                matrix = AddMatrix(matrix, i, s);
            }

            matrix = Rotate90(matrix);

            Print(matrix);


        }
        /// <summary>
        /// Rotates matrix 90 degrees in O(n^2) time where
        /// n is the length of a given column and O(n^2) space 
        /// complexity (which is pretty bad)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        protected static string[,] Rotate90(string[,] matrix)
        {
            int length = matrix.GetLength(0);
            string[,] temp = new string[length, length];
            Array.Copy(matrix,temp,length*length);
            

            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    matrix[x, y] = temp[y,length-1-x];
                    //For -90 degrees:
                    //matrix[x,y] = temp[length - 1 - y, x];
                }
            }

            return matrix;
        }
        protected static string[,] AddMatrix(string[,] matrix, int index, string[] s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                matrix[i, index] = s[i];
            }
            return matrix;
        }
        protected static void Print(string[,] matrix)
        {
            Console.WriteLine("");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[j,i] + " ");
                }
                Console.WriteLine("");
            }
        }
       
    }
}
