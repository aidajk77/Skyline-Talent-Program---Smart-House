using Smart_House.Sensors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartThermostat : Device
    {
        public TemperatureSensor TemperatureSensor { get; set; }
        public int TargetSensorValue { get; set; }
        
        public SmartThermostat(string name,string id, TemperatureSensor temperatureSensor, int targetSensorValue) : base(name,id)
        {
            TemperatureSensor = temperatureSensor;
            TargetSensorValue = targetSensorValue;
        }
        public void AdjustTemperature()
        {
            if (TemperatureSensor.Value < TargetSensorValue)
            { 
                Console.WriteLine($"Temperature is {(int)TemperatureSensor.Value}°C. Turning on the heating.");
                TemperatureSensor.Value += 1;

            }
            else if (TemperatureSensor.Value > TargetSensorValue)
            {
                Console.WriteLine($"Temperature is {(int)TemperatureSensor.Value}°C. Turning on the cooling.");
                TemperatureSensor.Value -=1;
            }
            else
            {
                Console.WriteLine($"Temperature is {(int)TemperatureSensor.Value}°C. The temperature is optimal.");
            }
        }


    }
}
