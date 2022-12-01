using System;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // THIS CLASS CAR
            /*Console.WriteLine("***** Fun with Class Types *****\n");
            // Allocate and configure a Car object.
            Car myCar = new Car();
            myCar.petName = "Fajar";
            myCar.petName = "Odegaard"; // change petName from Fajar to Odegaard

            // Make a Car called Chucky going 10 MPH
            Car chucky = new Car();
            chucky.PrintState();

            // Make a Car called Mary going 0 MPH.
            Car mary = new Car("Mary");
            mary.PrintState();

            // Make a Car called Jokowi goin 75 MPH.
            Car jokowi = new Car("Jokowi", 75);
            jokowi.PrintState();

            Car Maruf = new Car(10);
            Maruf.PrintState(); // default value of a string is Zero
            // because not there second parameter
            // There no Maruf in this printed
            myCar.currSpeed = 15;
            // Speed up the car a few times and print out the new state
            for (int i = 0; i < 15; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.ReadLine();*/

            // THIS IS CLASS MOTORCYCLE
            Motorcycle motor = new Motorcycle();
            motor.PopAWheely(); // there no in console
            Motorcycle motor2 = new Motorcycle(5);
            motor2.PopAWheely(); // there is 5 loopings
            motor2.SetDriverName("Sinta dan Jojo");
            Console.WriteLine("Rider name is {0} ", motor2.driverName); // Prints an empty name value
            Console.ReadLine();
        }
    }
}
