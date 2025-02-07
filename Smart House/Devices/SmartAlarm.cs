using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Smart_House.Devices
{
    internal class SmartAlarm : Device
    {
        public bool IsTriggered { get; private set; } = false;

        public SmartAlarm(string name, string id) : base(name, id)
        {
        }

        public override void TurnOn()
        {
            if (!IsActive)
            {
                base.TurnOn();
                Console.WriteLine("The alarm system is now turned on.");
            }
            else
            {
                Console.WriteLine("The alarm is already ON.");
            }
        }

        public override void TurnOff()
        {
            if (IsActive)
            {
                base.TurnOff();
                IsTriggered = false;
                Console.WriteLine("The alarm system is now turned off.");
            }
            else
            {
                Console.WriteLine("The alarm is already OFF.");
            }
        }

        public void TriggerAlarm()
        {
            if (IsActive)
            {
                IsTriggered = true;
                Console.WriteLine("ALERT! The alarm has been TRIGGERED!");
            }
            else
            {
                Console.WriteLine("The alarm is OFF. It cannot be triggered.");
            }
        }

        public string CheckStatus()
        {
            if (IsTriggered)
                return "Alarm is TRIGGERED!";

            return IsActive ? "Alarm is ON." : "Alarm is OFF.";
        }
    }
}
