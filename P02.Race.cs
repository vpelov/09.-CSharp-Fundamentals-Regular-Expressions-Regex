using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            
            string[] nameRaser = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string someText = Console.ReadLine();

            while (someText != "end of race")
            {
                string name = string.Empty; ;
                int distance = 0;

                char[] someTextArray = someText.ToCharArray();

                foreach (char item in someTextArray)
                {
                    if (Char.IsDigit(item))
                    {
                        distance += item - '0';
                    }
                    else if (char.IsLetter(item))
                    {
                        name += item;
                    }
                }

                if (!data.ContainsKey(name))
                {
                    data.Add(name, distance);
                }
                else
                {
                    data[name] += distance;
                }

                someText = Console.ReadLine();
            }

            Dictionary<string, int> printDict = new Dictionary<string, int>();

            foreach (var item in data)
            {
                for (int i = 0; i < nameRaser.Length; i++)
                {
                    if (item.Key == nameRaser[i])
                    {
                        printDict.Add(item.Key, item.Value);
                    }
                }
            }

            
            int count = 0;

            foreach (var item in printDict.OrderByDescending(x => x.Value))
            {
                if (count == 0)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (count == 1)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                else if (count == 3)
                {
                    break;
                }
                
                count++;
            }
        }
    }
}
