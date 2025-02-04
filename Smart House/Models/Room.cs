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
            Devices.Remove(device);
        }

        public void RemoveSensor(Sensor sensor)
        {
            Sensors.Remove(sensor);
        }
    }
}
