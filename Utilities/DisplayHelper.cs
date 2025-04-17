using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Utilities
{
    public class DisplayHelper
    {
        public static bool GetYesOrNo(string question)
        {
            while (true)
            {
                Console.Write($"{question} (y/n): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "y" || input == "yes")
                    return true;
                else if (input == "n" || input == "no")
                    return false;
                else
                    Console.WriteLine("❌ Invalid input. Please enter 'y' or 'n'.");
            }
        }

    }
}
