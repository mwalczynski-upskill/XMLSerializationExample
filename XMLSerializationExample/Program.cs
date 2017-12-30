using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLSerializationExample.Models;

namespace XMLSerializationExample
{
    class Program
    {       
        static void Main(string[] args)
        {
            var workPlace = new WorkPlace(123, "PGS Software S.A");

            var workers = new List<Worker>
            {
                new Worker("Michał", 22, 123),
                new Worker("Tomasz", 33, 456),
                new Worker("Mateusz", 23, 789),
                new Worker("Patryk", 18, 101)
            };
            workPlace.Workers = workers;

            using (var fileStream = File.Open("workPlace.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(workPlace.GetType());
                serializer.Serialize(fileStream, workPlace);
            }

            using (var fileStream = File.Open("workers.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(workers.GetType());
                serializer.Serialize(fileStream, workers);
            }

            var xmlFile = XDocument.Load("workPlace.xml");
            xmlFile.Descendants("Worker")
                .Select(x => new Worker(x.Element("FirstName")?.Value, Int32.Parse(x.Element("Age")?.Value)))
                .Where(x => x.Age > 22)
                .ToList()
                .ForEach(x => { Console.WriteLine($"{x.FirstName}, {x.Age}"); });

            Console.ReadKey();
        }
    }
}
