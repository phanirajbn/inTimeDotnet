using System;
namespace SampleConApp
{
   
    abstract class Account
    {
        public Account()
        {
            Amount = 5000;
        }
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Amount { get; protected set; }

        public void Deposit(int amount)
        {
            Amount += amount;
        }

        public void Withdraw(int amount)
        {
            if (Amount >= amount)
                Amount -= amount;
            else
                throw new Exception("Insufficient Funds");
        }
        public abstract void CalculateInterest();
    }

    class FDAccount : Account
    {
        public override void CalculateInterest()
        {
            var interest = this.Amount * 1 / 2 * 8.5 / 100;
            Amount += interest;
        }
    }
    class SBAccount : Account
    {
        //Abstract methods are implemented using override...
        public override void CalculateInterest()
        {
            var interest = this.Amount * 1 / 12 * 6.5 / 100;
            this.Amount += interest;
            //this.Deposit((int)interest);
        }
    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            Account acc = new FDAccount();
            acc.Deposit(50000);
            Console.WriteLine("The current balance is " + acc.Amount);
            acc.CalculateInterest();
            Console.WriteLine("The current balance after interest calcuation is " + acc.Amount);

        }
    }
}