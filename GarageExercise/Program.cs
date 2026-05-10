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
            String prompt = "";
            Console.WriteLine(MainMenu);
            string choice = SafeInput("Enter your choice: ");
            switch (choice)
            {
                case "1":
                    // Add a vehicle
                    string type = SafeInput("Enter vehicle type (Car/Motorcycle/Bus): ");
                    string make = SafeInput("Enter make: ");
                    string color = SafeInput("Enter color: ");
                    string regNumber = SafeInput("Enter registration number: ");

                    if (type.Equals("Car", StringComparison.OrdinalIgnoreCase))
                    {
                        prompt = ($"Enter car type ({string.Join("/", Enum.GetNames<Car.CarTypeE>())}): ");
                        Car.CarTypeE carType = Enum.Parse<Car.CarTypeE>(SafeInput(prompt), true);
                        prompt = $"Enter transmission type (Automatic/Manual): ";
                        Car.TransmissionE transmission = Enum.Parse<Car.TransmissionE>(SafeInput(prompt), true);
                        Car car = new Car(make, color, regNumber, carType, transmission);
                        garage.AddVehicle(car);
                    }
                    else if (type.Equals("Motorcycle", StringComparison.OrdinalIgnoreCase))
                    {
                        prompt = ($"Enter motorcycle type ({string.Join("/", Enum.GetNames<Motorcycle.McTypeE>())}): ");
                        Motorcycle.McTypeE mcType = Enum.Parse<Motorcycle.McTypeE>(SafeInput(prompt), true);
                        prompt = "Enter engine type (TwoStroke/FourStroke): ";
                        Motorcycle.EngineTypeE engineType = Enum.Parse<Motorcycle.EngineTypeE>(SafeInput(prompt), true);
                        Motorcycle motorcycle = new Motorcycle(make, color, regNumber, mcType, engineType);
                        garage.AddVehicle(motorcycle);
                    }
                    else if (type.Equals("Bus", StringComparison.OrdinalIgnoreCase))
                    {
                        prompt = ($"Enter bus type ({string.Join("/", Enum.GetNames<Bus.BusTypeE>())}): ");
                        Bus.BusTypeE busType = Enum.Parse<Bus.BusTypeE>(SafeInput(prompt), true);
                        prompt = "Enter seating capacity: ";
                        int seatingCapacity;
                        while (!int.TryParse(SafeInput(prompt), out seatingCapacity))
                        {
                            Console.WriteLine("Enter a valid integer for seating capacity:");
                        }
                        Bus bus = new Bus(make, color, regNumber, busType, seatingCapacity);
                        garage.AddVehicle(bus);
                    }
                    break;          
                case "2":
                    // Remove a vehicle
                    string regNumToRemove = SafeInput("Enter registration number of the vehicle to remove: ");
                    Vehicle? vehicleToRemove = null;
                    foreach (var vehicle in garage.GetVehicles())
                    {
                        if (vehicle != null && vehicle.RegNumber.Equals(regNumToRemove, StringComparison.OrdinalIgnoreCase))
                        {
                            vehicleToRemove = vehicle;
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

    private static string SafeInput(string prompt)
    {
        string? input = "";
        Console.Write(prompt);
        try {
            input = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: Incorrect input. {ex.Message}");
        }
        return input?.Trim() ?? "";
    }
}



