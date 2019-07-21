using System;

//This how to enable Nullable Reference Types errors instead of warnings
//csproj:<WarningsAsErrors>CS8600;CS8602;CS8603</WarningsAsErrors>

namespace NullableTypesAsErrors
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = null; //CS8600: Converting null literal or possible null value to non-nullable type

            //Console.WriteLine(str.Length); //CS8602: Dereference of a possibly null reference
            //Console.WriteLine(GetType(new DateTime()));
        }

        //static string GetType<T>(T item)
        //{
        //    return item?.ToString(); //CS8603: Possible null reference return
        //}
    }
}
