namespace GarageExercise;
public class Boat : Vehicle
{
    public enum BoatTypeE { Sailboat, Motorboat, Yacht, Kayak, Canoe, Other };
    private BoatTypeE BoatType { get; set; }
    private double Length { get; set; }  // in meters
    public Boat(string make, string color, string regNumber, BoatTypeE boatType, double length) 
        : base(make, color, regNumber)
    {
        BoatType = boatType;
        Length = length;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {BoatType}, {Length} m";
    }
}
