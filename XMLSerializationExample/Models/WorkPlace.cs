using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLSerializationExample.Models
{
    public class WorkPlace
    {
        [XmlElement("CompanyIdentifier")]
        public int Nip { get; set; }
        public string Name { get; set; }
        [XmlArray]
        public List<Worker> Workers { get; set; }

        public WorkPlace() { }

        public WorkPlace(int nip, string name)
        {
            Nip = nip;
            Name = name;
        }
    }
}
