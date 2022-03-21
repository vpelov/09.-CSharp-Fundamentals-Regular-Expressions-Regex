using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P01.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (inputData.Length == 0)
            {
                Console.WriteLine("invalid ticket");
            }

            for (int i = 0; i < inputData.Length; i++)
            {
                string ticket = inputData[i];

                string[] returnArray = new string[2];

                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                else if (ticket.Length == 20)
                {
                    string one = ticket.Substring(0, 10);
                    string two = ticket.Substring(10, 10);
                    returnArray[0] = one;
                    returnArray[1] = two;
                }

                CheckTicket(returnArray);

            }


        }


        static void CheckTicket(string[] checkArray)
        {
            bool isPrint = true;
            string one = checkArray[0];
            string two = checkArray[1];

            string fullOne = CheckFullSymbol(one);
            string fullTwo = CheckFullSymbol(two);

            if (fullOne != string.Empty && fullOne[0] == fullTwo[0])
            {
                Console.WriteLine($"ticket \"{one + two}\" - {fullOne.Length}{fullOne[0]} Jackpot!");
                isPrint = false;
            }

            string newOne = CheckSymbol(one);
            string newTwo = CheckSymbol(two);

            if (newOne.Length!= 0 && newOne.Length == newTwo.Length && newOne[0] == newTwo[0] && isPrint)
            {
                Console.WriteLine($"ticket \"{one + two}\" - {newOne.Length}{newOne[0]}");
                isPrint = false;
            }
                        

            if (isPrint)
            {
                Console.WriteLine($"ticket \"{one + two}\" - no match");
            }
        }



        static string CheckSymbol(string text)
        {
            string back = string.Empty;
            string pattern = @"(?<symbol>[\@]{6,9}|[\#]{6,9}|[\$]{6,9}|[\^]{6,9})";
            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                back = match.Groups["symbol"].Value;
            }
            return back;
        }

        static string CheckFullSymbol(string text)
        {
            string back = string.Empty;
            string pattern = @"(?<sym>[\@]{10}|[\#]{10}|[\$]{10}|[\^]{10})";

            Match full = Regex.Match(text, pattern);

            if (full.Success)
            {
                back = full.Groups["sym"].Value;
            }
            return back;
        }


    }
}
