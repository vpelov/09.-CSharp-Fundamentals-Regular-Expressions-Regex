using System;
using System.Text.RegularExpressions;

namespace P01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]{1,}) ([A-Z][a-z]{1,})\b";

            string inputData = Console.ReadLine();

            MatchCollection match = Regex.Matches(inputData, pattern);

            foreach (Match item in match)
            {
                Console.Write(item.Value + " ");
            }
        }
    }
}
