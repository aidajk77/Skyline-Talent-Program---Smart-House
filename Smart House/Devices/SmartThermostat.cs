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
        public TemperatureSensor TemperatureSensor { get; private set; }
        public int TargetSensorValue { get; set; }
        
        public SmartThermostat(string name,string id, TemperatureSensor temperatureSensor, int targetSensorValue) : base(name,id)
        {
            TemperatureSensor = temperatureSensor;
            TargetSensorValue = targetSensorValue;
        }

        public void SetTargetTemperature(int targetTemperature)
        {
            if (!IsActive)
            {
                Console.WriteLine("Thermostat is OFF. Cannot set target temperature.");
                return;
            }
            TargetSensorValue = targetTemperature;
            Console.WriteLine($"Target temperature set to {TargetSensorValue}°C.");
        }
        public void AdjustTemperature()
        {
            if (!IsActive)
            {
                Console.WriteLine("Thermostat is OFF. Cannot adjust temperature.");
                return;
            }

            int currentTemp = (int)TemperatureSensor.Value;

            if (currentTemp < TargetSensorValue)
            {
                Console.WriteLine($"Temperature is {currentTemp}°C. Turning on the heating.");
                TemperatureSensor.UpdateValue(currentTemp + 1);
            }
            else if (currentTemp > TargetSensorValue)
            {
                Console.WriteLine($"Temperature is {currentTemp}°C. Turning on the cooling.");
                TemperatureSensor.UpdateValue(currentTemp - 1);
            }
            else
            {
                Console.WriteLine($"Temperature is {currentTemp}°C. The temperature is optimal.");
            }
        }



    }
}
