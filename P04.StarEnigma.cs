using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace P04.StarEnigma
{
    class Planet
    {
        public Planet(string planet, int population, char attackType, int army)
        {
            this.NamePlanet = planet;
            this.Population = population;
            this.AttackType = attackType;
            this.SoldierCount = army;
        }

        public string NamePlanet { get; set; }

        public int Population { get; set; }

        public char AttackType { get; set; }

        public int SoldierCount { get; set; }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            string primePattern = @"\@(?<planetName>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>[0-9]+)[^\@\-\!\:\>]*?\!(?<attackType>[A|D]{1})[^\@\-\!\:\>]*?\!\-\>(?<soliderCount>\d+)";

            List<Planet> printList = new List<Planet>();
            int numberMessage = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberMessage; i++)
            {
                string inputMessage = Console.ReadLine();
                string encryptMessage = GetEncryptMessage(inputMessage);

                Match match = Regex.Match(encryptMessage, primePattern);
                if (match.Success)
                {
                    string planet = match.Groups["planetName"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    char attackType = char.Parse(match.Groups["attackType"].Value);
                    int soliderCount = int.Parse(match.Groups["soliderCount"].Value);

                    Planet current = new Planet(planet, population, attackType, soliderCount); ;

                    printList.Add(current);
                }
            }

            printList = printList.OrderBy(x => x.NamePlanet).ToList();

            Console.WriteLine($"Attacked planets: {GetAttackPlanetCount(printList)}");
            foreach (Planet item in printList)
            {
                if (item.AttackType == 'A')
                {
                    Console.WriteLine($"-> {item.NamePlanet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {GetDestoydPlanetCount(printList)}");
            foreach (Planet item in printList)
            {
                if (item.AttackType == 'D')
                {
                    Console.WriteLine($"-> {item.NamePlanet}");
                }
            }
        }







        static string GetEncryptMessage(string message)
        {
            StringBuilder ready = new StringBuilder();
            int count = GetCount(message);

            foreach (char item in message)
            {
                int currentCh = item - count;
                char ch = (char)currentCh;
                ready.Append(ch);
            }


            return ready.ToString();
        }

        static int GetCount(string message)
        {
            int count = 0;
            string pattern = @"(?i)[star]{1}";
            MatchCollection currentMatch = Regex.Matches(message, pattern);
            count = currentMatch.Count;

            return count;
        }

        static int GetAttackPlanetCount(List<Planet> printList)
        {
            int count = 0;
            foreach (Planet item in printList)
            {
                if (item.AttackType == 'A')
                {
                    count++;
                }
            }

            return count;
        }

        static int GetDestoydPlanetCount(List<Planet> printList)
        {
            int count = 0;
            foreach (Planet item in printList)
            {
                if (item.AttackType == 'D')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
