using Smart_House.Devices;
using Smart_House.Models;
using Smart_House.Enums;
using Smart_House.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Device> livingRoomDevices = new List<Device>();
            livingRoomDevices.Add(new SmartAlarm("Living room alarm","al1"));
            livingRoomDevices.Add(new SmartLightning("Living room light", "li1"));
            livingRoomDevices.Add(new SmartThermostat("Living room thermostat", "th1",new TemperatureSensor("Temp sensor","sens1",20.3),22));
            List<Sensor> livingRoomSensors = new List<Sensor>();
            livingRoomSensors.Add(new SmokeSensor("smoke sensor","sens2",50.2));
            Room livingRoom = new Room(RoomType.LivingRoom, livingRoomDevices, livingRoomSensors);
            List<Device> kitchenDevices = new List<Device>();
            kitchenDevices.Add(new SmartAlarm("Kitchen alarm", "al2"));
            kitchenDevices.Add(new SmartLightning("Kitchen light", "li2"));
            kitchenDevices.Add(new SmartThermostat("Kitchen thermostat", "th2", new TemperatureSensor("Temp sensor", "sens3", 27.3), 22));
            kitchenDevices.Add(new SmartFridge("Kitchen fridge", "fr1",new SmartThermostat("Fridge thermostat","Fr1",new TemperatureSensor("Temp sensor","sens4",20),15)));
            List<Sensor> kitchenSensors = new List<Sensor>();
            kitchenSensors.Add(new SmokeSensor("smoke sensor", "sens4", 90.5));
            Room Kitchen = new Room(RoomType.Kitchen, kitchenDevices, kitchenSensors);
            List<Device> GardenDevices = new List<Device>();
            Dictionary<Days, int> gardenSprinklerSchedule = new Dictionary<Days, int>();
            gardenSprinklerSchedule.Add(Days.Monday, 10);
            gardenSprinklerSchedule.Add(Days.Tuesday, 15);
            gardenSprinklerSchedule.Add(Days.Wednesday, 20);
            GardenDevices.Add(new SmartSprinkler("Garden sprinkler", "sp1",gardenSprinklerSchedule));
            GardenDevices.Add(new SmartLightning("Garden light", "li3"));
            GardenDevices.Add(new SmartCamera("Garden camera", "ca1","1920x1080",500));
            Room garden = new Room(RoomType.Garden, GardenDevices);
            List<Device> hallwayDevices = new List<Device>();
            hallwayDevices.Add(new  SmartLock("Hallway lock", "lo1","abc"));
            hallwayDevices.Add(new SmartLightning("Hallway light", "li4"));
            Room hallway = new Room(RoomType.Hallway, hallwayDevices);
            List<Room> rooms = new List<Room>();
            rooms.Add(livingRoom);
            rooms.Add(Kitchen);
            rooms.Add(garden);
            rooms.Add(hallway);
            SmartHouse smartHouse = new SmartHouse("sh1", "123 Main St", rooms);
            SmartThermostat st = (SmartThermostat)smartHouse.Rooms.ElementAt(1).Devices.ElementAt(2);
            st.AdjustTemperature();









        }
    }
}
