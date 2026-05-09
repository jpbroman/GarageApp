using System;
[assembly: CaptureConsole]

namespace GarageExercise.Tests;

public class UnitTest1
{
    [Fact]
    public void TestCreateGarage()
    {
        Garage garage = new Garage(5);
        Assert.NotNull(garage);
    }

    [Fact]
    public void TestAddVehicle()
    {
        Garage garage = new Garage(5);
        Vehicle vehicle = new Vehicle("Toyota", "Red", "ABC123");
        Assert.True(garage.AddVehicle(vehicle));
        Assert.Equal(1, garage.numberOfVehicles);
    }

    [Fact]
    public void TestRemoveVehicle()
    {
        Garage garage = new Garage(5);
        Vehicle vehicle = new Vehicle("Toyota", "Red", "ABC123");
        garage.AddVehicle(vehicle);
        Assert.Equal(1, garage.numberOfVehicles);
        garage.RemoveVehicle(vehicle);
        Assert.Equal(0, garage.numberOfVehicles);
    }

    [Fact]
    public void TestAddTooManyVehicles()
    {
        Garage garage = new Garage(3);
        Vehicle vehicle1 = new Vehicle("Toyota", "Red","ABC123");
        Vehicle vehicle2 = new Vehicle("Honda", "Blue", "XYZ789");
        Vehicle vehicle3 = new Car("Ford", "Green", "DEF456", Car.CarTypeE.Sedan, Car.TransmissionE.Automatic);
        Vehicle vehicle4 = new Motorcycle("GHI321", "Black", "Harley", Motorcycle.McTypeE.Cruiser, Motorcycle.EngineTypeE.FourStroke);  
        Vehicle vehicle5 = new Bus("Volvo", "Yellow", "JKL012", Bus.BusTypeE.City, 50);
        garage.AddVehicle(vehicle1);
        garage.AddVehicle(vehicle2);
        garage.AddVehicle(vehicle3);
        Assert.False(garage.AddVehicle(vehicle4));
        garage.RemoveVehicle(vehicle2);
        Assert.True(garage.AddVehicle(vehicle4));
        Assert.False(garage.AddVehicle(vehicle5));
        garage.RemoveVehicle(vehicle1);
        Assert.True(garage.AddVehicle(vehicle5));
    }
    
    [Fact]
    public void TestListVehicles()
    {
        Garage garage = new Garage(10);
        Vehicle vehicle1 = new Vehicle("Toyota", "Red", "ABC123");
        Vehicle vehicle2 = new Car("Honda", "Blue", "XYZ789", Car.CarTypeE.SUV, Car.TransmissionE.Manual);
        Vehicle vehicle3 = new Motorcycle("Haeley", "Black", "POI123", Motorcycle.McTypeE.Cruiser, Motorcycle.EngineTypeE.FourStroke);
        Vehicle vehicle4 = new Airplane("Boeing", "White", "JKL012", Airplane.AirplaneTypeE.Commercial, 4, 200);
        Vehicle vehicle5 = new Bus("Volvo", "Yellow", "MNO345", Bus.BusTypeE.City, 50);
        Vehicle vehicle6 = new Boat("Yamaha", "Blue", "PQR678", Boat.BoatTypeE.Sailboat, 30);
        garage.AddVehicle(vehicle1);
        garage.AddVehicle(vehicle2);
        garage.AddVehicle(vehicle3);
        garage.AddVehicle(vehicle4);
        garage.AddVehicle(vehicle5);
        garage.AddVehicle(vehicle6);

        var sw = new StringWriter();  // redirect stdout from class under test
        Console.SetOut(sw);
        garage.ListVehicles();
        string result = sw.ToString();

        Assert.Contains("Toyota, Red, ABC123", result);
        Assert.Contains("Honda, Blue, XYZ789, SUV, Manual", result);
        Assert.Contains("Haeley, Black, POI123, Cruiser, FourStroke", result);
        Assert.Contains("Boeing, White, JKL012, Commercial, 4 engines, 200 seats", result);
        Assert.Contains("Volvo, Yellow, MNO345, City, 50", result);
        Assert.Contains("Yamaha, Blue, PQR678, Sailboat, 30", result);
    }

}
