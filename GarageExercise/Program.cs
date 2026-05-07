namespace GarageExercise;


internal class Program
{
    Garage garage = null;

    static void Main(string[] args)
    {
        int numberOfVehicles = 0;

        if (args.Length == 1)
        {
            numberOfVehicles = int.Parse(args[0]);  // TODO. Handle potential exceptions here.
        }
        else
        {
            Console.WriteLine("Please provide the number of vehicles as a command-line argument.");
            numberOfVehicles = int.Parse(Console.ReadLine());  // ...and here
        }
        garage = new Garage(numberOfVehicles);

        //Main mwnu loop

    }
}


