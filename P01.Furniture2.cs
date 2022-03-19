using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)";
            string inputData = Console.ReadLine();

            List<string> printList = new List<string>();
            double totalSum = 0;

            while (inputData != "Purchase")
            {
                Match order = Regex.Match(inputData, pattern);

                if (order.Success)
                {
                    string nameFurniture = order.Groups["name"].Value;
                    double price = double.Parse(order.Groups["price"].Value);
                    double quantity = double.Parse(order.Groups["quantity"].Value);
                    printList.Add(nameFurniture);
                    totalSum += price * quantity;
                }
                inputData = Console.ReadLine();
            }


            Console.WriteLine("Bought furniture:");
            foreach (string item in printList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalSum:f2}");

        }
    }
}
