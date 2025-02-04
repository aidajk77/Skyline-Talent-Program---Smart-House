using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartAlarm : Device
    {
        public SmartAlarm(string name, string id) : base(name, id)
        {
            IsActive = false;
        }
        public override void TurnOff()
        {
            IsActive = false;
            Console.WriteLine("The alarm is turned off.");
        }
        public override void TurnOn()
        {
            IsActive = true;
            Console.WriteLine("The alarm is turned on.");
        }
    }
}