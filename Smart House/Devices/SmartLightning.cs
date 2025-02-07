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
        public LightningColors Color { get; private set; }

        public SmartLightning(string name, string id, LightningColors color = LightningColors.none)
            : base(name, id)
        {
            Color = color;
        }

        public override void TurnOff()
        {
            Color = LightningColors.none;
            base.TurnOff();
            Console.WriteLine("The light is turned off.");
        }

        public override void TurnOn()
        {
            if (!IsActive)
            {
                base.TurnOn();

                Console.WriteLine("Please select a number for the desired color:");
                int counter = 0;
                foreach (var color in Enum.GetValues(typeof(LightningColors)))
                {
                    if (color.ToString() == "none") continue;
                    Console.WriteLine($"{counter + 1}. {color.ToString()}");
                    counter++;
                }
                bool isValid;
                int selectedColor;
                do
                {
                    isValid = int.TryParse(Console.ReadLine(), out selectedColor) && selectedColor>0 && selectedColor<=Enum.GetValues(typeof(LightningColors)).Length-1;
                    if (!isValid)
                        Console.WriteLine("Invalid input. Please try again.");
                } while (!isValid);
                Color = (LightningColors)selectedColor;

                Console.WriteLine($"The light is turned on and set to {Color}.");
            }
            else
            {
                Console.WriteLine("The light is already on.");
            }
        }

        public void ChangeColor(LightningColors newColor)
        {
            if (!IsActive)
            {
                Console.WriteLine("Cannot change color. The light is OFF.");
                return;
            }

            Color = newColor;
            Console.WriteLine($"The light color changed to {Color}.");
        }

        
    }
}
