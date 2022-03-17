using System;
using System.Text.RegularExpressions;

namespace P03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[0-9]{2})(?<separator>\.|-|/)(?<month>[A-Z]{1}[a-z]{2})\k<separator>(?<year>[0-9]{4})\b";

            string inputData = Console.ReadLine();

            MatchCollection dataMatch = Regex.Matches(inputData, pattern);

            foreach (Match item in dataMatch)
            {
                Console.WriteLine($"Day: {item.Groups["day"].Value}, Month: {item.Groups["month"].Value}, Year: {item.Groups["year"].Value}");
            }

       
        }
    }
}
