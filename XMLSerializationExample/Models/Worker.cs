using System.Xml.Serialization;

namespace XMLSerializationExample.Models
{
    public class Worker
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        [XmlIgnore]
        public long Pesel { get; set; }

        public Worker() { }

        public Worker(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }

        public Worker(string firstName, int age, long pesel)
        {
            FirstName = firstName;
            Age = age;
            Pesel = pesel;
        }
    }
}
