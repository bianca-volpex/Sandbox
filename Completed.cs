using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox
{
    class Completed
    {
        private void Promo()
        {
            const int promo = 3;

            var testCaseCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var stuffCount = int.Parse(Console.ReadLine());

                var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

                var groups = collection.GroupBy(el => el).ToArray();

                decimal totalSum = 0;

                for (var g = 0; g < groups.Count(); g++)
                {
                    var cost = groups[g].Key;
                    var everyThird = Math.Truncate((decimal)(groups[g].Count() / promo));
                    var groupSum = groups[g].Sum() - everyThird * cost;

                    totalSum += groupSum;
                }

                Console.WriteLine(totalSum);
            }
        }

        private void table()
        {
            // считали количество кейсов
            var testCaseCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                // пустая строка перед кейсом 
                Console.ReadLine();

                // строки и столбцы
                var rowColumnString = Console.ReadLine().Split(' ');

                var rowCount = int.Parse(rowColumnString[0]);
                var columnCount = int.Parse(rowColumnString[1]);

                List<string> table = new List<string>();

                for (var row = 0; row < rowCount; row++)
                {
                    table.Add(Console.ReadLine());
                }

                // количество кликов
                var clickCount = int.Parse(Console.ReadLine());

                // номера столбцов, по которым клики
                var columnNumbers = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

                for (var click = 0; click < clickCount; click++)
                {
                    var column = columnNumbers[click];
                    table = table.OrderBy(el => int.Parse(el.Split(' ')[column - 1])).ToList();
                }

                table.ForEach(el => Console.WriteLine(el));
            }
        }

        private void Pair()
        {
            // считали количество кейсов
            var testCaseCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                // пустая строка перед кейсом 
                var devCount = int.Parse(Console.ReadLine());

                var grades = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToList();
                var dictionary = new Dictionary<int, int>();

                for (var key = 0; key < grades.Count; key++)
                    dictionary.Add(key + 1, grades[key]);

                while (dictionary.Count != 0)
                {
                    var firstKey = dictionary.FirstOrDefault();
                    var firstValue = firstKey.Value;
                    dictionary.Remove(firstKey.Key);

                    var diff = dictionary.Values.Distinct().ToDictionary(val => val, val => Math.Abs(val - firstValue));

                    var secondValue = diff.OrderBy(el => el.Value).FirstOrDefault().Key;
                    var secondKey = dictionary.FirstOrDefault(el => el.Value == secondValue);

                    dictionary.Remove(secondKey.Key);

                    Console.WriteLine($"{firstKey.Key} {secondKey.Key}");
                };

                //выводить пустую строку между наборами данных
                if (i != testCaseCount - 1)
                    Console.WriteLine();
            }
        }

        private void Dictionary() {
            // словарь
            var dictionary = new List<string>();
            var dictSize = int.Parse(Console.ReadLine());

            for (var i = 0; i < dictSize; i++)
            {
                dictionary.Add(Console.ReadLine());
            }

            // запросы
            var dictionaryQuery = new List<string>();
            var querySize = int.Parse(Console.ReadLine());

            for (var i = 0; i < querySize; i++)
            {
                dictionaryQuery.Add(Console.ReadLine());
            }

            for (var j = 0; j < dictionaryQuery.Count; j++)
            {
                var queryWord = dictionaryQuery[j];

                var res = string.Empty;

                var reverseWord = queryWord.Reverse().ToList();

                var biggest = 0;

                dictionary.ForEach(el =>
                {
                    if (!string.Equals(el, queryWord))
                    {
                        var revert = el.Reverse().ToList();

                        var counter = queryWord.Length >= el.Length ? el.Length : queryWord.Length;

                        var lengthSimilar = 0;
                        for (var l = 0; l < counter; l++)
                        {
                            if (reverseWord[l].Equals(revert[l]))
                                lengthSimilar++;
                            else
                                break;
                        }

                        if (lengthSimilar > biggest)
                        {
                            res = el;
                            biggest = lengthSimilar;
                        }

                        if (string.IsNullOrEmpty(res))
                            res = dictionary.FirstOrDefault();
                    }
                });

                Console.WriteLine(res);
            }
        }
    }
}
