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
        public SmartThermostat SmartThermostat { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public Dictionary<string, int> Groceries { get; set; }
        public SmartFridge(string name, string id, SmartThermostat smartThermostat) : base(name, id)
        {
            SmartThermostat = smartThermostat;
            Groceries = new Dictionary<string, int>();
        }
        public void AddGrocery(string name, int quantity)
        {
            if (Groceries.ContainsKey(name))
            {
                Groceries[name] += quantity;
            }
            else
            {
                Groceries.Add(name, quantity);
            }
            Console.WriteLine($"{quantity} of {name} added to the fridge.");
        }
        public void TakeGrocery(string name)
        {
            if (Groceries.ContainsKey(name))
            {
                Groceries[name]--;
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
            }
            else
            {
                Console.WriteLine("The fridge contains:");
                foreach (var grocery in Groceries)
                {
                    Console.WriteLine($"{grocery.Value} of {grocery.Key}");
                }
            }
        }
        public void AdjustFridgeTemperature()
        {
            if (SmartThermostat.TemperatureSensor.Value < MinTemperature)
            {
                SmartThermostat.TargetSensorValue = MinTemperature;
                while (SmartThermostat.TemperatureSensor.Value < MinTemperature)
                {
                    SmartThermostat.AdjustTemperature();
                }
            }
            else if (SmartThermostat.TemperatureSensor.Value > MaxTemperature)
            {
                SmartThermostat.TargetSensorValue = MaxTemperature;
                while (SmartThermostat.TemperatureSensor.Value > MaxTemperature)
                {
                    SmartThermostat.AdjustTemperature();
                }
            }
            else
            {
                Console.WriteLine($"The fridge temperature is optimal.");
            }
        }
    }
}
