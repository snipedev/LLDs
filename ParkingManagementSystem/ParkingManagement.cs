namespace ParkingManagementSystem;
    public enum VehicleType
    {
        Car,
        Motorcycle,
        Truck
    }
    public abstract class Vehicle
    {
        public string LicensePlate { get; }
        public VehicleType VehicleType { get; }

        protected Vehicle(string licensePlate, VehicleType vehicleType)
        {
            LicensePlate = licensePlate;
            VehicleType = vehicleType;
        }
    }

    public class Car : Vehicle
    {
        public Car(string licensePlate) : base(licensePlate, VehicleType.Car)
        {
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(string licensePlate) : base(licensePlate, VehicleType.Motorcycle)
        {
        }
    }

    public class Truck : Vehicle
    {
        public Truck(string licensePlate) : base(licensePlate, VehicleType.Truck)
        {
        }
    }

    /******************************************************************************/

    // Parking Spot class

    /// <summary>
    /// Represents a parking spot in the parking lot.
    /// </summary>
    public class ParkingSpot
    {
        public int SpotNumber { get; }
        public VehicleType VehicleType { get; }
        public bool IsOccupied { get; private set; }
        public Vehicle ParkedVehicle { get; private set; }

        public ParkingSpot(int spotNumber, VehicleType vehicleType)
        {
            SpotNumber = spotNumber;
            VehicleType = vehicleType;
            IsOccupied = false;
            ParkedVehicle = null;
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            if (IsOccupied || vehicle.VehicleType != VehicleType)
            {
                return false;
            }

            ParkedVehicle = vehicle;
            IsOccupied = true;
            return true;
        }

        public bool RemoveVehicle()
        {
            if (!IsOccupied)
            {
                return false;
            }

            ParkedVehicle = null;
            IsOccupied = false;
            return true;
        }
    }

public class ParkingLot
{
    public int LotNumber { get;}
    public IList<ParkingSpot> ParkingSpots { get; } = new List<ParkingSpot>();

    public ParkingLot()
    {
        LotNumber = new Random().Next(1000, 9999); // Generate a random lot number
    }

    public void AddParkingSpot(ParkingSpot spot)
    {
        ParkingSpots.Add(spot);
    }

    //removal is not needed as we can just mark the spot as unoccupied when a vehicle leaves

    public ParkingSpot FindAvailableSpot(VehicleType vehicleType)
    {
        return ParkingSpots.FirstOrDefault(spot => !spot.IsOccupied && spot.VehicleType == vehicleType);
    }
}

public class ParkingLotManager
{
    private readonly IList<ParkingLot> _parkingLots = new List<ParkingLot>();

    public void AddParkingLot(ParkingLot lot)
    {
        _parkingLots.Add(lot);
    }

    public ParkingSpot ParkVehicle(Vehicle vehicle)
    {
        foreach (var lot in _parkingLots)
        {
            var availableSpot = lot.FindAvailableSpot(vehicle.VehicleType);
            if (availableSpot != null && availableSpot.ParkVehicle(vehicle))
            {
                return availableSpot;
            }
        }
        return null; // No available spot found
    }

    public bool RemoveVehicle(Vehicle vehicle)
    {
        foreach (var lot in _parkingLots)
        {
            var spot = lot.ParkingSpots.FirstOrDefault(s => s.ParkedVehicle.licensePlate == vehicle.licensePlate);
            if (spot != null && spot.RemoveVehicle())
            {
                return true;
            }
        }
        return false; // Vehicle not found in any parking lot
    }
}

    
