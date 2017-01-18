using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_012
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Height: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Enter Width: ");
            int width = int.Parse(Console.ReadLine());
            string[,] matrix = new string[width, height];

            for (int i = 0; i < height; i++)
            {
                string[] s = Console.ReadLine().Split(' ');
                matrix = AddMatrix(matrix, i, s);
            }

            matrix = FindZero(matrix);

            Print(matrix);


        }
        /// <summary>
        /// Finds all positions that are "0" and then loops through them 
        /// calling ZeroMatrix()
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        protected static string[,] FindZero(string[,] matrix)
        {
            List<int> positions = new List<int>();

            //Finds every position that is "0"
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if(matrix[j,i] == "0")
                    {
                        positions.Add(j);
                        positions.Add(i);
                    }
                }
            }
            //loops through found positions and zeros their rows and columns
            if(positions.Count > 0)
            {
                for(int i = 0; i < positions.Count-1;i += 2)
                {
                    ZeroMatrix(matrix, positions[i], positions[i + 1]);
                }
            }
            return matrix;
        }
        /// <summary>
        /// Zeros rows and columns at x,y
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected static string[,] ZeroMatrix(string[,] matrix, int x, int y)
        {
            //zeros row
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, y] = "0";
            }
            //zeros column
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[x, i] = "0";
            }

            return matrix;
        }
        protected static string[,] AddMatrix(string[,] matrix, int index, string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                matrix[i, index] = s[i];
            }
            return matrix;
        }
        protected static void Print(string[,] matrix)
        {
            Console.WriteLine("");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[j, i] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
