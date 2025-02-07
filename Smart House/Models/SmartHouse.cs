using Smart_House.Enums;
using Smart_House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartHouse
    {
        public string Id { get; private set; }
        public string Address { get; set; }
        public List<Room> Rooms { get; private set; }
        public SmartHouse(string id, string address, List<Room> rooms) : this(id, address)
        {
            Rooms = rooms;
        }

        public SmartHouse(string id, string address)
        {
            Id = id;
            Address = address;
            Rooms = new List<Room>();
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Room {room.RoomType} has been added to the house.");
        }
        public void RemoveRoom(Room room)
        {
            if (room == null || !Rooms.Contains(room))
            {
                Console.WriteLine("Cannot remove: Room not found.");
                return;
            }

            Rooms.Remove(room);
            Console.WriteLine($"{room.RoomType} has been removed from the house.");
        }
        public Room FindRoom(RoomType type)
        {
            foreach (var room in Rooms)
            {
                if (room.RoomType == type)
                {
                    return room;
                }
            }
            return null;
        }
        public int GetTotalDevices()
        {
            int totalDevices = 0;
            foreach (var room in Rooms)
            {
                totalDevices += room.Devices.Count;
            }
            return totalDevices;
        }
        public int GetTotalSensors()
        {
            int totalSensors = 0;
            foreach (var room in Rooms)
            {
                totalSensors += room.Sensors.Count;
            }
            return totalSensors;
        }
        public void DisplayHouseInfo()
        {
            Console.WriteLine($"House ID: {Id}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine("Rooms:");
            foreach (var room in Rooms)
            {
                Console.WriteLine($"Room type: {room.RoomType}");
                Console.WriteLine("Devices:");
                foreach (var device in room.Devices)
                {
                    Console.WriteLine($"Device name: {device.Name}");
                }
                Console.WriteLine("Sensors:");
                foreach (var sensor in room.Sensors)
                {
                    Console.WriteLine($"Sensor type: {sensor.Name}");
                }
            }
        }

    }
}
