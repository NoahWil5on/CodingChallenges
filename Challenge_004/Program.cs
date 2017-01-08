using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_004
{
    class Program
    {
        static Stack<double> numbers;
        static string[] pushers;
        static string[] equation;
        static void Main(string[] args)
        {
            Console.WriteLine("--Type an expression in RPN with spaces between each number/operator--");
            string input = Console.ReadLine();
            pushers = input.Split(' ');
            equation = input.Split(' ');
            numbers = new Stack<double>();

            FindResult();

            if(numbers.Count > 1)
            {
                Console.WriteLine("The entered string was written with too few operators.");
            }
            else
            {
                Console.WriteLine(numbers.Pop().ToString());
            }
        }
        protected static void FindResult()
        {
            foreach (string s in pushers)
            {
                double a;
                double b;

                if (double.TryParse(s, out a))
                {
                    numbers.Push(a);
                }
                else {
                    switch (s)
                    {
                        case "+":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(a + b);
                            break;
                        case "-":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(a - b);
                            break;
                        case "*":
                        case "x":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(a * b);
                            break;
                        case "/":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(a / b);
                            break;
                        case "//":
                            int c = (int)numbers.Pop();
                            int d = (int)numbers.Pop();
                            numbers.Push(d / c);
                            break;
                        case "%":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(a % b);
                            break;
                        case "^":
                            b = numbers.Pop();
                            a = numbers.Pop();
                            numbers.Push(Math.Pow(a, b));
                            break;
                        case "!":
                            a = numbers.Pop();
                            double factorial = 1;
                            for (int i = 1; i < a + 1; i++)
                            {
                                factorial *= i;
                            }
                            numbers.Push(factorial);
                            break;
                        default:
                            Console.WriteLine("The entered string contains characters that cannot be parsed.");
                            return;
                    }
                }
            }
        }
    }
}
