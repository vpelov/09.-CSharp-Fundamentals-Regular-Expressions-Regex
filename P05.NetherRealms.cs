using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P05.NetherRealms
{
    class Daemon
    {
        public Daemon(string daemonName, int health, double damage)
        {
            this.DaemonName = daemonName;
            this.Health = health;
            this.Damage = damage;
        }
        public string DaemonName { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Daemon> printList = new List<Daemon>();
            string inputData = Console.ReadLine();

            string[] stringArray = inputData
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < stringArray.Length; i++)
            {
                string daemonName = stringArray[i];
                int health = GetHealth(daemonName);
                double damage = GetDemage(daemonName);
                int multiplyCount = CheckMultyply(daemonName);
                int divideCount = CheckDivide(daemonName);

                if (multiplyCount != 0)
                {
                    damage = damage * (multiplyCount * 2);
                }
                if (divideCount != 0)
                {
                    damage = damage / (divideCount * 2);
                }

                Daemon currentDaemon = new Daemon(daemonName, health, damage);
                printList.Add(currentDaemon);

            }
            printList = printList.OrderBy(x => x.DaemonName).ToList();
            foreach (Daemon item in printList)
            {
                Console.WriteLine($"{item.DaemonName} - {item.Health} health, {item.Damage} damage");
            }

        }



        static int GetHealth(string text)
        {
            int health = 0;
            string pattern = @"[^0-9\+\-\*\/\.]+";
            MatchCollection match = Regex.Matches(text, pattern);

            StringBuilder newText = new StringBuilder();
            foreach (Match item in match)
            {
                newText.Append(item);
            }

            string textLast = newText.ToString();

            for (int i = 0; i < textLast.Length; i++)
            {
                int num = (int)textLast[i];
                health += num;
            }

            return health;
        }


        static double GetDemage(string text)
        {
            double returnNum = 0;
            string pattern = @"[\-]?(\d+(\.\d+)?)";
            MatchCollection match = Regex.Matches(text, pattern);
            foreach (Match item in match)
            {
                string current = item.ToString();
                double num = double.Parse(current);
                returnNum += num;
            }

            return returnNum;
        }

        static int CheckDivide(string text)
        {
            int divide = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\\')
                {
                    divide++;
                }
            }
            return divide;
        }


        static int CheckMultyply(string text)
        {
            int multiply = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '*')
                {
                    multiply++;
                }
            }
            return multiply;
        }
    }
}
