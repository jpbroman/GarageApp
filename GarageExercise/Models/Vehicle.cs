using System.Text.RegularExpressions;

namespace GarageExercise;
public class Vehicle
{
    public enum VehicleTypeE { Car, Motorcycle, Bus, Airplane, Boat, Unknown};
    public string Make { get; private set; }
    public string Color  { get; private set; }  // US variant of färg :-)
    public string RegNumber { get; private set; }
    public VehicleTypeE Type { get; private set; }

    public Vehicle(VehicleTypeE type, string make, string color, string? regNumber)
    {
        Type = type;
        Make = make;
        Color = color;
        RegNumber = RegNumberFormat(regNumber); // Validate and format to consisten format. If invalid.
        if (RegNumber == null)  
        {
            throw new ArgumentException("Invalid registration number format for this type of vehicle.");
        }
    }

    protected string? RegNumberFormat(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (Type == VehicleTypeE.Car || Type == VehicleTypeE.Motorcycle || Type == VehicleTypeE.Bus)
        {
            // Cars, busses and motorcycles: 3 letters followed by 3 digits, with optional dash (e.g., ABC123 or ABC-123)
            string cleaned = Regex.Replace(input.ToUpper(), @"[\s-]", "");

            // Validate format: ABC123 where last char can be 0-9 or A-Z
            if (!Regex.IsMatch(cleaned, @"^[A-Z]{3}\d{2}[0-9A-Z]$"))
                return null;

            return cleaned;
        }
        return input.ToUpper(); // For other types, just return uppercase.
    }
    public override string ToString()
    {
        return $"{Make}, {Color}, {RegNumber}";
    }
}
