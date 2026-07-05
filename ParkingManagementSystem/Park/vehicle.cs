namespace Park;

public enum VehicleType
{
    Car,
    Bike,
    Truck
}

public abstract class Vehicle
{
    public string LicensePlate { get; set; }

    public VehicleType VehicleType { get; set;}

    protected Vehicle(string lp, VehicleType type)
    {
        LicensePlate = lp;
        VehicleType = type;
    }
}

public class Car : Vehicle
{
    public Car(string lp) : base(lp, VehicleType.Car)
    {
    }
}

public class Bike : Vehicle
{
    public Bike(string lp) : base(lp, VehicleType.Bike)
    {
    }
}

public class Truck : Vehicle
{
    public Truck(string lp) : base(lp, VehicleType.Truck)
    {
    }
}