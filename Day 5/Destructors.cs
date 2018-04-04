using System;
namespace SampleConApp
{
    class SimpleClass : IDisposable
    {
        private string _testname;
        public SimpleClass(string name)
        {
            _testname = name;
            Console.WriteLine("The Object by name {0} is created", _testname);
        }
        public void Dispose()
        {
            Console.WriteLine("The object by name {0} is destroyed", _testname);
            GC.SuppressFinalize(this);
        }
        ~SimpleClass()
        {
            Console.WriteLine("The object by name {0} is destroyed", _testname);
        }
    }

    class DestructorMain
    {

        static void Main(string[] args)
        {
            createAndDestroyObjects();
        }

        private static void createAndDestroyObjects()
        {
            for (int i = 0; i < 100000; i++)
            {
                //SimpleClass cls = new SimpleClass(i.ToString());
                //cls.Dispose();
                using (SimpleClass cls = new SimpleClass(i.ToString()))
                {

                }
                GC.Collect();//GC will run a seperate thread to destroy the unused objects...
                GC.WaitForPendingFinalizers();//Main Thread to wait till all the objects are destroyed...
            }
        }
    }
}