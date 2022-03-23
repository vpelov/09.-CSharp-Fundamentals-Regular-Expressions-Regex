using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P04.Santa_sSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string message = Console.ReadLine();
            List<string> kidsName = new List<string>();
            while (message != "end")
            {
                char[] charArray = message.ToCharArray();
                string newMessage = GetMessageDivideKey(charArray, key);

                string patternCheck = @"[\@]{1}[^\@\-\!\:\>]+[\!]{1}[G|N]{1}[\!]{1}";
                Match match = Regex.Match(newMessage, patternCheck);
                if (match.Success)
                {
                    string name = GetName(newMessage);
                    char behavior = GetBehavior(newMessage);
                    if (behavior == 'G')
                    {
                        kidsName.Add(name);
                    }

                }
                
                message = Console.ReadLine();
            }
            foreach (string item in kidsName)
            {
                Console.WriteLine(item);
            }
        }


        static string GetMessageDivideKey(char[] chArray, int key)
        {
            StringBuilder returnString = new StringBuilder();
            for (int i = 0; i < chArray.Length; i++)
            {
                char currentCh = chArray[i];
                char newChar = (char)(currentCh - key);
                returnString.Append(newChar);
            }


            return returnString.ToString();
        }


        static string GetName(string newMessage)
        {
            StringBuilder returnStr = new StringBuilder();
            string pattern = @"[\@]{1}[A-Za-z]+";
            Match name = Regex.Match(newMessage, pattern);
            if (name.Success)
            {
                string match = name.ToString();
                for (int i = 1; i < name.Length; i++)
                {
                    char current = match[i];
                    returnStr.Append(current);
                }
            }

            return returnStr.ToString();
        }

        static char GetBehavior(string newMessage)
        {
            string pattern = @"[\!]{1}[G|N][\!]";
            Match match = Regex.Match(newMessage, pattern);
            char returnChar = '.';
            if (match.Success)
            {
                string cuStr = match.ToString();
                returnChar = cuStr[1];
            }

            return returnChar; 
        }

    }
}
