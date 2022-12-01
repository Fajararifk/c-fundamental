using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Car
    {
        public string petName;
        public int currSpeed;

        // A custome default constructor
        // constructor is a special method of a class that is called indirectly when creating object using new keyboard
        public Car()
        {
            petName = "Chucky";
            currSpeed = 10;
        }

        public Car(string name)
        {
            petName = name;
        }

        public Car(string name, int currentSpeed)
        {
            petName = name;
            currSpeed = currentSpeed;
        }

        // COnstructors as Expression-Bodied Members
        public Car(int pn) => currSpeed = pn;

        public void PrintState()
        {
            Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        }
        public void SpeedUp(int delta)
            => currSpeed += delta;
    }
}
