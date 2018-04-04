using System;
using System.Collections.Generic;

namespace SampleConApp
{
    //delegates are references to methods which can be used to invoke the method thro a reference instead of an object. Used to create methods that take other methods as arguements and could invoke those methods after a certain criteria is met....
    class Employee
    {
        public int EmpId { get; set; }
        public void OnEmployeeCreate(Action<string> callMe)
        {
            callMe("UR ID is 123");
        }
    }

    class EmpRep
    {
        //private bool finder(Employee emp)
        //{
        //    return emp.EmpId == int.Parse(_finderId);
        //}
        List<Employee> _employees = new List<Employee>();
        
        public void Find(int id)
        {
            _employees.Find((emp) => emp.EmpId == id);
        }
    }
    class Button
    {
        public event Action Click;
        public void Draw()
        {
            Console.WriteLine("Draws the button on the screen");
        }

        public void ClickMe()
        {
            Console.WriteLine("Button was clicked");
            if (this.Click != null)
                Click();
        }
    }
    delegate void FuncInvoker(double v1, double v2);
    class Delegates
    {
        //Action(with no return type) and Func(with return type)....
        static void InvokeFunc(FuncInvoker func)
        {
            //Take the inputs for the required args...
            Console.WriteLine("Enter one double value");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter one more double value");
            double v2 = double.Parse(Console.ReadLine());

            func(v1, v2);//Call the function....
        }
        
        static void oncreated(string str){
                Console.WriteLine("Wow!!! I was created");
                Console.WriteLine("Thanks for giving me " + str);
        }
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            //.NET 3.5....
            emp.OnEmployeeCreate(oncreated);
            //FuncInvoker invoker = new FuncInvoker(MathComponent.AddFunc);
            //InvokeFunc(addFunc);    

            Button btn = new Button();
            btn.Click += callMeWhenClicked;
            btn.Click += callThisOneToo;//Multicast delegate
            btn.Click += Btn_Click;   
            btn.Draw();
            btn.ClickMe();//Action done by the User...
        }

        private static void Btn_Click()
        {
        }

        static void callThisOneToo()
        {
            Console.WriteLine("Thanks for clicking me again");
        }
        static void callMeWhenClicked()
        {
            Console.WriteLine("Thanks for clicking me!!!!");
        }
        static void addFunc(double v1, double v2)
        {
            Console.WriteLine("v1 + v2 =" + (v1 +v2));
        }
    }
}
