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
