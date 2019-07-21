using System;
using static System.Console;

//This is how to enable Nullable Reference Types in project
//.csproj: <NullableContextOptions>enable</NullableContextOptions>
//doc: https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/nullable-reference-types.md

namespace NullableTypes
{

    class Program
    {
#pragma warning disable 219
        static void Main(string[] args)
        {
            string? s1 = null;
            string s2 = s1; //warning: Converting null literal or possible null value to non-nullable type

            string? s3 = "str3";
            Action someAction = () => s3 = null; //no worning
            //someAction();
            //WriteLine(s3.Length); //warning: Dereference of a possibly null reference.

#nullable disable
            string s4 = null; // ok
            WriteLine(s4);
#nullable restore

            string? s5 = null;
            //WriteLine(s5!.Length); //the "dammit" operator

            #region string default value
            string s6 = default;
            WriteLine($"what is default for string s6 == null - {s6 == null}");
            ReadLine();
            #endregion

            string? s7 = null;
            //WriteLine(s7!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!?.Length);

            Type t = Type.GetType("SomeType");
            //WriteLine(t.Name);

            #region Null coallescing assignment operator
            Program? program = null;

            
            if (program == null)
                program = new Program();
            //before C# 8.0

            //C# 8.0 approach
            program ??= new Program();

            #endregion

            ReadLine();
        }
    }
}
