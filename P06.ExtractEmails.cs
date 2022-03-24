using System;
using System.Text.RegularExpressions;

namespace P06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            string pattern = @"(?<=\s)([a-z]+|\d+)(\d+|\w+|\.+|\-+)([a-z]+|\d+)\@[a-z]+\-?[a-z]+\.[a-z]+(\.[a-z]+)?";

            MatchCollection match = Regex.Matches(inputData, pattern);

            foreach (Match m in match)
            {
                Console.WriteLine(m.Value);
            
            }


        }
    }
}
