using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();

            string[] inputArray = inputData.Split('|').ToArray();
            string partOne = inputArray[0];
            string partTwo = inputArray[1];
            string partThree = inputArray[2];

            List<char> charList = GetCapitalLetter(partOne);   // Find Capital Letters

            List<string> lenghtList = GetLenght(partTwo);      // Find ASCII and Lenght

            List<string> wordsList = GetWords(partThree);      // Find Words

            List<string> checkPrint = new List<string>();

            for (int i = 0; i < charList.Count; i++)
            {
                char currentCh = charList[i];

                for (int j = 0; j < lenghtList.Count; j++)
                {
                    string currentString = lenghtList[j];
                    int oneCharNum = int.Parse(currentString.Substring(0, 2));
                    int lenght = int.Parse(currentString.Substring(3, 2));

                    if (currentCh == oneCharNum)
                    {
                        for (int k = 0; k < wordsList.Count; k++)
                        {
                            string currentWord = wordsList[k];
                            char firstLetter = currentWord[0];
                            int wordLength = currentWord.Length - 1;

                            if (firstLetter == currentCh && wordLength == lenght)
                            {
                                if (!checkPrint.Contains(currentWord))
                                {
                                    Console.WriteLine(currentWord);
                                    checkPrint.Add(currentWord);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }


            //Console.WriteLine(string.Join(" ", wordsList));
        }

        static List<char> GetCapitalLetter(string partOne)  //Find Capital Letters
        {
            List<char> returnList = new List<char>();
            string pattern = @"[\#]{1}[A-Z]+[\#]{1}|[\$]{1}[A-Z]+[\$]{1}|[\%]{1}[A-Z]+[\%]{1}|[\&]{1}[A-Z]+[\&]{1}";
            Match match = Regex.Match(partOne, pattern);

            if (match.Success)
            {
                string workString = match.Value;
                for (int i = 1; i < workString.Length - 1; i++)
                {
                    char current = workString[i];
                    returnList.Add(current);

                }
            }
            return returnList;
        }

        static List<string> GetLenght(string partTwo)      // Find ASCII and Lenght
        {
            List<string> returnList = new List<string>();
            string pattern = @"[\d]{2}:[\d]{2}";

            MatchCollection match = Regex.Matches(partTwo, pattern);
            foreach (Match item in match)
            {
                returnList.Add(item.Value);
            }
            return returnList;
        }

        static List<string> GetWords(string partThree)            // Find Words
        {
            List<string> returnList = new List<string>();
            string pattern = @"\b[A-Z]{1}[^ ]+";

            MatchCollection match = Regex.Matches(partThree, pattern);

            foreach (Match item in match)
            {
                returnList.Add(item.Value);
            }
            return returnList;
        }
    }
}
