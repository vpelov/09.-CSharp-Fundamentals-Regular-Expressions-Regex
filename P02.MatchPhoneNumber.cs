using System;
using System.Text.RegularExpressions;

namespace P02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359(?<group>-| )2\k<group>[0-9]{3}\k<group>[0-9]{4}\b";

            string inputData = Console.ReadLine();

            MatchCollection phone = Regex.Matches(inputData, pattern);

            string[] printArray = new string[phone.Count];
            int count = 0;

            foreach (Match item in phone)
            {                
                printArray[count] = item.Value;
                count++;
            }

            Console.WriteLine(String.Join(", ", printArray));


            //int count = 0;                                       // Valid to

            //for (int i = 0; i < phone.Count; i++)
            //{
            //    if (count == phone.Count - 1)
            //    {
            //        Console.Write(phone[i]);
            //    }
            //    else
            //    {
            //        Console.Write(phone[i] + ", ");
            //    }

            //    count++;
            //}

        }
    }
}
