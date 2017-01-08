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
        static string finalEQ;

        static void Main(string[] args)
        {
            Console.WriteLine("--Type an expression in RPN with spaces between each number/operator--");
            string input = Console.ReadLine();
            pushers = input.Split(' ');
            numbers = new Stack<double>();
            finalEQ = "";

            FindResult();

            if(numbers.Count > 1)
            {
                Console.WriteLine("The entered string was written with too few operators.");
            }
            else
            {
                Console.Write(FindEquation() + "=");
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
        protected static string FindEquation()
        {
            List<string> pool = new List<string>();
            List<string> eq = new List<string>();

            bool onInt = true;
            bool inPar = false;
            bool found = false;

            int parCount = 0;
            int current = 0;

            foreach(string s in pushers)
            {
                pool.Add(s);
            }
            while(pool.Count > 0)
            {
                if (onInt)
                {
                    if (inPar)
                    {
                        eq.Add("(");
                        parCount++;
                    }
                    eq.Add(pool[0]);
                    if(!inPar)
                    {
                        while (parCount > 0)
                        {
                            eq.Add(")"); parCount--;
                        }
                    }
                    onInt = false;
                    pool.RemoveAt(0);
                    continue;
                }
                inPar = false;
                onInt = true;
                string outString;
                double outDouble = 0;
                for(int i = 0; i < pool.Count; i++)
                {
                    if (!double.TryParse(pool[i], out outDouble))
                    {
                        if (i + 1 != pool.Count)
                        {
                            if (!double.TryParse(pool[i + 1], out outDouble))
                            {
                                inPar = true;
                            }
                        }
                        else {
                            found = true;
                            outString = pool[i];
                            break;
                        }                 
                    }
                    current = i+1;
                }
                if (found)
                {
                    eq.Add(pool[current]);
                    pool.RemoveAt(current);
                }
                found = false;
            }

            StringBuilder(eq);

            return finalEQ;
        }
        protected static void StringBuilder(List<string> ls)
        {
            if(ls.Count > 0)
            {
                finalEQ += ls[0];
                ls.RemoveAt(0);
                StringBuilder(ls);
            }
        }
    }
}
