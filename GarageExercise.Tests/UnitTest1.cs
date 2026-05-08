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
        Vehicle vehicle = new Vehicle("Toyota", "Red", TypeE.Car, "ABC123");
        garage.AddVehicle(vehicle);
        Assert.Equal(1, garage.numberOfVehicles);
    }
}
