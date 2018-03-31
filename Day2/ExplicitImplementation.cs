using System;
namespace SampleConApp
{
    interface ICustomer
    {
        void Create(string id, string name, string address);
    }

    interface IEmployee
    {
        void Create(string id, string name, string address);
    }

    class CustomerEmployee : ICustomer, IEmployee
    {
        void ICustomer.Create(string id, string name, string address)
        {
            Console.WriteLine($"The Customer by name {name} at {address} with id {id} has been added");
        }

        void IEmployee.Create(string id, string name, string address)
        {
            Console.WriteLine($"The Employee by name {name} at {address} with id {id} has been added");
        }
        public void Create(string id, string name, string address)
        {
            Console.WriteLine("Apple 123");
        }
    }
    class MainExplicitDemo
    {
        static void Main(string[] args)
        {
            ICustomer cst = new CustomerEmployee();
            cst.Create("123", "Phaniraj", "Bangalore");

            IEmployee emp = new CustomerEmployee();
            emp.Create("123", "Phaniraj", "Bangalore");

            CustomerEmployee cstEmp = new CustomerEmployee();
            cstEmp.Create("123", "Phaniraj", "Bangalore");
        }
    }
}