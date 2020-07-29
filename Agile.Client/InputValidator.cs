using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Client
{
    public class InputValidator
    {
        public static string InputStringValue(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int InputIntegerValue(string message)
        {
            int value;
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                else
                    Console.WriteLine("Wrong input value");
            }
            while (true);
        }
    }
}
