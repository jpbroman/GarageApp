namespace GarageExercise;
public class Car : Vehicle
{
    public enum CarTypeE { Sedan, Hatchback, SUV, Coupe, Convertible, Wagon, Van, Other };
    public enum TransmissionE { Manual, Automatic}; 
    private CarTypeE CarType { get; set; }
    private TransmissionE Transmission { get; set; }
    public Car(string make, string color, string regNumber, CarTypeE carType, TransmissionE transmission) 
        : base(make, color, regNumber)
    {
        CarType = carType;
        Transmission = transmission;
    }

    public override string ToString()
    {
        return $"Car: {base.ToString()}, {CarType}, {Transmission}";
    }
}
