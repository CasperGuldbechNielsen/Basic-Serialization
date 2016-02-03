using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Serialization___Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Owner owner = new Owner(1, "Casper");

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Owner.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, owner);
            stream.Close();

            Stream outputStream = new FileStream("Owner.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Owner outputOwner = (Owner)formatter.Deserialize(outputStream);
            stream.Close();

            string message = outputOwner.Id + ", " + outputOwner.Name;

            Console.WriteLine(message);
            
            Console.ReadKey();
        }
    }
}
