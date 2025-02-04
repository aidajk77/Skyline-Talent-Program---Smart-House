using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Sensors
{
    internal class SmokeSensor : Sensor
    {
        public SmokeSensor(string name, string id, double value) : base(name,id, value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Smoke value must be between 0 and 100.");
            }
        }
        public override string status()
        {
            return $"Smoke sensor {Id} reads currently {Value} %.";
        }
    }
}
