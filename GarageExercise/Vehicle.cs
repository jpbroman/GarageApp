namespace GarageExercise
{
    enum TypeE { Car, Motorcycle, Truck };
    
    public class Vehicle
    {
        private string Make { get; set; }
        private string Color  { get; set; }  // US variant of färg :-)
        private TypeE Type { get; set; }
        private string RegNumber { get; set; }

        public Vehicle(string make, string color, TypeE type, string regNumber)
        {
            Make = make;
            Color = color;
            Type = type;
            RegNumber = regNumber;
        }

        public override string ToString()
        {
            return $"{Make}, {Type}, {Color}, {RegNumber}";
        }
    }
}