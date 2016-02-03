using System;

namespace Basic_Serialization___Console
{
    [Serializable]
    public class Car
    {
        public string Model { get; set; } 
        public string RegNo { get; set; }
        public Owner Owner { get; set; }

        public Car(string model, string regNo, Owner owner)
        {
            this.Model = model;
            this.RegNo = regNo;
            this.Owner = owner;
        }
    }
}