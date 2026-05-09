namespace GarageExercise;
public class Motorcycle : Vehicle
{
    public enum McTypeE { Standard, Cruiser, Sport, Touring, OffRoad, Scooter, Other };
    private McTypeE McType { get; set; }
    public Motorcycle(string make, string color, string regNumber, McTypeE mcType) 
        : base(make, color, regNumber)
    {
        McType = mcType;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {McType}";
    }  
    
}
