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
            List<Owner> owners = new List<Owner>();

            owners.Add(new Owner(1, "Casper"));
            owners.Add(new Owner(2, "Istvan"));
            owners.Add(new Owner(3, "Bianca"));

            List<Car> cars = new List<Car>();

            cars.Add(new Car("Volvo", "AA 12 123", owners[0]));
            cars.Add(new Car("Bmw", "BB 98 987", owners[1]));
            cars.Add(new Car("Corsa", "HJ 53 348", owners[2]));

            List<object> persistence = new List<object>();

            persistence.Add(owners);
            persistence.Add(cars);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            Stream outputStream = null;

            List<object> outputOwner;

            try
            {
                stream = new FileStream("Owner.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, persistence);
            }
            catch (SerializationException sie)
            {
                throw sie;
            }
            catch (IOException e)
            {
                throw e;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            try
            {
                outputStream = new FileStream("Owner.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                outputOwner = (List<object>) formatter.Deserialize(outputStream);
            }
            catch (SerializationException sie)
            {
                throw sie;
            }
            catch (IOException e)
            {
                throw e;
            }
            finally
            {
                if (outputStream != null)
                {
                    outputStream.Close();
                }
            }
            

            List<Owner> newOwners = new List<Owner>();
            List<Car> newCars = new List<Car>();

            newOwners = (List<Owner>)outputOwner[0];
            newCars = (List<Car>)outputOwner[1];

            foreach (var item in newOwners)
            {
                string message = item.Id + ", " + item.Name;
                Console.WriteLine(message);
            }

            Console.WriteLine("==================");

            foreach (var item in newCars)
            {
                string message = item.Model + ", " + item.RegNo + ", " + item.Owner.Name;
                Console.WriteLine(message);
            }

            Console.WriteLine("==================");

            if (newOwners[0].Equals(newCars[0].Owner))
            {
                Console.Write("It is!");
            }

            Console.ReadKey();
        }
    }
}
