namespace ParkingManagementSystem;

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

    private Dictionary<string, ParkingSpot> _vehicleSpotMap = new Dictionary<string, ParkingSpot>();

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
                _vehicleSpotMap[vehicle.LicensePlate] = availableSpot;
                return availableSpot;
            }
        }
        return null; // No available spot found
    }

    public bool RemoveVehicle(string LicensePlate)
    {
        if (!_vehicleSpotMap.TryGetValue(licensePlate, out ParkingSpot spot))
        return false;

    if (!spot.RemoveVehicle())
        return false;

    _vehicleSpotMap.Remove(licensePlate);

    return true;
    }
}

    
