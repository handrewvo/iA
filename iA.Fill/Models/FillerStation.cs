namespace iA.Fill.Models
{
    public class FillerStation
    {
        public int StationId { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public List<Medication> MedicationsInFiller { get; set; }

    }
}
