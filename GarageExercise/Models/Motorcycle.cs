namespace GarageExercise;
public class Motorcycle : Vehicle
{
    public enum McTypeE { Standard, Cruiser, Sport, Touring, OffRoad, Scooter, Other };
    public enum EngineTypeE { TwoStroke, FourStroke, Electric, Other };
    private McTypeE McType { get; set; }
    private EngineTypeE EngineType { get; set; }
    public Motorcycle(string make, string color, string regNumber, 
        McTypeE mcType, EngineTypeE engineType) : base(make, color, regNumber)
    {
        McType = mcType;
        EngineType = engineType;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {McType}, {EngineType}";
    }  
    
}
