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
        public Dictionary<Days, int > WateringSchedule { get; set; }
        public SmartSprinkler(string name, string id, Dictionary<Days, int> wateringSchedule) : base(name, id)
        {
            WateringSchedule = wateringSchedule;
        }
        public void WaterTheGarden(Days day)
        {
            if (WateringSchedule.ContainsKey(day))
            {
                IsActive= true;
                Console.WriteLine($"Watering the garden for {WateringSchedule[day]} minutes.");
            }
            else
            {
                IsActive = false;
                Console.WriteLine("No watering scheduled for today.");
            }
        }
    }
}
