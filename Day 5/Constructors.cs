using System;
namespace SampleConApp
{
    class Radio
    {
        public int Price { get; set; }
        public string Name { get; set; }
    }

    class Car
    {
        //public Car()
        //{
        //    this.audioSystem = new Radio();
        //}
        public Car(Radio radio)
        {
            this.audioSystem = radio;
        }
        public Car() : this(new Radio { Name="Philips", Price = 2000})
        {

        }
        public Radio audioSystem { get; set; }
        public void Play()
        {
            Console.WriteLine($"The audio system called {audioSystem.Name} is playing...");
        }
    }

    //Derived class is  instantiated, it will chain to the base class and then to its constructor. It will always try to call default constructor of the base class....
    class BMW : Car
    {
        public BMW() : base(new Radio { Name ="JBL", Price=45000 })
        {

        }
    }
    //What is a Constructor?
    class ConstructorDemo
    {
        static void Main(string[] args)
        {
            Car car = new BMW();
            car.Play();
        }
    }
}