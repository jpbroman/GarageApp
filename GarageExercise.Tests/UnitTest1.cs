using System;
using System.Reflection.Metadata;
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
        Vehicle vehicle = new Vehicle(Vehicle.VehicleTypeE.Car, "Toyota", "Red", "ABC123");
        Assert.True(garage.AddVehicle(vehicle));
        Assert.Equal(1, garage.numberOfVehicles);
    }

    [Fact]
    public void TestRemoveVehicle()
    {
        Garage garage = new Garage(5);
        Vehicle vehicle = new Vehicle(Vehicle.VehicleTypeE.Car, "Toyota", "Red", "ABC123");
        garage.AddVehicle(vehicle);
        Assert.Equal(1, garage.numberOfVehicles);
        garage.RemoveVehicle(vehicle);
        Assert.Equal(0, garage.numberOfVehicles);
    }

    [Fact]
    public void TestAddTooManyVehicles()
    {
        Garage garage = new Garage(3);
        Vehicle vehicle1 = new Vehicle(Vehicle.VehicleTypeE.Car, "Toyota", "Red", "ABC123");
        Vehicle vehicle2 = new Vehicle(Vehicle.VehicleTypeE.Car, "Honda", "Blue", "XYZ789");
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
        Vehicle vehicle1 = new Vehicle(Vehicle.VehicleTypeE.Car, "Toyota", "Red", "ABC123");
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
        Assert.Contains("Make: Toyota, Color: Red, RegNumber: ABC123", result);
        Assert.Contains("Make: Honda, Color: Blue, RegNumber: XYZ789", result);
        Assert.Contains("Make: Haeley, Color: Black, RegNumber: POI123", result);
        Assert.Contains("Make: Boeing, Color: White, RegNumber: JKL012", result);
        Assert.Contains("Make: Volvo, Color: Yellow, RegNumber: MNO345", result);
        Assert.Contains("Make: Yamaha, Color: Blue, RegNumber: PQR678", result);
    }

    [Fact]
    public void TestGetObjectData()
    {
        Garage garage = new Garage(5);
        Vehicle vehicle = new Car("Honda", "Blue", "XYZ789", Car.CarTypeE.SUV, Car.TransmissionE.Manual);
        string result = garage.GetObjectData(vehicle);
        Assert.Contains("Make: Honda", result);
        Assert.Contains("Color: Blue", result);
        Assert.Contains("RegNumber: XYZ789", result);
        vehicle = new Motorcycle("Haeley", "Black", "POI123", Motorcycle.McTypeE.Cruiser, Motorcycle.EngineTypeE.FourStroke);
        result = garage.GetObjectData(vehicle);
        Assert.Contains("Make: Haeley", result);
        Assert.Contains("Color: Black", result);    
        Assert.Contains("RegNumber: POI123", result);
    }

    [Fact]
    public void TestSaveToFile()
    {
        Garage garage = new Garage(5);
        Vehicle vehicle1 = new Car("Honda", "Blue", "XYZ789", Car.CarTypeE.SUV, Car.TransmissionE.Manual);
        Vehicle vehicle2 = new Car("Skoda", "Red", "ABC123", Car.CarTypeE.Sedan, Car.TransmissionE.Automatic);
        garage.AddVehicle(vehicle1);
        garage.AddVehicle(vehicle2);

        string filePath = "test_garage.txt";
        garage.SaveToFile(filePath);
        Assert.True(File.Exists(filePath));
        string content = File.ReadAllText(filePath);
    }

    [Fact]
    public void TestLoadFromFile()
    {
        Garage garage = new Garage(5);
        string filePath = "test_garage.txt";
        File.WriteAllText(filePath, "Car: Honda, Blue, XYZ789, SUV, Manual\nCar: Skoda, Red, ABC123, Sedan, Automatic\n");
        garage.LoadFromFile(filePath);
        Assert.Equal(2, garage.numberOfVehicles);
        var vehicles = garage.GetVehicles();
        Assert.Contains(vehicles, v => v != null && v.RegNumber == "ABC123");
        Assert.Contains(vehicles, v => v != null && v.RegNumber == "XYZ789");
    }
    [Fact]
    public void TestListVehiclesByProperties()
    {
        Garage garage = new Garage(7);
        Vehicle vehicle1 = new Car("Honda", "Blue", "XYZ789", Car.CarTypeE.SUV, Car.TransmissionE.Manual);
        Vehicle vehicle2 = new Boat("Flipper", "Red", "ABC123", Boat.BoatTypeE.Sailboat, 30);
        garage.AddVehicle(vehicle1);
        garage.AddVehicle(vehicle2);

        var sw = new StringWriter();  // redirect stdout from class under test
        Console.SetOut(sw);
        // Find all red vehicles regardless of type or make
        garage.ListVehiclesByProperties(Vehicle.VehicleTypeE.Unknown, null, "Red");
        string result = sw.ToString();

        sw.GetStringBuilder().Clear(); // clear output for next test
        garage.ListVehiclesByProperties(Vehicle.VehicleTypeE.Car, null, null);
        result = sw.ToString();
        Assert.Contains("Make: Honda, Color: Blue, RegNumber: XYZ789", result);
        Assert.DoesNotContain("Make: Flipper, Color: Red, RegNumber: ABC123", result);

        garage.AddVehicle(new Car("Honda", "Black", "AEF456", Car.CarTypeE.Hatchback, Car.TransmissionE.Automatic));
        garage.AddVehicle(new Airplane("Flyer2", "Blue", "POI234", Airplane.AirplaneTypeE.Private, 2, 4));
        sw.GetStringBuilder().Clear(); // clear output for next test
        garage.ListVehiclesByProperties(Vehicle.VehicleTypeE.Unknown, "Honda", "Black");
        result = sw.ToString();
        Assert.Contains("Make: Honda, Color: Black, RegNumber: AEF456", result);
        Assert.DoesNotContain("Make: Honda, Color: Blue, RegNumber: XYZ789", result);
        Assert.DoesNotContain("Make: Flyer2, Color: Blue, RegNumber: POI234", result);

        // All Blue vehicles regardless of type or make
        garage.AddVehicle(new Motorcycle("Harley", "Blue", "QWE567", Motorcycle.McTypeE.Cruiser, Motorcycle.EngineTypeE.FourStroke));
        sw.GetStringBuilder().Clear(); // clear output for next test
        garage.ListVehiclesByProperties(Vehicle.VehicleTypeE.Unknown, null, "Blue");
        result = sw.ToString();
        Assert.Contains("Make: Honda, Color: Blue, RegNumber: XYZ789", result);
        Assert.Contains("Make: Flyer2, Color: Blue, RegNumber: POI234", result);
        Assert.Contains("Make: Harley, Color: Blue, RegNumber: QWE567", result);
        Assert.DoesNotContain("Make: Honda, Color: Black, RegNumber: AEF456", result);
    }
}
