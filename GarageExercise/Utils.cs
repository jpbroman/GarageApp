namespace GarageExercise;

public static class Utils
{
    public static string SafeInput(string prompt)
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
