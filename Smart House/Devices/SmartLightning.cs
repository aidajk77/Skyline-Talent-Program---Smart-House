using Smart_House.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartLightning : Device
    {
        public LightningColors Color { get; set; }
        public SmartLightning(string name, string id, LightningColors color = LightningColors.none) : base(name, id)
        {
            Color = color;
        }
        public override void TurnOff()
        {
            Color = LightningColors.none;
            IsActive = false;
            Console.WriteLine("The light is turned off.");
        }
        public override void TurnOn()
        {
            Console.WriteLine("Please select a number of desired color:");
            int counter = 0;
            foreach (var color in Enum.GetValues(typeof(LightningColors)))
            {
                if(color.ToString() == "none")
                {
                    continue;
                }
                Console.WriteLine($"{counter+1}. {color.ToString()}");
                counter++;
            }
            int selectedColor = int.Parse(Console.ReadLine());
            Color = (LightningColors)selectedColor;
            IsActive = true;
            Console.WriteLine($"The light is turned on and it is lightning {Color.ToString()}");
        }

    }
}
