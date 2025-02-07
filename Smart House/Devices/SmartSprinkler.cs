using Smart_House.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartSprinkler : Device
    {
        public Dictionary<Days, int > WateringSchedule { get; private set; }
        public SmartSprinkler(string name, string id, Dictionary<Days, int> wateringSchedule) : base(name, id)
        {
            WateringSchedule = wateringSchedule;
            foreach (var entry in WateringSchedule)
            {
                if (entry.Value < 0 || entry.Value > 120)
                {
                    throw new ArgumentException($"Invalid watering time for {entry.Key}: {entry.Value} minutes.");
                }
            }
        }
        public void WaterTheGarden(Days day)
        {
            if (WateringSchedule.ContainsKey(day))
            {
                base.TurnOn(); 
                Console.WriteLine($"Watering the garden for {WateringSchedule[day]} minutes.");
            }
            else
            {
                base.TurnOff();
                Console.WriteLine(" watering scheduled for today.");
            }
        }

        public void AddWateringSchedule(Days day, int minutes)
        {
            if (minutes < 0 || minutes > 120)
            {
                Console.WriteLine("Invalid watering time. Please enter between 0 and 120 minutes.");
                return;
            }

            WateringSchedule[day] = minutes;
            Console.WriteLine($"Scheduled watering for {day} for {minutes} minutes.");
        }

        public void ShowSchedule()
        {
            if (WateringSchedule.Count == 0)
            {
                Console.WriteLine("No watering schedule set.");
                return;
            }

            Console.WriteLine("Watering Schedule:");
            foreach (var entry in WateringSchedule)
            {
                Console.WriteLine($"🌿 {entry.Key}: {entry.Value} minutes");
            }
        }

    }

}
