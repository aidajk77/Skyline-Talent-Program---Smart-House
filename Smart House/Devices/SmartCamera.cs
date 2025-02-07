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
            RecordingsInMB = new List<int>();
            StorageCapacity = storage;
            UsedStorage = 0;
            NightVisionEnabled = false;

            if (IsValidResolution(resolution))
                Resolution = resolution;
            else
                throw new ArgumentException("Invalid resolution. Choose from: 720p, 1080p, 4K.");
        }

        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine("The camera is turned off.");
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("The camera is turned on.");
        }

        public void EnableNightVision()
        {
            if (!NightVisionEnabled)
            {
                NightVisionEnabled = true;
                Console.WriteLine("Night vision is enabled.");
            }
            else
            {
                Console.WriteLine("Night vision is already enabled.");
            }
        }

        public void DisableNightVision()
        {
            if (NightVisionEnabled)
            {
                NightVisionEnabled = false;
                Console.WriteLine("Night vision is disabled.");
            }
            else
            {
                Console.WriteLine("Night vision is already disabled.");
            }
        }

        public void ChangeResolution(string resolution)
        {
            if (IsValidResolution(resolution))
            {
                Resolution = resolution;
                Console.WriteLine($"The resolution has been changed to {resolution}.");
            }
            else
            {
                Console.WriteLine("Invalid resolution. Choose from: 720p, 1080p, 4K.");
            }
        }

        private bool IsValidResolution(string resolution)
        {
            return resolution == "720p" || resolution == "1080p" || resolution == "4K";
        }

        public int CheckStorageAvailable()
        {
            return StorageCapacity - UsedStorage;
        }

        public void SaveRecording(int size)
        {
            if (size <= 0)
            {
                Console.WriteLine("Invalid recording size. Must be greater than 0MB.");
                return;
            }

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
            Console.WriteLine($"Recording {index + 1} has been deleted.");
        }

        public void ShowAllRecordings()
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

        public void ClearStorage()
        {
            RecordingsInMB.Clear();
            UsedStorage = 0;
            Console.WriteLine("Storage has been cleared.");
        }
    }
}
