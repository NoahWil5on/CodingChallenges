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
                        /*case "!":
                            a = numbers.Pop();
                            double factorial = 1;
                            for (int i = 1; i < a + 1; i++)
                            {
                                factorial *= i;
                            }
                            numbers.Push(factorial);
                            break;*/
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

            bool inPar = false;

            double outDouble = 0;

            foreach (string s in pushers)
            {
                pool.Add(s);
            }
            while(pool.Count > 0)
            {
                if(double.TryParse(pool[0],out outDouble))
                {
                    eq.Insert(eq.Count,pool[0]);
                    pool.RemoveAt(0);
                    continue;
                }               
                    
                if(double.TryParse(eq[eq.Count-1], out outDouble) && eq[eq.Count-2] != ")")
                {
                    eq.Insert(eq.Count - 2, "(");
                    eq.Insert(eq.Count - 1, pool[0]);
                    eq.Insert(eq.Count, ")");
                    pool.RemoveAt(0);
                    continue;
                }

                int openCount = 0;
                int closedCount = 0;

                int operatorIndex = 0;
                int parIndex = 0;

                for (int i = eq.Count-1; i > -1; i--)
                {
                    if(eq[i] == ")")
                    {
                        closedCount++;
                    }
                    if(eq[i] == "(")
                    {
                        openCount++;
                    }
                    if(i == 0)
                    {
                        break;
                    }
                    if(!inPar && closedCount == openCount)
                    {
                        operatorIndex = i;
                        openCount = 0;
                        closedCount = 0;
                        inPar = true;
                        if(double.TryParse(eq[i-1],out outDouble))
                        {
                            parIndex = i - 1;
                            break;
                        }
                    }
                    if(inPar && (closedCount == openCount) && openCount != 0)
                    {
                        parIndex = i;
                        break;
                    }
                }

                inPar = false;

                eq.Insert(operatorIndex, pool[0]);
                eq.Insert(parIndex, "(");
                eq.Insert(eq.Count, ")");
                pool.RemoveAt(0);
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
