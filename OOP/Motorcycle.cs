using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Motorcycle
    {
        public int driverIntensity;
        public void PopAWheely()
        {
            for (int i = 0; i < driverIntensity; i++)
            {
                Console.WriteLine("Yeeeee Haaaaaaewww!");
            }
        }

        // constructor chaining
        public Motorcycle()
        {
            Console.WriteLine("In default constoructor");
        }
        public Motorcycle(int intensity)
            : this(intensity, "")
        {
            Console.WriteLine("In constructor taking an int");
        }
        public Motorcycle(string name)
            : this(0, name) 
        {
            Console.WriteLine("In constructor taking an string");
        }
        /*public Motorcycle(int intensity)
        {
            if(intensity > 10)
            {
                intensity = 10;
            }
            intensity = driverIntensity;
        }*/

        // master constructor
        public Motorcycle(int intensity, string name)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
        public string driverName;
        public void SetDriverName(string name)
        {
            driverName = name;
            this.driverName = name;
        }
    }
}
