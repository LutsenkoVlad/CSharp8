using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

//doc: https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/async-streams.md

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            static async IAsyncEnumerable<string> Demo1Async()
            {
                var aDevice = new Advice();
                await foreach (var item in aDevice.GetSensorData1())
                    yield return $"Demo1 {item.Score1} {item.Score2}";
            }

            static async IAsyncEnumerable<string> Demo2Async()
            {
                var aDevice = new Advice();

                IAsyncEnumerable<Event> en = aDevice.GetSensorData1();
                IAsyncEnumerator<Event> enumerator = en.GetAsyncEnumerator();
                try
                {
                    while (await enumerator.MoveNextAsync())
                    {
                        var sendorData = enumerator.Current;
                        yield return $"Demo2 {sendorData.Score1} {sendorData.Score2}";
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync();
                }
            }

            await foreach (var item in Demo1Async()) WriteLine(item);
            WriteLine();
            WriteLine();
            await foreach (var item in Demo2Async()) WriteLine(item);

            ReadLine();
        }
    }
    
    public struct Event
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public Event(int score1, int score2) => (Score1, Score2) = (score1, score2);
    }

    public class Advice
    {
        public async IAsyncEnumerable<Event> GetSensorData1()
        {
            var r = new Random();
            int count = 0;
            while (count != 10)
            {
                await Task.Delay(r.Next(3000));
                yield return new Event(r.Next(1000), r.Next(5000));count++;
            }
        }
    }
}
