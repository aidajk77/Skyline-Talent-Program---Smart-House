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
            if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
            {
                throw new ArgumentException("Password must be at least 4 characters long.");
            }
            Password = password;
        }

        public override void TurnOff()
        {
            base.TurnOff(); 
            Console.WriteLine("The lock is turned off.");
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("The lock is turned on.");
        }

        public bool Unlock()
        {
            Console.WriteLine("Enter the password to unlock:");
            string enteredPassword = Console.ReadLine();
            int attempts = 0;

            while (enteredPassword != Password)
            {
                attempts++;
                if (attempts >= 3)
                {
                    Console.WriteLine("Too many failed attempts. Try again later.");
                    return false;
                }
                Console.WriteLine("Incorrect password. Try again:");
                enteredPassword = Console.ReadLine();
            }

            Console.WriteLine("Access granted. The lock is now open.");
            return true;
        }

        public void ChangePassword()
        {
            Console.WriteLine("Enter the current password:");
            string currentPassword = Console.ReadLine();
            int attempts = 0;

            while (currentPassword != Password)
            {
                attempts++;
                if (attempts >= 3)
                {
                    Console.WriteLine("Too many failed attempts. Try again later.");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again:");
                currentPassword = Console.ReadLine();
            }

            string newPassword;
            do
            {
                Console.WriteLine("Enter the new password (min 4 characters):");
                newPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4)
                {
                    Console.WriteLine("Password too weak. Please enter at least 4 characters.");
                }
            } while (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4);

            Password = newPassword;
            Console.WriteLine("Password has been changed successfully.");
        }
    }
}
