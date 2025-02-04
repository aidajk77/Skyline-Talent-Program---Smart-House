using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House.Devices
{
    internal class SmartLock : Device
    {
        public string Password { get; private set; }
        public SmartLock(string name, string id, string password) : base(name, id)
        {
            Password = password;
        }
        public override void TurnOff()
        {
            IsActive = false;
            Console.WriteLine("The lock is turned off.");
        }
        public override void TurnOn()
        {
            IsActive = true;
            Console.WriteLine("The lock is turned on.");
        }
        public void changePassword()
        {
            Console.WriteLine("Please enter the current password:");
            string currentPassword = Console.ReadLine();
            int counter = 0;
            while (currentPassword != Password)
            {
                Console.WriteLine("The current password is incorrect. Try again:");
                currentPassword = Console.ReadLine();
                counter++;
                if (counter == 3)
                {
                    Console.WriteLine("You have entered the wrong password too many times. Try again later.");
                    return;
                }
            }
            Console.WriteLine("Please enter the new password:");
            string newPassword = Console.ReadLine();
            Password = newPassword;
            Console.WriteLine("The password has been changed.");
        }


    }
}
