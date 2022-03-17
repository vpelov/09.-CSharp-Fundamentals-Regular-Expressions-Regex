using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> dataDict = new Dictionary<string, double>();

            string patern = @">>(?<furniture>[A-Z]+[a-z]*)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            string inputData = Console.ReadLine();

            while (inputData != "Purchase")
            {
                MatchCollection currentMatch = Regex.Matches(inputData, patern);

                foreach (Match match in currentMatch)
                {
                    string furniture = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);
                    dataDict.Add(furniture, price * quantity);
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in dataDict)
            {
                Console.WriteLine($"{item.Key}");
            }

            double totalSum = 0;

            foreach (var item in dataDict)
            {
                totalSum += item.Value;
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");

        }
    }
}
    
