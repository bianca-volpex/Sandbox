using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox
{
    class CompeteComplate
    {
        private void Signs()
        {
            // первоначальная наклейка
            var signInit = Console.ReadLine();

            // наклеяно сверху
            var aboveCount = int.Parse(Console.ReadLine());

            for (var n = 0; n < aboveCount; n++)
            {
                var nextSignParam = Console.ReadLine().Split(' ');

                var start = int.Parse(nextSignParam[0]);
                var end = int.Parse(nextSignParam[1]);
                var sign = nextSignParam[2]; // это записано между start и end

                signInit = signInit.Remove(start - 1, end - start + 1).Insert(start - 1, sign);
            }

            Console.WriteLine(signInit);
        }

        private void Temperature()
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

        private void Relief()
        {
            // количество кейсов
            var caseCount = int.Parse(Console.ReadLine());

            var output = new List<string> { };

            for (var c = 0; c < caseCount; c++)
            {
                var param = Console.ReadLine().Split(' ');

                var reliefCount = int.Parse(param[0]);
                var reliefHeight = int.Parse(param[1]);
                var reliefWidth = int.Parse(param[2]);

                var res = new List<string> { };

                string initString = new string('.', reliefWidth);

                for (var i = 0; i < reliefHeight; i++)
                    res.Add(initString);

                for (var relief = 0; relief < reliefCount; relief++)
                {
                    if (relief != 0)
                        Console.ReadLine();

                    for (var str = 0; str < reliefHeight; str++)
                    {
                        var currentStr = Console.ReadLine();
                        var resStr = res[str];

                        int isOpen = 0;
                        for (var symb = 0; symb < reliefWidth; symb++)
                        {
                            var isFree = resStr[symb].Equals('.');

                            if (currentStr[symb].Equals('/'))
                            {
                                isOpen++;

                                if (isFree)
                                    resStr = resStr.Remove(symb, 1).Insert(symb, currentStr[symb].ToString());
                            }
                            else if (currentStr[symb].Equals('\\'))
                            {
                                isOpen--;

                                if (isFree)
                                    resStr = resStr.Remove(symb, 1).Insert(symb, currentStr[symb].ToString());
                            }
                            else if (isOpen > 0 && isFree)
                            {
                                resStr = resStr.Remove(symb, 1).Insert(symb, "X");
                            }
                        }

                        res[str] = resStr;
                    }


                }

                output.AddRange(res);
                output.Add(string.Empty);
            }

            output.ForEach(el => Console.WriteLine(el));
        }
    }
}
