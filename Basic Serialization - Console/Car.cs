using System;

namespace Basic_Serialization___Console
{
    [Serializable]
    public class Car
    {
        public string Model { get; set; } 
        public string RegNo { get; set; }

        public Car(string model, string regNo)
        {
            this.Model = model;
            this.RegNo = regNo;
        }
    }
}