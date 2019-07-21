using System;
using static System.Console;

//doc: https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/patterns.md

namespace PatternMatching
{
    class Program
    {
        static void Main()
        {
            #region Property patterns
            WriteLine(ShowPropertyPatterns(new Car(240)));
            WriteLine(ShowPropertyPatterns(new Car(180)));
            WriteLine(ShowPropertyPatterns(new Car(140)));
            WriteLine(ShowPropertyPatterns(15));
            WriteLine(ShowPropertyPatterns(new object()));
            WriteLine(ShowPropertyPatterns(null));
            #endregion

            WriteLine();
            WriteLine();
            Console.ReadLine();

            #region Tuple patterns & positinal
            WriteLine(ShowTuplePatterns(new DateTime(1996, 9, 3)));
            WriteLine(ShowTuplePatterns(new DateTime(2014, 5, 24)));
            WriteLine(ShowTuplePatterns(new DateTime(2018, 7, 23)));
            WriteLine(ShowTuplePatterns(new DateTime(2020, 7, 23)));
            WriteLine(ShowTuplePatterns(DateTime.Today));
            #endregion

            ReadLine();
            //static local function
            //Property patterns
            static string ShowPropertyPatterns(object car) => car switch
            {
                Car { MaxSpeed: var s } c when s > 220            => "Fast Car",
                Car { MaxSpeed: var s } c when s > 160 && s < 220 => "Usual car",
                Car { MaxSpeed: var s } c when s < 160            => "Not fast car",
                { }                                               => "another object",
                null                                              => "null"
            };
        }

        //tuple & positional patterns
        static string ShowTuplePatterns(DateTime dt) => dt switch
        {
            (3, 9, 1996)                => $"My birthday {dt.ToUniversalTime()}",
            (_, 5, 2014)                => $"SBTech Ukraine birthday {dt.ToUniversalTime()}",
            (_, 7, 2018)                => $"Start work at SBTech {dt:d}",
            var (_, _, z) when z > 2019 =>  "Future date",
            _                           => $"Today is {dt:d}"
        };
    }
}
