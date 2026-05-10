namespace GarageExercise;

public class Bus : Vehicle
{
    public enum BusTypeE { City, Intercity, Coach, Minibus, SchoolBus, Other };
    private BusTypeE BusType { get; set; }
    private int NumberOfSeats { get; set; }
    public Bus(string make, string color, string regNumber, BusTypeE busType, int numberOfSeats) 
        : base(make, color, regNumber)
    {
        BusType = busType;
        NumberOfSeats = numberOfSeats;
    }

    public override string ToString()
    {
        return $"Bus: {base.ToString()}, {BusType}, {NumberOfSeats} seats";
    }
}
