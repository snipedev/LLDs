// See https://aka.ms/new-console-template for more information
using Park;

Console.WriteLine("Hello, World!");

var spot1 = new ParkingSpot(1, VehicleType.Car);
var spot2 = new ParkingSpot(2, VehicleType.Bike);
var spot3 = new ParkingSpot(3, VehicleType.Truck);
var spot4 = new ParkingSpot(4, VehicleType.Bike);
var spot5 = new ParkingSpot(5, VehicleType.Bike);
var spot6 = new ParkingSpot(6, VehicleType.Car);

var lot1 = new ParkingLot(1);
var lot2 = new ParkingLot(2);
var lot3 = new ParkingLot(3);

lot1.AddSpot(spot1);
lot1.AddSpot(spot2);
lot1.AddSpot(spot3);
lot1.AddSpot(spot4);
lot1.AddSpot(spot5);
lot1.AddSpot(spot6);


lot2.AddSpot(spot1);
lot2.AddSpot(spot2);
lot2.AddSpot(spot3);
lot2.AddSpot(spot4);
lot2.AddSpot(spot5);
lot2.AddSpot(spot6);

lot3.AddSpot(spot1);
lot3.AddSpot(spot2);
lot3.AddSpot(spot3);
lot3.AddSpot(spot4);
lot3.AddSpot(spot5);
lot3.AddSpot(spot6);

var parkingManagementSystem = new ParkingLotManager();

parkingManagementSystem.ParkingLots.Add(lot1);
parkingManagementSystem.ParkingLots.Add(lot2);
parkingManagementSystem.ParkingLots.Add(lot3);

var car1 = new Car("ABC123");
var bike1 = new Bike("BIKE123");
var truck1 = new Truck("TRUCK123");
var car2 = new Car("XYZ789");
var bike2 = new Bike("BIKE456");

var res = parkingManagementSystem.ParkVehicle(car1);


void DoPark()
{
    var res = parkingManagementSystem.ParkVehicle(car1);
    if(res)
{
    Console.WriteLine($"car {car1.LicensePlate} parked Successfully in {parkingManagementSystem.VehicleToSpotMapping[car1.LicensePlate].SpotNumber}");
}
else
{
    Console.WriteLine($"car {car1.LicensePlate} could not be parked.");
}
}

DoPark();

