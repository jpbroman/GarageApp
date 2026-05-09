namespace GarageExercise;
public class Car : Vehicle
{
    public enum CarTypeE { Sedan, Hatchback, SUV, Coupe, Convertible, Wagon, Van, Other };
    public enum TransmissionE { Manual, Automatic}; 
    private CarTypeE CarType { get; set; }
    private TransmissionE Transmission { get; set; }
    public Car(string make, CarTypeE carType, TransmissionE transmission, string color, string regNumber) 
        : base(make, color, regNumber)
    {
        CarType = carType;
        Transmission = transmission;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {CarType}, {Transmission}";
    }
}
