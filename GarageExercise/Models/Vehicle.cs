using System.Text;
namespace GarageExercise;
public class Vehicle
{
    public enum VehicleTypeE { Car, Motorcycle, Bus, Airplane, Boat, Unknown};
    public string Make { get; private set; }
    public string Color  { get; private set; }  // US variant of färg :-)
    public string RegNumber { get; private set; }
    public VehicleTypeE Type { get; private set; }

    public Vehicle(VehicleTypeE type, string make, string color, string regNumber)
    {
        Type = type;
        Make = make;
        Color = color;
        RegNumber = regNumber;
    }

    public override string ToString()
    {
        return $"{Make}, {Color}, {RegNumber}";
    }
}
