namespace GarageExercise;
public class Airplane : Vehicle
{
    public enum AirplaneTypeE { Commercial, Private, Cargo, Military, Other };
    private AirplaneTypeE AirplaneType { get; set; }
    private int NumberOfEngines { get; set; }
    private int NumberOfSeats { get; set; }
    public Airplane(string make, string color, string regNumber, AirplaneTypeE airplaneType, 
        int numberOfEngines, int numberOfSeats) : base(make, color, regNumber)
    {
        AirplaneType = airplaneType;
        NumberOfEngines = numberOfEngines;
        NumberOfSeats = numberOfSeats;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {AirplaneType}, {NumberOfEngines} engines, {NumberOfSeats} seats";
    }
}
