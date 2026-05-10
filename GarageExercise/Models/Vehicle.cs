namespace GarageExercise
{
    public class Vehicle
    {
        public string Make { get; private set; }
        public string Color  { get; private set; }  // US variant of färg :-)
        public string RegNumber { get; private set; }

        public Vehicle(string make, string color, string regNumber)
        {
            Make = make;
            Color = color;
            RegNumber = regNumber;
        }

        public override string ToString()
        {
            return $"{Make}, {Color}, {RegNumber}";
        }
    }
}