using System;
using System.Collections.Generic;
using static System.Console;

//doc: https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/index-range-changes.md
//     https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/ranges.md
//     https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/ranges.cs

namespace IndicesAndRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Index i2b = 2;  //number 2 from beggining
            //Index i2e = ^2; //number 2 from end

            //WriteLine($"number 2 from begging {numbers[i2b]}");
            //WriteLine($"number 2 from end {numbers[i2e]}");
            //WriteLine();

            //Console.ReadLine();

            //WriteLine($"From 2 to 10: ");
            //foreach (var item in numbers[2..^0])
            //    WriteLine(item);
            //WriteLine();

            //Console.ReadLine();

            //WriteLine($"From 8 to end: ");
            //foreach (var item in numbers[8..])
            //    WriteLine(item);
            //WriteLine();

            //Console.ReadLine();

            //WriteLine($"From 2 to end: ");
            //Range range = 2..;
            //foreach (var item in numbers[range])
            //    WriteLine(item);
            //WriteLine();

            //Console.ReadLine();

            string text = "Powerfull .NET CORE 3.0!";
            WriteLine(text[11..^1]);
            WriteLine();
            WriteLine();

            ReadOnlySpan<Char> span = text.AsSpan();
            WriteLine(span[2..^2].ToString());

            #region Maybe
            //foreach(var y in 0..100)
            //{
            //    CW(y);
            //}

            //switch (value)
            //{
            //    case 0..10: ..;break;
            //}
            #endregion

            ReadLine();
        }
    }
}
