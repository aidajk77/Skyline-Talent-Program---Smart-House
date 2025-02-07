using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartFridge : Device
    {
        public SmartThermostat SmartThermostat { get; private set; }
        public int MinTemperature { get; private set; }
        public int MaxTemperature { get; private set; }
        public Dictionary<string, int> Groceries { get; private set; }

        public SmartFridge(string name, string id, SmartThermostat smartThermostat, int minTemp = 2, int maxTemp = 6)
            : base(name, id)
        {
            SmartThermostat = smartThermostat;
            Groceries = new Dictionary<string, int>();
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
        }

        public void AddGrocery(string name, int quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Must be greater than 0.");
                return;
            }

            if (Groceries.ContainsKey(name))
                Groceries[name] += quantity;
            else
                Groceries[name] = quantity;

            Console.WriteLine($"{quantity} of {name} added to the fridge.");
        }

        public void TakeGrocery(string name)
        {
            if (Groceries.ContainsKey(name))
            {
                Groceries[name]--;

                if (Groceries[name] <= 0)
                {
                    Groceries.Remove(name);
                    Console.WriteLine($"{name} is out of stock.");
                }
                else
                {
                    Console.WriteLine($"One {name} taken. Remaining: {Groceries[name]}.");
                }
            }
            else
            {
                Console.WriteLine($"There is no {name} in the fridge.");
            }
        }

        public void CheckGroceries()
        {
            if (Groceries.Count == 0)
            {
                Console.WriteLine("The fridge is empty.");
                return;
            }

            Console.WriteLine("The fridge contains:");
            foreach (var grocery in Groceries)
                Console.WriteLine($"{grocery.Value}x {grocery.Key}");
        }

        public void AdjustFridgeTemperature()
        {
            double currentTemp = SmartThermostat.TemperatureSensor.Value;

            if (currentTemp < MinTemperature)
            {
                SmartThermostat.TargetSensorValue = MinTemperature;
                while (SmartThermostat.TemperatureSensor.Value < MinTemperature)
                {
                    SmartThermostat.AdjustTemperature();
                }
                Console.WriteLine($"Fridge is warming up to {MinTemperature}°C.");
            }
            else if (currentTemp > MaxTemperature)
            {
                SmartThermostat.TargetSensorValue = MaxTemperature;
                while (SmartThermostat.TemperatureSensor.Value > MaxTemperature)
                {
                    SmartThermostat.AdjustTemperature();
                }
                Console.WriteLine($"Fridge is cooling down to {MaxTemperature}°C.");
            }
            else
            {
                Console.WriteLine($"The fridge temperature is optimal: {currentTemp}°C.");
            }
        }
    }
}
