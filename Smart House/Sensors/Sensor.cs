using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Sensors
{
    internal abstract class Sensor 
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public double Value { get; set; }

        public Sensor(string name,string id, double value)
        {
            Name = name;
            Id = id;
            Value = value;
        }

        public virtual string status()
        {
            return $"Sensor {Name} with ID {Id} reads currently {Value}.";
        }

    }
}
