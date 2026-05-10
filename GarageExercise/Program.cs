namespace GarageExercise;

public class Program
{
    private static string MainMenu = "1. Add a vehicle\n2. Remove a vehicle\n3. Display garage contents\n0. Exit";
    static void Main(string[] args)
    {
        int numberOfVehicles;
        if (args.Length != 1 || !int.TryParse(args[0], out numberOfVehicles))
        {
            Console.Write("Please provide the number of vehicles: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfVehicles))
            {
                Console.WriteLine("Enter a valid integer for the number of vehicles:");
            }
        }

        Garage garage = new Garage(numberOfVehicles);
        Console.WriteLine($"Garage created: {garage}");

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
                    // Display all vehicles
                    garage.ListVehicles();
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

    // private static string SafeInput(string prompt)
    // {
    //     string? input = "";
    //     Console.Write(prompt);
    //     try {
    //         input = Console.ReadLine();
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Error: Incorrect input. {ex.Message}");
    //     }
    //     return input?.Trim() ?? "";
    // }
}



