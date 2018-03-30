using System;
//Arrays are reference types that are used to perform common operations on a group of objects like a collection. They are fixed in size and the most primitive way of representing group of data. 
namespace SampleConApp
{
    class ArraysDemo
    {
        /*foreach notes:
         * Used only on collections...
         * Used for reading the data in the collection.
         * Its forward only and read only...
         * U dont have to know the bounds of the array
         */
        static void Main(string[] args)
        {
            //firstDemo();
            //TwoDArrayDemo();
            //jaggedArrayDemo();
            arrayObjectDemo();
        }

        private static void arrayObjectDemo()
        {
            //Size of the array..
            Console.WriteLine("Enter the size of the Array");
            int size = int.Parse(Console.ReadLine());
            //What data type for UR Array...
            Console.WriteLine("Enter the type of data U want to create an array\nPlease enter the name as .NET type(CTS type)");
            Type dataType = Type.GetType(Console.ReadLine());
            if(dataType == null)
            {
                Console.WriteLine("Invalid data type, sorry!!!!");
                return;
            }
            Array array = Array.CreateInstance(dataType, size);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Enter a value of the data type " + dataType.Name);
                string valueEntered = Console.ReadLine();
                array.SetValue(Convert.ChangeType(valueEntered, dataType), i);
            }
            //.NET has an universal data type called System.Object represented by keyword called object. It is similar to void* of C/C++...

            Console.WriteLine("All the values are set");
            //foreach(var val in array)
            //  Console.WriteLine(val);//Data is stored as object and displayed as object...
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array.GetValue(i));
            }
        }

        private static void jaggedArrayDemo()
        {
            //Arrays with fixed no of rows and variable no of columns in each row...
            int [] [] school = new int[3][];
            school[0] = new int[] {45, 56, 65, 45, 56, 45 };
            school[1] = new int[] { 24, 56, 67 };
            school[2] = new int[] { 67, 78, 67, 78 };

            for (int i = 0; i < school.Length; i++)
            {
                foreach(var s in school[i])
                    Console.Write(s + " ");
                Console.WriteLine();
            }
        }

        private static void TwoDArrayDemo()
        {
            int[,] TwoD = new int[,] { { 2, 3, 4, 5 }, { 3, 4, 5, 6 }, { 4, 5, 6, 7 } };
            //Every Arrayobject is an instance of a System.Array.  U could extract info about the array object at runtime...
            Console.WriteLine("The no of dimensions:" + TwoD.Rank);
            Console.WriteLine("The Length of first demension is " + TwoD.GetLength(0));
            Console.WriteLine("The Length of second demension is " + TwoD.GetLength(1));
            Console.WriteLine("This array is in the matrix format of {0}x{1}", TwoD.GetLength(0), TwoD.GetLength(1));
            Console.WriteLine("The Total size(No of Items) is {0}", TwoD.Length);
            Console.WriteLine("Displaying in the form of a matrix");
            for (int i = 0; i < TwoD.GetLength(0); i++)
            {
                for (int j = 0; j < TwoD.GetLength(1); j++)
                {
                    Console.Write(TwoD[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void firstDemo()
        {
            //datatype [] varName = new dataType[size];
            int[] values = new int[5];//creating the array using new operator...
            for (int i = 0; i < 5; i++)
            {
                values[i] = i + 1;//explicitly set the values....
            }
            int[] numbers = { 34, 45, 45, 45, 453, 2, 3, 56, 7, 7 };
            foreach (var value in numbers)
                Console.WriteLine(value);//value means each item in the array....
                                         //Optimization: use foreach for reading the data from the array...
        }
    }
}/*NOTES:
Arrays are fixed in Size. U cannot change the size of the Array after its created.
Arrays are convinient only if U know the size as well as the data type....
Alternatively U could use Generics or Collections for dynamic Arrays...
*/
