using System.Collections;

namespace GarageExercise;
public class Garage
{
    private Vehicle?[] Vehicles { get; }
    public int numberOfVehicles { get ; private set; }
    public Garage(int availableSpace)
    {
        Vehicles = new Vehicle?[availableSpace];
        numberOfVehicles = 0;
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        int i = Array.IndexOf(Vehicles, null);
        if (i >= 0)        {
            Vehicles[i] = vehicle;
            numberOfVehicles++;
            return true;
        }
        else {       
            Console.WriteLine("No room for this vehicle in the garage.");
        }
        return false;
    }
    public void RemoveVehicle(Vehicle vehicle)
    {
        int i = Array.IndexOf(Vehicles, vehicle);
        if (i >= 0)        {
            Vehicles[i] = null;
            numberOfVehicles--;
        }
        else
        {
            Console.WriteLine("Vehicle not found in the garage.");
        }
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
