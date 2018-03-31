using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SampleConApp
{
    //Serialization is an ability of saving the state of the object into a storage device like a file or a Stream so that it could be used to retrieve the information back later. 
    //In .NET we have 3 types: Binary, XML and SOAP..
    //Binary is for within the Windows OS, XML is for cross platforms and SOAP is for Web services....
    //For every serialization: What to serialize, where to serialize and how to serialize...
    //What to serialize: Any object of the .net class that has an attribute serializable. 
    //Where: File, Stream or any: FileStream would be the most prefered one...
    //How:Either Binary or XML....
    
    [Serializable]
    public class Bill
    {
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public double Amount { get; set; }
        public string  Description { get; set; }

        public override string ToString()
        {
            return string.Format($"{BillNo}\t{BillDate}\n{Description}\t{Amount:C}");
        }
    }
    class SerializationApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do U want to save as XML or Binary");
            string option = Console.ReadLine();
            if (option == "XML")
            {
                xmlSerialization();
            }
            else
            {
                binarySerialization();
            }
            
        }

        private static void xmlSerialization()
        {
            Console.WriteLine("Do U want to save(S) or load(L)");
            string choice = Console.ReadLine();
            if (choice == "S")
            {
                saveXmlFile();
            }
            else
            {
                loadXmlFile();
            }
        }

        private static void loadXmlFile()
        {
            FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(Bill));
            var data = fm.Deserialize(fs) as Bill;//Deserialize returns object which U should unbox if U want to read specific members...
            Console.WriteLine(data);
        }

        //XML serialization needs UR Class marked as public, Formatter expects the type so that the schema is generated.
        private static void saveXmlFile()
        {
            var bill = new Bill();
            bill.BillNo = UIInteraction.GetInteger("Enter the BillNo");
            bill.BillDate = DateTime.Now;
            bill.Description = UIInteraction.GetString("Enter the Description");
            bill.Amount = UIInteraction.GetInteger("Enter the Amount of the Bill");

            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
            //BinaryFormatter fm = new BinaryFormatter();
            XmlSerializer fm = new XmlSerializer(typeof(Bill));
            fm.Serialize(fs, bill);
            fs.Close();
        }

        private static void binarySerialization()
        {
            Console.WriteLine("Do U want to save(S) or load(L)");
            string choice = Console.ReadLine();
            if (choice == "S")
            {
                saveFile();
            }
            else
            {
                loadFile();
            }
        }

        private static void loadFile()
        {
            FileStream fs = new FileStream("Data.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            //fm.Serialize(fs, bill);//Object graph not only contain the object state, but also the details of the class and assembly....
            var bill = fm.Deserialize(fs);
            fs.Close();
            Console.WriteLine(bill);

        }

        private static void saveFile()
        {
            var bill = new Bill();
            bill.BillNo = UIInteraction.GetInteger("Enter the BillNo");
            bill.BillDate = DateTime.Now;
            bill.Description = UIInteraction.GetString("Enter the Description");
            bill.Amount = UIInteraction.GetInteger("Enter the Amount of the Bill");
            FileStream fs = new FileStream("Data.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter fm = new BinaryFormatter();
            fm.Serialize(fs, bill);
            fs.Close();
        }
    }    
}