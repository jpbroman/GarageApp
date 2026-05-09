using System.Collections;

namespace GarageExercise;
public class Garage
{
    private Vehicle?[] Vehicles;
    public int numberOfVehicles { get ; private set; }
    public Garage(int availableSpace)
    {
        Vehicles = new Vehicle?[availableSpace];
        numberOfVehicles = 0;
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        // check if there is room for this vehicle. If not, print a message and return.
/*
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
        for (int i = 0; i < Vehicles.Length; i++)
        {
            if (Vehicles[i] == null)
            {
                Vehicles[i] = vehicle;
                numberOfVehicles++;
                return;
            }
        }
*/
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
