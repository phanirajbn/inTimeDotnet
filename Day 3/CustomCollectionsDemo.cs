using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleConApp
{
    enum EmpCriteria {  Name, Address }
    //To compare objects for different criteria, U will create a new Class that implements IComparer interface
    class EmployeeComparer : IComparer<Employee>
    {
        private EmpCriteria criteria;
        public EmployeeComparer(EmpCriteria criteria)
        {
            this.criteria = criteria;
        }
        public int Compare(Employee x, Employee y)
        {
            switch (criteria)
            {
                case EmpCriteria.Name:
                    return x.EmpName.CompareTo(y.EmpName);
                case EmpCriteria.Address:
                    return x.EmpAddress.CompareTo(y.EmpAddress);
                default:
                    break;
            }
            return 0;
        }
    }
    class Employee : IComparable<Employee>
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int CompareTo(Employee other)
        {
            if (this.EmpID == other.EmpID)
                return 0;
            else if (this.EmpID < other.EmpID)
                return -1;
            else
                return 1;
        }
    }
    //foreach uses only collections=>A Class which has a public function called GetEnumerator....
    class FruitBasket : IEnumerable<string>
    {
        List<string> fruits = new List<string>();
        public void AddFruit(string name)
        {
            fruits.Add(name);
        }

        public void RemoveFruit(string name)
        {
            fruits.Remove(name);
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            return fruits.GetEnumerator();            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in fruits)
                yield return item;
        }
    } 

    class CollectionMain
    {
        static void Main(string[] args)
        {
            sortingDemo();
            //collectionDemo();
        }

        private static void sortingDemo()
        {
            //integerSorting();
            empSorting();
        }

        private static void empSorting()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { EmpID = 121, EmpName ="Phaniraj", EmpAddress="Bangalore" },
                new Employee { EmpID = 112, EmpName ="Anantharam", EmpAddress="Kochi" },
                new Employee { EmpID = 113, EmpName ="Zaheer Khan", EmpAddress="Mumbai" },
                new Employee { EmpID = 124, EmpName ="Sachin", EmpAddress="Pune" },
                new Employee { EmpID = 105, EmpName ="Dravid", EmpAddress="Bangalore" },
                new Employee { EmpID = 116, EmpName ="Srinath", EmpAddress="Mysore" }
            };
            Console.WriteLine("Sorting by ID");
            employees.Sort();
            foreach (var emp in employees)
                Console.WriteLine($"{emp.EmpID}->{emp.EmpName} from {emp.EmpAddress}");
            employees.Sort(new EmployeeComparer(EmpCriteria.Address));
            Console.WriteLine("Sorting by Address");
            foreach(var emp in employees)
                Console.WriteLine($"{emp.EmpID}->{emp.EmpName} from {emp.EmpAddress}");
            employees.Sort(new EmployeeComparer(EmpCriteria.Name));
            Console.WriteLine("Sorting by Name");
            foreach (var emp in employees)
                Console.WriteLine($"{emp.EmpID}->{emp.EmpName} from {emp.EmpAddress}");

        }

        private static void integerSorting()
        {
            List<int> integers = new List<int> { 34, 32, 45, 3, 42, 3, 4, 5, 6, 778, 5, 56, 32, 2, 34 };
            Console.WriteLine("Before sorting....");
            foreach (var item in integers)
                Console.WriteLine(item);
            integers.Sort();
            Console.WriteLine("After sorting....");

            foreach (var item in integers)
                Console.WriteLine(item);
        }

        private static void collectionDemo()
        {
            FruitBasket basket = new FruitBasket();
            basket.AddFruit("Apple");
            basket.AddFruit("Mango");
            basket.AddFruit("Orange");
            basket.AddFruit("Banana");

            IEnumerator<string> iterator = basket.GetEnumerator();
            //while(iterator.MoveNext())
            //    Console.WriteLine(iterator.Current);
            foreach (var item in basket)
                Console.WriteLine(item);
        }
    }
}