using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // количество кейсов
            var caseCount = int.Parse(Console.ReadLine());
            Random rand = new Random();

            for (var t = 0; t < caseCount; t++)
            {
                // количество сотрудников
                var empCount = int.Parse(Console.ReadLine());

                var min = 15;
                var max = 30;

                var result = new List<int>();

                for (var n = 0; n < empCount; n++)
                {
                    // желаемая температура
                    var wanted = Console.ReadLine().Split(' ');

                    var wantedMean = wanted[0];
                    var wantedVal = int.Parse(wanted[1]);

                    if (string.Equals(wantedMean, ">="))
                        min = wantedVal;
                    else
                        max = wantedVal;

                    if (min > max)
                        result.Add(-1);
                    else
                        result.Add(rand.Next(min, max));
                }

                result.ForEach(el => Console.WriteLine(el));

                Console.WriteLine();
            }
        }
    }
}