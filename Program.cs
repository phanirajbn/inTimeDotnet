using System;

namespace SampleConApp
{
    class Program
    {
        static string getString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            conversionDemo();
            //displayAllRanges();
            //Console.WriteLine("Enter the name");
            //string name = Console.ReadLine();//ReadLIne is the method used for reading the input from the console. It returns only string....

            //firstDemo();
        }

        private static void conversionDemo()
        {
            try
            {
                long value = 12323423432423423;
                //int iVal = (int)value;//Explicit conversion...
                int iVal = Convert.ToInt32(value);
                Console.WriteLine(iVal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void firstDemo()
        {
            string name = getString("Enter the name");
            int age = getInteger("Enter the Age");
            string city = getString("Enter the City");

            Console.WriteLine($"The name is {name}. The Address is {city} and the Age is {age}");
        }

        private static void displayAllRanges()
        {
            Console.WriteLine($"The range of byte is {byte.MinValue} and {byte.MaxValue}");
            Console.WriteLine($"The range of short is {short.MinValue} and {short.MaxValue}");
            Console.WriteLine($"The range of int is {int.MinValue} and {int.MaxValue}");
            Console.WriteLine($"The range of long is {long.MinValue} and {long.MaxValue}");
            Console.WriteLine($"The range of float is {float.MinValue} and {float.MaxValue}");
            Console.WriteLine($"The range of double is {double.MinValue} and {double.MaxValue}");
            Console.WriteLine($"The range of decimal is {decimal.MinValue} and {decimal.MaxValue}");
        }

        /*
* C# by itself does not own any data type. 
* All data types in C# are from the .NET Framwork.
* .NET Framework has 2 broad types of data types:
* Value types and Reference types
* Value types are primitive types and Reference types are classes....
* Value types:
* Integral types: byte(System.Byte), short(Int16), int(Int32), long(Int64)....
* Floating types: float(Single), double(Double), decimal(Decimal)
* Other types: char(Char), bool(Boolean).
* User defined types: enum(Enum), struct...
* NOTE: All data types in .NET are represented either as structs(value types) or classes(Reference types)
* C# has keywords to represent these datatypes in its program...
*/
        private static int getInteger(string v)
        {
            return int.Parse(getString(v));
        }
    }
}
