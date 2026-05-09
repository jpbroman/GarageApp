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
        Garage garage = new Garage(2);
        Vehicle vehicle1 = new Vehicle("Toyota", "Red","ABC123");
        Vehicle vehicle2 = new Vehicle("Honda", "Blue", "XYZ789");
        Vehicle vehicle3 = new Vehicle("Ford", "Green", "DEF456");
        garage.AddVehicle(vehicle1);
        garage.AddVehicle(vehicle2);
        Assert.False(garage.AddVehicle(vehicle3));
        garage.RemoveVehicle(vehicle1);
        Assert.True(garage.AddVehicle(vehicle3));
    }
}
