using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Sensors
{
    internal abstract class Sensor 
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public double Value { get; private set; }

        public Sensor(string name,string id, double value)
        {
            Name = name;
            Id = id;
            Value = value;
        }

        public virtual void UpdateValue(double newValue)
        {
            Value = newValue;
            Console.WriteLine($"{Name} (ID: {Id}) updated value: {Value}");
        }

        public virtual string Status()
        {
            return $"Sensor {Name} with ID {Id} reads currently {Value}.";
        }

    }
}
