using Smart_House.Devices;
using Smart_House.Enums;
using Smart_House.Models;
using Smart_House.Sensors;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Smart House Simulation!");

        //  1. Create a Smart House
        SmartHouse myHouse = new SmartHouse("H-001", "123 Main St");

        //  2. Create Rooms
        Room livingRoom = new Room(RoomType.LivingRoom);
        Room kitchen = new Room(RoomType.Kitchen);
        Room bedroom = new Room(RoomType.Bedroom);
        Room garden = new Room(RoomType.Garden);

        //  3. Add Rooms to the House
        myHouse.AddRoom(livingRoom);
        myHouse.AddRoom(kitchen);
        myHouse.AddRoom(bedroom);
        myHouse.AddRoom(garden);

        //  4. Create Devices
        Device livingRoomLight = new SmartLightning("Living Room Light", "LGT-001", LightningColors.white);
        Device kitchenLight = new SmartLightning("Kitchen Light", "LGT-002", LightningColors.blue);
        Device deskLamp = new SmartLightning("Desk Lamp", "LGT-003", LightningColors.white);
        Device thermostat = new SmartThermostat("Home Thermostat", "THM-001", new TemperatureSensor("Thermostat Sensor", "TMP-001", 22.5), 24);
        Device smartLock = new SmartLock("Bedroom Door Lock", "SLK-001", "secure123");
        Device alarm = new SmartAlarm("Home Alarm", "ALM-001");
        Device smartFridge = new SmartFridge("Kitchen Fridge", "FRG-001", new SmartThermostat("Fridge Thermostat", "THM-002", new TemperatureSensor("Fridge Sensor", "TMP-002", 4), 4));

        // Smart Sprinkler System with Predefined Schedule
        Dictionary<Days, int> wateringSchedule = new Dictionary<Days, int>
        {
            { Days.Monday, 30 },
            { Days.Wednesday, 45 },
            { Days.Friday, 60 }
        };
        Device smartSprinkler = new SmartSprinkler("Garden Sprinkler", "SPR-001", wateringSchedule);

        //  5. Add Devices to Rooms
        livingRoom.AddDevice(livingRoomLight);
        livingRoom.AddDevice(deskLamp);
        kitchen.AddDevice(kitchenLight);
        kitchen.AddDevice(smartFridge);
        bedroom.AddDevice(thermostat);
        bedroom.AddDevice(smartLock);
        bedroom.AddDevice(alarm);
        garden.AddDevice(smartSprinkler);

        //  6. Create Sensors
        Sensor smokeSensor = new SmokeSensor("Kitchen Smoke Detector", "SMK-001", 10);
        Sensor outdoorTempSensor = new TemperatureSensor("Garden Sensor", "TMP-004", 18);

        //  7. Add Sensors to Rooms
        kitchen.AddSensor(smokeSensor);
        garden.AddSensor(outdoorTempSensor);

        //  8. Display Initial House Info
        Console.WriteLine("Initial Smart House Setup:");
        myHouse.DisplayHouseInfo();

        //  9. Simulate Actions

        // Turn on and off some devices
        livingRoomLight.TurnOn();
        livingRoomLight.TurnOff();
        kitchenLight.TurnOn();
        smartLock.TurnOn();
        alarm.TurnOn();
        thermostat.TurnOn();

        // Unlock the Smart Lock
        if (smartLock is SmartLock lockDevice)
        {
            lockDevice.Unlock();
        }

        // Adjust Thermostat Temperature
        if (thermostat is SmartThermostat homeThermostat)
        {
            homeThermostat.SetTargetTemperature(20);
            homeThermostat.AdjustTemperature();
        }

        //  Simulate Smoke Detector Reading
        if (smokeSensor is SmokeSensor kitchenSmokeSensor)
        {
            kitchenSmokeSensor.UpdateValue(55); //  Should trigger an alert
        }

        //  Water the Garden on Monday
        if (smartSprinkler is SmartSprinkler gardenSprinkler)
        {
            gardenSprinkler.WaterTheGarden(Days.Monday);
        }

        //  10. Display Updated House Info
        Console.WriteLine("Updated Smart House Status:");
        myHouse.DisplayHouseInfo();

        //  11. Room Removal
        Console.WriteLine("Removing Kitchen from the House...");
        myHouse.RemoveRoom(kitchen);

        //  12. Display Final House Info
        Console.WriteLine("Final Smart House Status:");
        myHouse.DisplayHouseInfo();
    }
}
