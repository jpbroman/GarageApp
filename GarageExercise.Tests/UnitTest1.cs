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
        Vehicle vehicle4 = new Motorcycle("GHI321", "Black", "Harley", Motorcycle.McTypeE.Sport);
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
}
