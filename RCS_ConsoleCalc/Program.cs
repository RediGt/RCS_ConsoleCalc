using System;

namespace RCS_ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice;

            do
            {               
                Calculation();
                userChoice = UserAction();
            }
            while (userChoice != "q" && userChoice != "Q");
        }

        static void Calculation()
        {
            double first;
            double second;
            double result = 0;
            string mathSigh;
            bool outOfRangeOperation;
            bool illegalOperation = false;

            first = InputCheckOfDouble();
            mathSigh = InputCheckOfMatgSign();
            second = InputCheckOfDouble();

            switch (mathSigh)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    if (second == 0)
                    {
                        illegalOperation = true;
                        Console.WriteLine("Illegel operation. Division by 0 unallowed.");
                        break;
                    }
                    result = first / second;
                    break;
            }
            outOfRangeOperation = OutOfRangeOperation(result);

            if (outOfRangeOperation || illegalOperation)
                Console.WriteLine(first + " " + mathSigh + " " + second + " = Cannot be resolved");
            else
                Console.WriteLine(first + " " + mathSigh + " " + second + " = " + result);
        }

        static double InputCheckOfDouble()
        {
            double dbl = 0;
            bool correctInput = false;
            
            Console.Write("Input a double-type number: ");
            do
            {
                try
                {
                    dbl = Convert.ToDouble(Console.ReadLine());
                    correctInput = true;
                }                
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect input.");
                    Console.Write("Input a double-type number once more: ");
                }

                if (dbl > Double.MaxValue || dbl < Double.MinValue)
                {
                    correctInput = false;
                    Console.WriteLine("Input exceeds allowed range of double-type numbers.");
                    Console.Write("Input a double-type number once more: ");
                }
            }
            while (!correctInput);
            return dbl;
        }

        static string InputCheckOfMatgSign()
        {
            string sign;
            bool correctInput = false;

            Console.Write("Input math sign (+, -, * or /):");
            do
            {
                sign = Console.ReadLine();
                if (sign == "+" || sign == "-" || sign == "*" || sign == "/")
                    correctInput = true;
                else
                {
                    Console.WriteLine("Incorrect input.");
                    Console.Write("Input math sign (+, -, * or /) correctly: ");
                }
            }
            while (!correctInput);
            return sign;
        }

        static bool OutOfRangeOperation(double dbl)
        {
            if (dbl > Double.MaxValue || dbl < Double.MinValue)
            {
                Console.WriteLine("Result of operation exceeds allowed range of double-type numbers.");
                return true;
            }
            return false;
        }

        static string UserAction()
        {
            Console.WriteLine("\nMake your choice:" +
                    "\n'any key' - Continue" +
                    "\n'q' - Quit the program");
            return Console.ReadLine();
        }
    }
}
