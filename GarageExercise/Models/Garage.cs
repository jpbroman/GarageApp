using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.Marshalling;
using System.Globalization; 
using System.Reflection;
using System.Text;

namespace GarageExercise;
public class Garage
{
    private Vehicle?[] Vehicles { get; set; }
    public int numberOfVehicles { get ; private set; }
    public Garage(int availableSpace)
    {
        Vehicles = new Vehicle?[availableSpace];
        numberOfVehicles = 0;
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        if (checkRegNumberExists(vehicle.RegNumber))
        {
            Console.WriteLine("A vehicle with this registration number already exists. They must be unique.");
            return false;
        }
        int i = Array.IndexOf(Vehicles, null);
        if (i >= 0)        {
            Vehicles[i] = vehicle;
            numberOfVehicles++;
            Console.WriteLine($"Vehicle added: {vehicle}");
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
            Console.WriteLine($"Vehicle removed: {GetObjectData(vehicle)}");
        }
        else
        {
            Console.WriteLine("Vehicle not found in the garage.");
        }
    }
    public Vehicle?[] GetVehicles()
    {
        return Vehicles;
    }
    public void ListVehicles(Type? t = null)
    {
        Console.WriteLine($"Number of vehicles in the garage: {numberOfVehicles}");
        foreach (var vehicle in Vehicles)
        {
            Type? type = vehicle?.GetType();
            if (vehicle != null)
            {
                if (t == null || type == t)
                {
                    Console.WriteLine(GetObjectData(vehicle));
                }               
            }
        }
    }
    public void ListVehiclesByProperties(Vehicle.VehicleTypeE vehicleType, string? make, string ?color)
    {
        Console.WriteLine($"Number of vehicles in the garage: {numberOfVehicles}");

        foreach (var vehicle in Vehicles)
        {
            if (vehicle != null)
            {
                Type type2 = vehicle.GetType();
                if ((vehicleType == Vehicle.VehicleTypeE.Unknown || vehicle.Type == vehicleType) &&
                    (string.IsNullOrEmpty(make) || vehicle.Make.Equals(make, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(color) || vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)))
                {
                    String vehicleData = GetObjectData(vehicle);
                    Console.WriteLine(vehicleData);
                }

            }
        }
    }
    public void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var vehicle in Vehicles)
                {
                    if (vehicle != null)
                    {
                        writer.WriteLine(vehicle.ToString());
                    }
                }
            }
            Console.WriteLine($"Inventory saved to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
    public void LoadFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine($"File contains {lines.Length} vehicles.");
            if (Vehicles.Length < lines.Length)
            {
                Console.WriteLine("File contains more vehicles than the garage can hold. Building a bigger garage.");
                Vehicles = new Vehicle?[lines.Length+10];
            }
            numberOfVehicles = 0;
            foreach (var line in lines)
            {
                // This is a very basic parsing logic and should be improved for a real application
                string[] parts = line.Split(':');
                if (parts.Length > 1)
                {
                    string typePart = parts[0].Trim();
                    string dataPart = parts[1].Trim();
                    Vehicle? vehicle = VehicleFactory.CreateVehicleFromData(typePart, dataPart);
                    if (vehicle != null)
                    {
                        if (!AddVehicle(vehicle))
                        {
                            Console.WriteLine("Failed to add vehicle  {vehicle}.");
                        }
                    }
                }
            }
            Console.WriteLine($"Inventory loaded from {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
    public string  GetObjectData(object obj)
    {
        Type type = obj.GetType();
        var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static| BindingFlags.Instance);
        StringBuilder sb = new StringBuilder();
        foreach (var prop in properties)
        {
            sb.Append($"{prop.Name}: {prop.GetValue(obj)}, ");
        }
        return sb.ToString().TrimEnd(',', ' ');
    }

    private bool checkRegNumberExists(string regNumber)
    {
       foreach (Vehicle? v in Vehicles)
        {
            if (v != null && v.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
