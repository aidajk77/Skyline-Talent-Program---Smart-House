using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Sensors
{
    internal class TemperatureSensor : Sensor
    {
        public TemperatureSensor(string name, string id, double value) : base(name,id, value)
        {
            if(value < -50 || value > 100)
            {
                throw new ArgumentException("Temperature value must be between -50 and 50.");
            }
        }
        public override string status()
        {
            return $"Temperature sensor {Id} reads currently {Value} °C.";
        }
    }
}
