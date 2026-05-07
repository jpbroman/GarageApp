using System.Collections;

namespace GarageExercise;
public class Garage
{
    private Array[] Vehicles { get; set; }

    public Garage(int numberOfVehicles)
    {
        Vehicles = new Vehicle[numberOfVehicles];
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
    }

    public void ListVehicles()
    {
        Console.WriteLine("Vehicles in the garage:");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }
}
