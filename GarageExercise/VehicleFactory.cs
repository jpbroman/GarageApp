using System.Dynamic;

namespace GarageExercise;
public class VehicleFactory
{   
    static string prompt = "";
 
    public static Vehicle CreateVehicle(string type)
    {
        // base data
        Vehicle.VehicleTypeE vehicleType = Enum.TryParse<Vehicle.VehicleTypeE>(type, true, out var vt) ? vt : Vehicle.VehicleTypeE.Unknown;
        string make = Utils.SafeInput("Enter make: ");
        string color = Utils.SafeInput("Enter color: ");
        string regNumber = Utils.SafeInput("Enter registration number: ");

        Vehicle vehicle = new Vehicle(vehicleType, make, color, regNumber);

        switch (type.ToLower().Substring(0, Math.Min(type.Length, 3))) // use first 3 letters to determine type
        {
            case "car":
                return CreateCar(vehicle);
            case "mot":
                return CreateMotorcycle(vehicle);
            case "bus":
                return CreateBus(vehicle);
            case "air":
                return CreateAirplane(vehicle);
            case "boa":
                return CreateBoat(vehicle);
            default:
                throw new ArgumentException($"Unknown vehicle type: {type}");
        }
    }

    public static Vehicle CreateVehicleFromData(string type, string data)
    {
        string[] parts = data.Split(',', StringSplitOptions.TrimEntries);
        if (parts.Length < 4)
        {
            throw new ArgumentException("Invalid data format for vehicle.");
        }
        string make = parts[0];
        string color = parts[1];
        string regNumber = parts[2];

        switch (type.ToLower())
        {
            case "car":
                string cartypeStr = parts[3];
                string transmissionStr = parts[4];
                Car.CarTypeE carType = Enum.Parse<Car.CarTypeE>(cartypeStr, true);
                Car.TransmissionE transmission = Enum.Parse<Car.TransmissionE>(transmissionStr, true);
                Car car = new Car(make, color, regNumber, carType, transmission);
                return car;
            case "motorcycle":
                string mctypeStr = parts[3];
                string engineTypeStr = parts[4];
                Motorcycle.McTypeE mcType = Enum.Parse<Motorcycle.McTypeE>(mctypeStr, true);
                Motorcycle.EngineTypeE engineType = Enum.Parse<Motorcycle.EngineTypeE>(engineTypeStr, true);
                Motorcycle motorcycle = new Motorcycle(make, color, regNumber, mcType, engineType);
                return motorcycle;
            case "bus":
                string bustypeStr = parts[3];
                string seatingCapacityStr = parts[4];
                Bus.BusTypeE busType = Enum.Parse<Bus.BusTypeE>(bustypeStr, true);
                int seatingCapacity = int.Parse(seatingCapacityStr);
                Bus bus = new Bus(make, color, regNumber, busType, seatingCapacity);
                return bus;
            case "airplane":
                string airplaneTypeStr = parts[3];
                string numEnginesStr = parts[4];
                string numSeatsStr = parts[5];
                Airplane.AirplaneTypeE airplaneType = Enum.Parse<Airplane.AirplaneTypeE>(airplaneTypeStr, true);
                int numEngines = int.Parse(numEnginesStr);
                int numSeats = int.Parse(numSeatsStr);
                Airplane airplane = new Airplane(make, color, regNumber, airplaneType, numEngines, numSeats);
                return airplane;
            case "boat":
                string boatTypeStr = parts[3];
                string lengthStr = parts[4];
                Boat.BoatTypeE boatType = Enum.Parse<Boat.BoatTypeE>(boatTypeStr, true);
                double length = double.Parse(lengthStr);
                Boat boat = new Boat(make, color, regNumber, boatType, length);
                return boat;
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
        prompt = "Enter number of seats: ";
        int numSeats;
        while (!int.TryParse(Utils.SafeInput(prompt), out numSeats))
        {
            Console.WriteLine("Enter a valid integer for number of seats:");
        }
        Airplane airplane = new Airplane(vehicle.Make, vehicle.Color, vehicle.RegNumber, airplaneType, numEngines, numSeats);
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