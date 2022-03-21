using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace P02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"([\D]+)([\d]+)";
            string inputData = Console.ReadLine().ToUpper();

            List<string> resultList = new List<string>();
            MatchCollection match = Regex.Matches(inputData, pattern);

            foreach (Match item in match)
            {
                string current = item.Value;
                resultList.Add(current);
            }

            string patternNum = @"([\d]+)";
            StringBuilder printString = new StringBuilder();
            List<char> countSymbol = new List<char>();

            for (int i = 0; i < resultList.Count; i++)
            {
                int repped = 0;
                string current = resultList[i];
                Match num = Regex.Match(current, patternNum);

                if (num.Success)
                {
                    repped = int.Parse(num.Value);
                }

                StringBuilder reppedString = new StringBuilder();
                for (int j = 0; j < current.Length; j++)
                {
                    char ch = current[j];
                    if (!char.IsDigit(ch))
                    {
                        reppedString.Append(ch);
                        if (!countSymbol.Contains(ch))
                        {
                            countSymbol.Add(ch);
                        }
                    }
                }

                for (int k = 0; k < repped; k++)
                {
                    printString.Append(reppedString);
                }
                
            }
            Console.WriteLine($"Unique symbols used: {countSymbol.Count}");
            Console.WriteLine(string.Join(" ", printString));          

        }
    }
}
