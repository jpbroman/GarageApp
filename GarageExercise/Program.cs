namespace GarageExercise;

public class Program
{
    private static string MainMenu = "1. Add a vehicle\n2. Remove a vehicle\n3. Display garage contents\n" +
         "4. Save inventory to file\n5. Load inventory from file\n0. Exit";
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Garage Management System!");
        int numberOfVehicles = 0;
        if (args.Length >= 1 && int.TryParse(args[0], out numberOfVehicles))
        {
            Console.WriteLine($"Number of vehicles: {numberOfVehicles}");
        }
        else
        {
            Console.WriteLine("Enter the number of vehicles the garage can hold:");
            while (!int.TryParse(Console.ReadLine(), out numberOfVehicles))
            {
                Console.WriteLine("Enter a valid integer for the number of vehicles:");
            }
        }

        Garage garage = new Garage(numberOfVehicles);
        Console.WriteLine($"Garage created with room for {numberOfVehicles} vehicles.");

        if (args.Length == 2)
        {
            Console.WriteLine($"Populating garage from file: {args[1]}");
            garage.LoadFromFile(args[1]);
        }

        // Main menu loop
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine(MainMenu);
            string choice = Utils.SafeInput("Enter your choice: ");
            switch (choice)
            {
                case "1":
                    // Add a vehicle
                    string type = Utils.SafeInput("Enter vehicle type (Car/Motorcycle/Bus/Airplane/Boat): ");
                    Vehicle vehicle = VehicleFactory.CreateVehicle(type);
                    garage.AddVehicle(vehicle);
                    break;
                case "2":
                    // Remove a vehicle
                    string regNumToRemove = Utils.SafeInput("Enter registration number of the vehicle to remove: ");
                    Vehicle? vehicleToRemove = null;
                    foreach (var v in garage.GetVehicles())
                    {
                        if (v != null && v.RegNumber.Equals(regNumToRemove, StringComparison.OrdinalIgnoreCase))
                        {
                            vehicleToRemove = v;
                            break;
                        }
                    }
                    if (vehicleToRemove != null)
                    {
                        garage.RemoveVehicle(vehicleToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Vehicle not found.");
                    } 
                    break;         
                case "3":
                    // Display vehicles in the garage
                    string? vehicleType = Utils.SafeInput("Press Enter to display all vehicles or enter a specific type (Car/Motorcycle/Bus/Airplane/Boat): ");
                    if (vehicleType == "" || vehicleType == null)
                    {
                        garage.ListVehicles();
                    }
                    else
                    {
                        // Normalize input to match class names
                        vehicleType = char.ToUpper(vehicleType[0]) + vehicleType.Substring(1).ToLower(); 
                        Type? classType = Type.GetType($"GarageExercise.{vehicleType}");
                        if (classType != null)
                        {
                            garage.ListVehicles(classType);
                        }
                        else
                        {
                            Console.WriteLine("Invalid vehicle type.");
                        }
                    }
                    break;
                case "4":
                    // Save inventory to file
                    string filePath = Utils.SafeInput("Enter file path to save inventory: ");
                    garage.SaveToFile(filePath);
                    break;
                case "5":
                    // Load inventory from file
                    filePath = Utils.SafeInput("Enter file path to load inventory: ");
                    garage.LoadFromFile(filePath);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}



