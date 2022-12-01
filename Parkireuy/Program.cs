using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Parkireuy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fajar");
            var parkingLotCore = new ParkingLotCore();
        }
        public interface IParkingLot
        {
            int FreeSpots { get; }
            bool ParkVechile(Vehicle vehicle, ParkingSpot parkingSpot);
            bool UnParkVechile(Vehicle vehicle);
            ParkingSpot GetParkingSpot(Vehicle vehicle);
            ParkingSpotStatus GetParkingSpotStatus(ParkingSpot parkingSpot);
        }
        public interface IParkingSpaceMapper
        {
            ParkingSpaceRequirment GetParkingSpaceRequirment(Vehicle vehicle);
        }
        public enum ParkingSpotStatus
        {
            Occupied = 0,
            Vacant = 1
        }
        public enum ParkingSpotTypes
        {
            Motorcycle = 0,
            Compact = 1,
            Large = 2
        }
        public enum VehicleTypes
        {
            MotorCycle = 0,
            Car = 1,
            Bus = 2,
            Truck = 3
        }

        public class ParkingLotStatus
        {
            public int TotalParkingSpots { get; set; }
            public int OccupiedSpots { get; set; }
            public int FreeSpots { get; set; }
        }
        public class ParkingSpaceRequirment
        {
            public ParkingSpotTypes ParkingSpot { get; set; }
            public int ParkingSpotsCount { get; set; }
        }
        public class ParkingSpot
        {
            public int Floor { get; set; }
            public int Row { get; set; }
            public int StartPosition { get; set; }
            public int SpotCount { get; set; }
            public ParkingSpotTypes ParkingSpotTypes { get; set; }
        }
        public class Vehicle
        {
            public string VehicleNumber { get; set; }
            public VehicleTypes vehicleType { get; set; }
        }
        public class ParkingLotCore : IParkingLot
        {
            public int _freeSpots = 0;
            public int FreeSpots => _freeSpots;
            public int _totalSpots = 0;
            public int TotalSpots => _totalSpots;
            private ImmutableSortedSet<ParkingSpot> freeParkingSpots;
            private ConcurrentDictionary<string, ParkingSpot> parkedVehicles;
            private readonly IEnumerable<List<List<ParkingSpot>>> parkingLotLayout;
            private readonly IParkingSpaceMapper parkingSpaceMapper;

            public ParkingLotCore(int freeSpots, int totalSpots, IEnumerable<List<List<ParkingSpot>>> parkingLot, IParkingSpaceMapper parkingSpaceMapper)
            {
                _freeSpots = freeSpots;
                _totalSpots = totalSpots;
                var comparer = Comparer<ParkingSpot>.Create((x, y) =>
               x.Floor == y.Floor ?
                   x.Row == y.Row ?
                       x.StartPosition.CompareTo(y.StartPosition)
                       : x.Row.CompareTo(y.Row)
                   : x.Floor.CompareTo(y.Floor)
                );
                freeParkingSpots = ImmutableSortedSet.Create<ParkingSpot>(comparer);
                parkedVehicles = new ConcurrentDictionary<string, ParkingSpot>();
                this.parkingLotLayout = parkingLotLayout;
                this.parkingSpaceMapper = parkingSpaceMapper;
                InitializeParkingLot();
            }
            private void InitializeParkingLot()
            {
                foreach (var floor in parkingLotLayout)
                {
                    foreach (var row in floor)
                    {
                        foreach (var spot in row)
                        {
                            freeParkingSpots = freeParkingSpots.Add(spot);
                            Interlocked.Add(ref _totalSpots, spot.SpotCount);
                            Interlocked.Add(ref _freeSpots, spot.SpotCount);
                        }
                    }
                }
            }

            public ParkingSpot GetParkingSpot(Vehicle vehicle)
            {
                ParkingSpaceRequirment requiredSpace = parkingSpaceMapper.GetParkingSpaceRequirment(vehicle);
                var vacantSpot = freeParkingSpots.FirstOrDefault(m => m.ParkingSpotTypes >= requiredSpace.ParkingSpot
                && m.SpotCount >= requiredSpace.ParkingSpotsCount
                );
                if (vacantSpot != null)
                {
                    vacantSpot.SpotCount = Math.Min(vacantSpot.SpotCount, requiredSpace.ParkingSpotsCount);
                }
                return vacantSpot;
            }

            public ParkingSpotStatus GetParkingSpotStatus(ParkingSpot parkingSpot)
            {
                var rightSpot = freeParkingSpots.FirstOrDefault(spot => spot.Floor == parkingSpot.Floor
             && spot.Row == parkingSpot.Row
             && spot.ParkingSpotTypes == parkingSpot.ParkingSpotTypes
             && spot.StartPosition <= parkingSpot.StartPosition
             && spot.StartPosition + spot.SpotCount >= parkingSpot.SpotCount + parkingSpot.StartPosition
            );
                if (rightSpot != null)
                {
                    return ParkingSpotStatus.Vacant;
                }
                return ParkingSpotStatus.Occupied;
            }

            public bool ParkVechile(Vehicle vehicle, ParkingSpot parkingSpot)
            {
                if (parkedVehicles.ContainsKey(vehicle.VehicleNumber))
                {
                    throw new InvalidOperationException($"Vehicle with number {vehicle.VehicleNumber} is already parked");
                }
                ParkingSpot vacantSpot = freeParkingSpots.FirstOrDefault(spot => spot.Floor == parkingSpot.Floor
                && spot.Row == parkingSpot.Row
                && spot.ParkingSpotTypes == parkingSpot.ParkingSpotTypes
                && spot.StartPosition <= parkingSpot.StartPosition
                && spot.SpotCount >= parkingSpot.SpotCount
                 );
                if (vacantSpot == null)
                    throw new KeyNotFoundException("The spot could not be found");

                freeParkingSpots = freeParkingSpots.Remove(vacantSpot);
                parkedVehicles.TryAdd(vehicle.VehicleNumber, parkingSpot);
                if (parkingSpot.StartPosition > vacantSpot.StartPosition)
                {
                    var newSpot = new ParkingSpot() { Floor = vacantSpot.Floor, ParkingSpotTypes = vacantSpot.ParkingSpotTypes, Row = vacantSpot.Row, StartPosition = vacantSpot.StartPosition };
                    newSpot.SpotCount = parkingSpot.StartPosition - vacantSpot.StartPosition;
                    freeParkingSpots = freeParkingSpots.Add(newSpot);
                }
                if (vacantSpot.SpotCount > parkingSpot.SpotCount)
                {
                    var newSpot = new ParkingSpot() { Floor = vacantSpot.Floor, ParkingSpotTypes = vacantSpot.ParkingSpotTypes, Row = vacantSpot.Row };
                    newSpot.StartPosition = parkingSpot.StartPosition + parkingSpot.SpotCount;
                    newSpot.SpotCount = vacantSpot.SpotCount - newSpot.StartPosition + 1;
                    freeParkingSpots = freeParkingSpots.Add(newSpot);
                }
                Interlocked.Add(ref _freeSpots, parkingSpot.SpotCount * -1);
                return true;
            }

            public bool UnParkVechile(Vehicle vehicle)
            {
                parkedVehicles.TryRemove(vehicle.VehicleNumber, out ParkingSpot currentSpot);
                if (currentSpot == null)
                    throw new ArgumentException($"vehicle {vehicle.VehicleNumber} is not parked");

                var leftSpot = freeParkingSpots.FirstOrDefault(spot => spot.Floor == currentSpot.Floor
                 && spot.Row == currentSpot.Row
                 && spot.ParkingSpotTypes == currentSpot.ParkingSpotTypes
                 && spot.StartPosition + spot.SpotCount == currentSpot.StartPosition
                );
                ParkingSpot newSpotToUpdate = new ParkingSpot() { Floor = currentSpot.Floor, ParkingSpotTypes = currentSpot.ParkingSpotTypes, Row = currentSpot.Row, StartPosition = currentSpot.StartPosition, SpotCount = currentSpot.SpotCount };
                if (leftSpot != null)
                {
                    newSpotToUpdate.StartPosition = leftSpot.StartPosition;
                    newSpotToUpdate.SpotCount = currentSpot.SpotCount + leftSpot.SpotCount;
                    freeParkingSpots = freeParkingSpots.Remove(leftSpot);
                }
                var rightSpot = freeParkingSpots.FirstOrDefault(spot => spot.Floor == currentSpot.Floor
                 && spot.Row == currentSpot.Row
                 && spot.ParkingSpotTypes == currentSpot.ParkingSpotTypes
                 && spot.StartPosition == currentSpot.StartPosition + currentSpot.SpotCount
                );

                if (rightSpot != null)
                {
                    newSpotToUpdate.SpotCount = newSpotToUpdate.SpotCount + rightSpot.SpotCount;
                    freeParkingSpots = freeParkingSpots.Remove(rightSpot);
                }
                freeParkingSpots = freeParkingSpots.Add(newSpotToUpdate);
                return true;
            }
        }
        public class ParkingSpaceMapper : IParkingSpaceMapper
        {
            public ParkingSpaceRequirment GetParkingSpaceRequirment(Vehicle vehicle)
            {
                switch (vehicle.vehicleType)
                {
                    case VehicleTypes.MotorCycle:
                        return new ParkingSpaceRequirment() { ParkingSpot = ParkingSpotTypes.Motorcycle, ParkingSpotsCount = 1 };
                    case VehicleTypes.Car:
                        return new ParkingSpaceRequirment() { ParkingSpot = ParkingSpotTypes.Compact, ParkingSpotsCount = 1 };
                    case VehicleTypes.Bus:
                        return new ParkingSpaceRequirment() { ParkingSpot = ParkingSpotTypes.Large, ParkingSpotsCount = 5 };
                    default:
                        throw new ArgumentException($"vehicleType {vehicle.vehicleType} is invalid.");
                }
            }
        }

    }
}
