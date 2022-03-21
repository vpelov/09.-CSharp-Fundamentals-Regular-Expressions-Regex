using System;
using System.Text.RegularExpressions;

namespace P03.SoftuniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<name>[A-Z]{1}[a-z]+)\%[^|$%.]*?\<(?<product>\w+)\>[^|$%.]*?\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>\d+(\.\d+)?)\$";
            double totalSum = 0;
            string inputData = Console.ReadLine();

            while (inputData != "end of shift")
            {
                Match inData = Regex.Match(inputData, pattern);

                if (inData.Success)
                {
                    string name = inData.Groups["name"].Value;
                    string product = inData.Groups["product"].Value;
                    double count = double.Parse(inData.Groups["count"].Value);
                    double price = double.Parse(inData.Groups["price"].Value);

                    Console.WriteLine($"{name}: {product} - {count * price:f2}");
                    totalSum += count * price;
                }



                inputData = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");

        }
    }
}
