namespace GarageExercise;

public class Program
{
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

    }
}


