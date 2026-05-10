using System.Dynamic;

namespace GarageExercise;
public class VehicleFactory
{   
    static string prompt = "";
 
    public static Vehicle CreateVehicle(string type)
    {
        // base data
        string make = Utils.SafeInput("Enter make: ");
        string color = Utils.SafeInput("Enter color: ");
        string regNumber = Utils.SafeInput("Enter registration number: ");

        Vehicle vehicle = new Vehicle(make, color, regNumber);

        switch (type.ToLower())
        {
            case "car":
                return CreateCar(vehicle);
            case "motorcycle":
                return CreateMotorcycle(vehicle);
            case "bus":
                return CreateBus(vehicle);
            case "airplane":
                return CreateAirplane(vehicle);
            case "boat":
                return CreateBoat(vehicle);
            default:
                throw new ArgumentException($"Unknown vehicle type: {type}");
        }
    }
    private static Car CreateCar(Vehicle vehicle)   
    {
        prompt = ($"Enter car type ({string.Join("/", Enum.GetNames<Car.CarTypeE>())}): ");
        Car.CarTypeE carType = Enum.Parse<Car.CarTypeE>(Utils.SafeInput(prompt), true);
        prompt = $"Enter transmission type (Automatic/Manual): ";
        Car.TransmissionE transmission = Enum.Parse<Car.TransmissionE>(Utils.SafeInput(prompt), true);
        Car car = new Car(vehicle.Make, vehicle.Color, vehicle.RegNumber, carType, transmission);
        return car;
    }

    private static Motorcycle CreateMotorcycle(Vehicle vehicle)
    {
        prompt = ($"Enter motorcycle type ({string.Join("/", Enum.GetNames<Motorcycle.McTypeE>())}): ");
        Motorcycle.McTypeE mcType = Enum.Parse<Motorcycle.McTypeE>(Utils.SafeInput(prompt), true);
        prompt = "Enter engine type (TwoStroke/FourStroke): ";
        Motorcycle.EngineTypeE engineType = Enum.Parse<Motorcycle.EngineTypeE>(Utils.SafeInput(prompt), true);
        Motorcycle motorcycle = new Motorcycle(vehicle.Make, vehicle.Color, vehicle.RegNumber, mcType, engineType);
        return motorcycle;
    }

    private static Bus CreateBus(Vehicle vehicle)
    {
        prompt = ($"Enter bus type ({string.Join("/", Enum.GetNames<Bus.BusTypeE>())}): ");
        Bus.BusTypeE busType = Enum.Parse<Bus.BusTypeE>(Utils.SafeInput(prompt), true);
        prompt = "Enter seating capacity: ";
        int seatingCapacity;
        while (!int.TryParse(Utils.SafeInput(prompt), out seatingCapacity))
        {
            Console.WriteLine("Enter a valid integer for seating capacity:");
        }
        Bus bus = new Bus(vehicle.Make, vehicle.Color, vehicle.RegNumber, busType, seatingCapacity);
        return bus;
    }

    private static Airplane CreateAirplane(Vehicle vehicle)
    {
        prompt = ($"Enter airplane type ({string.Join("/", Enum.GetNames<Airplane.AirplaneTypeE>())}): ");
        Airplane.AirplaneTypeE airplaneType = Enum.Parse<Airplane.AirplaneTypeE>(Utils.SafeInput(prompt), true);
        prompt = "Enter number of engines: ";
        int numEngines;
        while (!int.TryParse(Utils.SafeInput(prompt), out numEngines))
        {
            Console.WriteLine("Enter a valid integer for number of engines:");
        }
        prompt = "Enter maximum altitude (ft): ";
        int maxAltitude;
        while (!int.TryParse(Utils.SafeInput(prompt), out maxAltitude))
        {
            Console.WriteLine("Enter a valid integer for maximum altitude:");
        }
        Airplane airplane = new Airplane(vehicle.Make, vehicle.Color, vehicle.RegNumber, airplaneType, numEngines, maxAltitude);
        return airplane;
    }

    private static Boat CreateBoat(Vehicle vehicle)
    {
        prompt = ($"Enter boat type ({string.Join("/", Enum.GetNames<Boat.BoatTypeE>())}): ");
        Boat.BoatTypeE boatType = Enum.Parse<Boat.BoatTypeE>(Utils.SafeInput(prompt), true);
        prompt = "Enter length (ft): ";
        double length;
        while (!double.TryParse(Utils.SafeInput(prompt), out length))
        {
            Console.WriteLine("Enter a valid number for length:");
        }
        Boat boat = new Boat(vehicle.Make, vehicle.Color, vehicle.RegNumber, boatType, length);
        return boat;
    }

}   