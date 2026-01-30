using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_DanielNilsson
{
    internal class Utilities
    {
        public static int UserInputNumberMinMax(int min, int max)
        {
            int answer;

            Console.WriteLine("Ange siffra:");
            while ((!int.TryParse(Console.ReadLine(), out answer) || answer < min || answer > max))
            {
                Console.WriteLine($"Ange en siffra mellan {min} och {max}");
            }
            return answer;
        }

        public static void ExitMenu()
        {
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        public static string UserInputString(string value)
        {
            string input;
            do
            {
                Console.Write($"Ange {value}:");
                input = Console.ReadLine();
            } while (input == null|| input==string.Empty);
            return input;
        }

    }
}
