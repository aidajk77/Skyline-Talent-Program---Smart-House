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

        public override void UpdateValue(double newValue)
        {
            if (newValue < 0 || newValue > 100)
            {
                Console.WriteLine("❌ Invalid smoke level. Must be between 0 and 100.");
                return;
            }

            base.UpdateValue(newValue);
        }
        public override string Status()
        {
            if(Value >= 50)
            {
                Console.WriteLine("🚨 CRITICAL SMOKE LEVEL!");
            }
            else if (Value >= 30)
            {
                Console.WriteLine("WARNING LEVEL!");
            }
            return $"Smoke sensor {Id} reads currently {Value}.";
        }
    }
}
