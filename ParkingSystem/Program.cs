using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using static ParkingSystem.Program;

namespace ParkingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            string plates = string.Empty;
            Console.Write("Enter your Plate : ");
            Console.WriteLine();
            plates = Console.ReadLine();
            string colors = string.Empty;
            Console.Write("Enter your color : ");
            colors = Console.ReadLine();
            string types = string.Empty;
            Console.Write("Enter your Type : ");
            Console.WriteLine();
            types = Console.ReadLine();
            */
            var parking = new ParkingSystem();
            parking.LotsParking();

            //var status = new Transportation();
            //status.Status();
            //status.Transportations();
        }
        public enum VechileType
        {
            Motor = 0,
            Car = 1,
            Truck = 2,
            Bus = 3
        }
        public enum ParkingSpotStatus
        {
            Occupied = 0,
            Vacant = 1
        }

    }
    public class ParkingLotsStatus
    {
        public int TotalParkingSpots { get; set; }
        public int OccupiedSpots { get; set; }
        public int FreeSpots { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public string TypeTransportation { get; set; }
    }
    public class ParkingSystem
    {
        //public List<ParkingLotsStatus> parkingLot { get; set; }
        //public List<PlateNumber> plateNumbers { get; set; }
        public void LotsParking()
        {
            List<ParkingLotsStatus> parkingLots = new List<ParkingLotsStatus>();
            //List<PlateNumber> plateNumber = new List<PlateNumber>();
            int totalSpots = new Random().Next(1, 15);
            int occ = 1;
            //parkingLots.OrderBy(x => x.TotalParkingSpots).Take(totalSpots);
            if(totalSpots < 6)
            {
                Console.WriteLine("Parkir Tutup");
            }
            else
            {
                parkingLots.Add(new ParkingLotsStatus { Plate = "B-1234-XYZ", Color = "White", TypeTransportation = "Car", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                parkingLots.Add(new ParkingLotsStatus { Plate = "B-9999-XYZ", Color = "White", TypeTransportation = "Motor", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                parkingLots.Add(new ParkingLotsStatus { Plate = "D-0001-HIJ", Color = "Black", TypeTransportation = "Car", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                parkingLots.Add(new ParkingLotsStatus { Plate = "B-7777-DEF", Color = "Red", TypeTransportation = "Car", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                parkingLots.Add(new ParkingLotsStatus { Plate = "B-2701-XXX", Color = "Blue", TypeTransportation = "Car", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                parkingLots.Add(new ParkingLotsStatus { Plate = "B-3141-ZZZ", Color = "Black", TypeTransportation = "Motor", TotalParkingSpots = totalSpots, OccupiedSpots = occ });
                Console.WriteLine("Created a parking lot with {0} slots", parkingLots.FirstOrDefault().TotalParkingSpots);
                Console.WriteLine();
                foreach (var parkingLotsStatus in parkingLots)
                {
                    parkingLotsStatus.OccupiedSpots = occ++;
                    parkingLotsStatus.FreeSpots = totalSpots - occ +1;
                }
                foreach (var item in parkingLots)
                {
                    Console.WriteLine("Parking {0} {1} {2} ", item.Plate, item.Color, item.TypeTransportation);
                    Console.WriteLine("Alocated slot number: {0}", item.OccupiedSpots);
                }
                Console.WriteLine();
                LeavePark(parkingLots);
                InputPlate(parkingLots);
                foreach (var item2 in parkingLots)
                {
                    if(item2.TypeTransportation == "Car")
                    {
                        item2.TotalParkingSpots.
                    }
                }
            }
            
        }
        public void LeavePark(List<ParkingLotsStatus> parkingSystems)
        {
            Console.Write("Leave Parking number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            parkingSystems.RemoveAt(n);
            Console.WriteLine($"Slot number  {n + 1} is free");
            Console.WriteLine();
            Console.WriteLine("Status Parking Right Now");
            Console.WriteLine();
            Console.WriteLine("Slot       No Plate.           Type       Registration No Colour");
            foreach (var item in parkingSystems)
            {

                Console.WriteLine("{0}        {1}            {2}             {3} ", item.OccupiedSpots, item.Plate, item.TypeTransportation, item.Color);
            }
        }
        public void InputPlate(List<ParkingLotsStatus> input)
        {
            Console.Write("Input Parking number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input plate number : ");
            string plate = Console.ReadLine();
            Console.WriteLine("Input color : ");
            string color = Console.ReadLine();
            Console.WriteLine("Input type transportation : ");
            string type = Console.ReadLine();

            input.Add(new ParkingLotsStatus { Plate = plate, Color = color, TypeTransportation = type, TotalParkingSpots = 6, OccupiedSpots = n + 1 });
            Console.WriteLine($"Allocated slot number : {input.ElementAt(2).OccupiedSpots + 1}");
            Console.WriteLine("Slot       No Plate.           Type       Registration No Colour");
            foreach (var item in input)
            {

                Console.WriteLine("{0}        {1}            {2}             {3} ", item.OccupiedSpots, item.Plate, item.TypeTransportation, item.Color);
            }
            Console.WriteLine();
            Console.Write("Input Parking number : ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input plate number : ");
            string plate1 = Console.ReadLine();
            Console.WriteLine("Input color : ");
            string color1 = Console.ReadLine();
            Console.WriteLine("Input type transportation : ");
            string type1 = Console.ReadLine();

            input.Add(new ParkingLotsStatus { Plate = plate1, Color = color1, TypeTransportation = type1, TotalParkingSpots = 6, OccupiedSpots = n1+2 });
            Console.WriteLine($"Park {input.ElementAt(6).Plate} {input.ElementAt(6).Color} {input.ElementAt(6).TypeTransportation}");
            Console.WriteLine("Sorry, Parking lot is full");
        }
        /*public void Type(List<ParkingLotsStatus> types)
        {
            if (types.ElementAt(1).TypeTransportation == "Car")
            {
                Console.WriteLine(types.ElementAt(1).TypeTransportation.Count());
            }
            else if (types.ElementAt(1).TypeTransportation == "Motor")
            {
                Console.WriteLine(types.ElementAt(2).TypeTransportation.Count());
            }
        }*/

    }

    
    public class PlateNumber
    {
        public string Plate { get; set; }
        public string Color { get; set; }
        public string TypeTransportation { get; set; }
        public int TotalParkingSpots { get; set; }
    }
    public class Transportation
    {
        public List<PlateNumber> plateNumbers { get; set; }
        public void Transportations()
        {
            string plates = string.Empty;
            Console.Write("Enter your Plate : ");
            Console.WriteLine();
            plates = Console.ReadLine();
            string colors = string.Empty;
            Console.Write("Enter your color : ");
            colors = Console.ReadLine();
            string types = string.Empty;
            Console.Write("Enter your Type : ");
            Console.WriteLine();
            types = Console.ReadLine();
            List<PlateNumber> plateNumbers = new List<PlateNumber>();
            plateNumbers.Add(new PlateNumber { Plate = plates, Color = colors, TypeTransportation = types });
            foreach (var item in plateNumbers)
            {
                item.Plate = plates;
                item.Color = colors;
                item.TypeTransportation = types;
                Console.WriteLine("Input Car : {0} {1} {2}", item.Plate, item.Color, item.TypeTransportation);
            }


        }
        public void Status()
        {
            List<PlateNumber> plateNumber = new List<PlateNumber>();
            plateNumber.Add(new PlateNumber { Plate = "B-1234-XYZ", Color = "White", TypeTransportation = "Car", TotalParkingSpots = 1 });
            plateNumber.Add(new PlateNumber { Plate = "B-9999-XYZ", Color = "White", TypeTransportation = "Motor", TotalParkingSpots = 2 });
            plateNumber.Add(new PlateNumber { Plate = "D-0001-HIJ", Color = "Black", TypeTransportation = "Car", TotalParkingSpots = 3 });
            plateNumber.Add(new PlateNumber { Plate = "B-7777-DEF", Color = "Red", TypeTransportation = "Car", TotalParkingSpots = 4 });
            plateNumber.Add(new PlateNumber { Plate = "B-2701-XXX", Color = "Blue", TypeTransportation = "Car", TotalParkingSpots = 5 });
            plateNumber.Add(new PlateNumber { Plate = "B-3141-ZZZ", Color = "Black", TypeTransportation = "Motor", TotalParkingSpots = 6 });
            Console.WriteLine("Slot       No.           Type       Registration No Colour");
            foreach (var item in plateNumber)
            {

                Console.WriteLine("{0}        {1}            {2}       {3}", item.TotalParkingSpots, item.Plate, item.TypeTransportation, item.Color);
            }
        }
    }
    public class ParkingFee
    {
        public decimal Fee { get; set; }
    }
}
