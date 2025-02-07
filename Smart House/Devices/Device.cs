using Smart_House.Interfaces;
using System;
using System.Globalization;

namespace Smart_House.Devices
{
    internal abstract class Device : ITurnable
    {
        public string Name { get; set; }
        public string Id { get; private set; }
        public bool IsActive { get; protected set; } = false; 

        public Device(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public virtual void TurnOn()
        {
            if (!IsActive)
            {
                IsActive = true;
                Console.WriteLine($"{Name} with ID {Id} is now ON.");
            }
            else
            {
                Console.WriteLine($"{Name} is already ON.");
            }
        }

        public virtual void TurnOff()
        {
            if (IsActive)
            {
                IsActive = false;
                Console.WriteLine($"{Name} with ID {Id} is now OFF.");
            }
            else
            {
                Console.WriteLine($"{Name} is already OFF.");
            }
        }

        public virtual string Status() 
        {
            return IsActive ? $"{Name} is currently ON." : $"{Name} is currently OFF.";
        }
    }
}
