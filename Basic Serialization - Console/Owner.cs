using System;

namespace Basic_Serialization___Console
{
    [Serializable]
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Owner(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}