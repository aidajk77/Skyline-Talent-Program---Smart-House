using Smart_House.Interfaces;
using System;
using System.Globalization;

namespace Smart_House.Devices
{
    internal abstract class Device : ITurnable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; protected set; }

        public Device(string name, string id)
        {
            Name = name;
            Id = id;
            IsActive = true;
        }

        public virtual void TurnOn()
        {
            IsActive = true;
            Console.WriteLine($"{Name} with ID {Id} is now ON.");
        }

        public virtual void TurnOff()
        {
            IsActive = false;
            Console.WriteLine($"{Name} with ID {Id} is now OFF.");
        }

        public virtual string status()
        {
            return IsActive ? $"{Name} is currently ON." : $"{Name} is currently OFF.";
        }
    }
}