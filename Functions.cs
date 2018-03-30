using System;
namespace SampleConApp
{
    //Functions in C# are of 2 types:Static and non static functions. 
    //Static functions are singleton functions that are invoked by the name of the class. It will thus help in invoking them across the Application without an object instance. 
    //Non Static functions are functions that are created for the instance of the class and will be accessed only thro the object of that class. The non static members can access their non static data, non static functions and even static members. 
    //Static members need an object instance for accessing the instance members. 
    class FunctionsDemo
    {
        void TestFunc()//default they are private....
        {
            StaticTestFunc();//Instance functions can call Static functions....
            Console.WriteLine("Test Func");
        }

        //It is recommended practise to have methods take inputs in the form of parameters instead of statements
        public static int AddNumbers(int v1, int v2)
        {
            return v1 + v2;
        }

        public static int SubtractNumbers(int v1, int v2)
        {
            return v1 - v2;
        }

        //Pass by ref would make the caller initialize the value before sending it into the function. Pass by Out would get the value from the function without the need of the Caller initializing it. The called function must set the value for Out parameter.
        public static void SquareOperation(int value, ref int squaredValue, out double squareRootValue)
        {
            squaredValue = value * value;
            if (value != 0)
                squareRootValue = Math.Sqrt(value);
            else squareRootValue = 0;
        }
        public static void AddNumbers()
        {
            Console.WriteLine("Enter v1");
            int v1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter v2");
            int v2 = int.Parse(Console.ReadLine());
            Console.WriteLine("The Added value is " + (v1 + v2));
        }
        static void StaticTestFunc()
        {
            Console.WriteLine("Static functions are like global");
        }

        //There will be only params for a function signature. It will always be the last of the parameter list.n It should always be passed by value..
        public static void DisplayFullName(params string[] nameParts)
        {
            var fullName = string.Empty;
            foreach (var name in nameParts)
                fullName += name + " ";
            Console.WriteLine(fullName);
        }

        //If UR App has more than one entry point, U should set the Startup object thro the project settings by selecting the class from the dropdownlist that contain the list of classes in UR project that has a valid entry point...
        static void Main(string[] args)
        {
            DisplayFullName("FirstName", "MiddleName", "LastName");
            //params allow to pass different number of arguments into the function....

            int squared = 123;
            double squareRt;
            SquareOperation(4, ref squared, out squareRt);
            Console.WriteLine("The results are Squared:{0} and Root: {1}", squared, squareRt);
            Console.WriteLine("Enter v1");
            int v1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter v2");
            int v2 = int.Parse(Console.ReadLine());
            Console.WriteLine("The Added value is " + AddNumbers(v1 , v2));
            //AddNumbers();
            //FunctionsDemo demo = new FunctionsDemo();
            //demo.TestFunc();
        }
    }
}