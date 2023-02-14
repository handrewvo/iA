using iA.Fill.Models;
using System.Drawing;

namespace iA.Fill
{
    internal class Program
    {
        protected static List<FillerStation> fillerStations;
        static void Main()
        {
            try
            {
                Console.WriteLine("Please input X coordinate (-10 to 10): ");
                var input = Console.ReadLine();

                int x;
                while (!(int.TryParse(input, out x) && InRange(x)))
                {
                    Console.WriteLine("Invalid re-enter X coordinate with an integer value from -10 to 10: ");
                    input = Console.ReadLine();
                }

                Console.WriteLine("Please input Y coordinate (-10 to 10): ");
                input = Console.ReadLine();
                int y;
                while (!(int.TryParse(input, out y) && InRange(y)))
                {
                    Console.WriteLine("Invalid re-enter Y coordinate with an integer value from -10 to 10: ");
                    input = Console.ReadLine();
                }

                InitializeData();
                

                Point startPoint = new Point(x, y);
                GetClosestFillStations(startPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void InitializeData()
        {
            var mOne = new Medication(1, "A", 30.25);
            var mTwo = new Medication(2, "B", 5);
            var mThree = new Medication(3, "C", 1.5);
            var mFour = new Medication(4, "D", 15.45);
            var mFive = new Medication(5, "E", 21.99);
            var mSix = new Medication(6, "F", 5);

            fillerStations = new List<FillerStation>
            {
                new FillerStation { StationId = 1, XCoord = 1, YCoord = 1, MedicationsInFiller = new List<Medication> { mOne, mThree, mFive} },
                new FillerStation { StationId = 2, XCoord = 2, YCoord = 4, MedicationsInFiller = new List<Medication> { mTwo, mFour, mSix} },
                new FillerStation { StationId = 3, XCoord = 10, YCoord = 10, MedicationsInFiller = new List<Medication> { mFour, mFive, mSix} },
                new FillerStation { StationId = 4, XCoord = -5, YCoord = 5, MedicationsInFiller = new List<Medication> { mFive} },
                new FillerStation { StationId = 5, XCoord = 3, YCoord = 3, MedicationsInFiller = new List<Medication> { mOne, mTwo, mThree, mFour, mFive, mSix} },
                new FillerStation { StationId = 6, XCoord = 0, YCoord = 7, MedicationsInFiller = new List<Medication> { mTwo, mThree, mFour, mSix} },
                new FillerStation { StationId = 7, XCoord = 4, YCoord = 0, MedicationsInFiller = new List<Medication> { mOne, mSix} },
                new FillerStation { StationId = 8, XCoord = 5, YCoord = -1, MedicationsInFiller = new List<Medication> { mTwo, mFour, mFive} },
                new FillerStation { StationId = 9, XCoord = -10, YCoord = -10, MedicationsInFiller = new List<Medication> { mOne, mTwo, mThree} }
            };

        }

        private static void GetClosestFillStations(Point startPoint)
        {
            var results = fillerStations.Select(station => new
            {
                station.StationId,
                MedicationList = station.MedicationsInFiller.OrderBy(m => m.Price),
                Distance = CalculateManhattanDistance(startPoint, station.XCoord, station.YCoord)
            });

            Console.WriteLine("Closest Central Fills to ({0},{1})", startPoint.X.ToString(), startPoint.Y.ToString());
            var result = (from r in results orderby r.Distance select r).Take(3);

            foreach (var r in result)
            {
                var cheapestMedication = r.MedicationList.FirstOrDefault();
                Console.WriteLine("Central Fill {0} - ${1}, Medication {2}, Distance {3}",
                    r.StationId.ToString("000"),
                    cheapestMedication.Price.ToString("00.00"), cheapestMedication.Name, r.Distance);
            }

        }

        public static int CalculateManhattanDistance(Point startPoint, int xCoord, int yCoord)
        {
            return Math.Abs(startPoint.X - xCoord) + Math.Abs(startPoint.Y - yCoord);
        }

        private static bool InRange(int i)
        {
            return i >= -10 && i <= 10;
        }
        
        
    }
}