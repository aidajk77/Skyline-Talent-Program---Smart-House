using Smart_House.Devices;
using Smart_House.Enums;
using Smart_House.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Models
{
    internal class Room
    {
        public RoomType RoomType { get; private set; }
        public List<Device> Devices { get; set; }
        public List<Sensor> Sensors { get; set; }

        public Room(RoomType roomType, List<Device> devices, List<Sensor> sensors)
        {
            RoomType = roomType;
            Devices = devices;
            Sensors = sensors;
        }
        public Room(RoomType roomType, List<Device> devices)
        {
            RoomType = roomType;
            Devices = devices;
            Sensors = new List<Sensor>();
        }
        public Room(RoomType roomType)
        {
            RoomType = roomType;
            Devices = new List<Device>();
            Sensors = new List<Sensor>();
        }

        public void AddDevice(Device device)
        {
            Devices.Add(device);
        }

        public void AddSensor(Sensor sensor)
        {
            Sensors.Add(sensor);
        }

        public void RemoveDevice(Device device)
        {
            if (device == null || !Devices.Contains(device))
            {
                Console.WriteLine("Cannot remove: Device not found in the room.");
                return;
            }

            Devices.Remove(device);
            Console.WriteLine($"Device {device.Name} (ID: {device.Id}) has been removed from the {RoomType}.");
        }

        public void RemoveSensor(Sensor sensor)
        {
            if (sensor == null || !Sensors.Contains(sensor))
            {
                Console.WriteLine("Cannot remove: Sensor not found in the room.");
                return;
            }

            Sensors.Remove(sensor);
            Console.WriteLine($"Sensor {sensor.Name} (ID: {sensor.Id}) has been removed from the {RoomType}.");
        }

        public void ShowRoomContents()
        {
            Console.WriteLine($"Contents of { RoomType}:");
            Console.WriteLine("   -Devices:");
            foreach (Device device in Devices) {
                Console.WriteLine(device.Name+", "+device.Id);
            }
            Console.WriteLine("    -Sensors");
            foreach (Sensor sensor in Sensors)
            {
                Console.WriteLine(sensor.Name + ", " + sensor.Id);
            }
        }
    }
}
