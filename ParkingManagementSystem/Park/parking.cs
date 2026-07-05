namespace Park;

#region parking spot and parking lot classes
public class ParkingSpot
{
    public int SpotNumber { get; set; }
    public VehicleType SpotType { get; set; }
    public bool IsOccupied { get; set; }
    public Vehicle? OccupyingVehicle { get; set; }

    public ParkingSpot(int spotNumber, VehicleType spotType)
    {
        SpotNumber = spotNumber;
        SpotType = spotType;
        IsOccupied = false;
        OccupyingVehicle = null;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (IsOccupied || vehicle.VehicleType != SpotType)
        {
            return false;
        }

        OccupyingVehicle = vehicle;
        IsOccupied = true;
        return true;
    }

    public bool RemoveVehicle()
    {
        if (!IsOccupied)
        {
            return false;
        }

        OccupyingVehicle = null;
        IsOccupied = false;
        return true;
    }
}

public class ParkingLot
{
    public int LotNumber { get;}
    public List<ParkingSpot> Spots { get; set; }

    public ParkingLot(int lotNumber)
    {
        LotNumber = lotNumber;
        Spots = new List<ParkingSpot>();
    }

    public void AddSpot(ParkingSpot spot)
    {
        Spots.Add(spot);
    }

    public ParkingSpot? FindAvailableSpot(VehicleType vehicleType)
    {
        return Spots.FirstOrDefault(spot => !spot.IsOccupied && spot.SpotType == vehicleType);
    }

    //add spot can be implemented later
}
#endregion

public class ParkingLotManager
{
    public List<ParkingLot> ParkingLots { get; set; }

    public Dictionary<string,ParkingSpot> VehicleToSpotMapping { get; set; }

    public ParkingLotManager()
    {
        ParkingLots = new List<ParkingLot>();
        VehicleToSpotMapping = new Dictionary<string,ParkingSpot>();
    }

    public void addParkingLot(ParkingLot lot)
    {
        ParkingLots.Add(lot);
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        foreach (var lot in ParkingLots)
        {
            var availableSpot = lot.FindAvailableSpot(vehicle.VehicleType);
            if (availableSpot != null)
            {
                if (availableSpot.ParkVehicle(vehicle))
                {
                    VehicleToSpotMapping[vehicle.LicensePlate] = availableSpot;
                    return true;
                }
            }
        }
        return false; // No available spot found
    }

    public bool RemoveVehicle(string licensePlate)
    {
        if (VehicleToSpotMapping.TryGetValue(licensePlate, out ParkingSpot? spot))
        {
            if(spot==null)
            {
                return false;
            }
            spot.RemoveVehicle();
            VehicleToSpotMapping.Remove(licensePlate);
            return true;
        }
        
        return false; // Vehicle not found
    }



}