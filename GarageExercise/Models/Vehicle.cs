namespace GarageExercise
{
    public class Vehicle
    {
        private string Make { get; set; }
        private string Color  { get; set; }  // US variant of färg :-)
        private string RegNumber { get; set; }

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