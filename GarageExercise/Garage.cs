using System.Collections;

namespace GarageExercise;
public class Garage
{
    private Vehicle[] Vehicles;
    public int numberOfVehicles { get ; private set; }
    public Garage(int availableSpace)
    {
        Vehicles = new Vehicle[availableSpace];
        numberOfVehicles = 0;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        // check if there is room for this vehicle. If not, print a message and return.
        if (numberOfVehicles < Vehicles.Length)
        {
            Vehicles[numberOfVehicles] = vehicle;
            numberOfVehicles++;
        }
        else
        {
            Console.WriteLine("No room for this vehicle in the garage.");
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        // TODO. Implement this method.
    }

    public void ListVehicles()
    {
        Console.WriteLine("Vehicles in the garage:");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine((vehicle != null) ? vehicle.ToString() : "Empty slot");
        }
    }
}
