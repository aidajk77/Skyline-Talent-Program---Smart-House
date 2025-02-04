using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartCamera : Device
    {
        public string Resolution { get; private set; }
        public int StorageCapacity { get; }
        public int UsedStorage { get; private set; }
        public bool NightVisionEnabled { get; private set; }
        public List<int> RecordingsInMB { get; private set; }
        public SmartCamera(string name, string id, string resolution, int storage) : base(name, id)
        {
            Resolution = resolution;
            StorageCapacity = storage;
            UsedStorage = 0;
            NightVisionEnabled = false;
        }
        public override void TurnOff()
        {
            IsActive = false;
            Console.WriteLine("The camera is turned off.");
        }
        public override void TurnOn()
        {
            IsActive = true;
            Console.WriteLine("The camera is turned on.");
        }
        public void EnableNightVision()
        {
            NightVisionEnabled = true;
            Console.WriteLine("Night vision is enabled.");
        }
        public void DisableNightVision()
        {
            NightVisionEnabled = false;
            Console.WriteLine("Night vision is disabled.");

        }
        public void ChangeResolution(string resolution)
        {
            Resolution = resolution;
            Console.WriteLine($"The resolution has been changed to {resolution}.");
        }
        public int CheckStorageAvailable()
        {
            return StorageCapacity - UsedStorage;
        }
        public void SaveRecording(int size)
        {
            if (size > CheckStorageAvailable())
            {
                Console.WriteLine("Not enough storage available.");
                return;
            }
            RecordingsInMB.Add(size);
            UsedStorage += size;
            Console.WriteLine($"Recording of size {size}MB has been saved.");
        }
        public void DeleteRecording(int index)
        {
            if (index < 0 || index >= RecordingsInMB.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            UsedStorage -= RecordingsInMB[index];
            RecordingsInMB.RemoveAt(index);
            Console.WriteLine("Recording has been deleted.");
        }
        public void ShowAllRecordingsSizes()
        {
            if (RecordingsInMB.Count == 0)
            {
                Console.WriteLine("No recordings available.");
                return;
            }
            Console.WriteLine("Recordings:");
            for (int i = 0; i < RecordingsInMB.Count; i++)
            {
                Console.WriteLine($"Recording {i + 1}: {RecordingsInMB[i]}MB");
            }
        }
        public void ShowRecordingsSizeAtIndex(int index)
        {
            if (RecordingsInMB.Count == 0)
            {
                Console.WriteLine("No recordings available.");
                return;
            }
            if (index < 0 || index >= RecordingsInMB.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            Console.WriteLine($"Recording {index + 1}: {RecordingsInMB[index]}MB");

        }
        public void ClearStorage()
        {
            RecordingsInMB.Clear();
            UsedStorage = 0;
            Console.WriteLine("Storage has been cleared.");
        }
    }
}
