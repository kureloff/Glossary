using System;
using System.Collections.Generic;
using System.IO;

namespace Glossary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Work();
        }

        static void Work()
        {
            Dictionary<string, string> glossary = ReadGlossary("GamersGlossary.txt");
            string inputUser = "";
            bool isWork = true;

            while (inputUser != "exit")
            {
                Console.WriteLine("Введите слово: ");
                inputUser = Console.ReadLine();
                Console.Clear();
                SearchTerm(inputUser, glossary, ref isWork);
            }
        }

        static void SearchTerm(string keyword, Dictionary<string, string> glossary, ref bool isWork)
        {
            if (glossary.TryGetValue(keyword.ToLower(), out string value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Вашего слова - нет в списке");
            }
        }

        static Dictionary<string, string> ReadGlossary(string path)
        {
            string[] file = File.ReadAllLines(path);
            Dictionary<string, string> glossary = new Dictionary<string, string>(file.Length);

            char separator = ' ';

            foreach (string line in file)
            {
                string[] term = line.Split(separator);
                string key = term[0].ToLower();
                glossary.Add(key, line);
            }

            return glossary;
        }
    }
}
