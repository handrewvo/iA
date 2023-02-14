
namespace iA.Fill.Models
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Medication(int medicationId, string name, double price) => (MedicationId, Name, Price) = (medicationId, name, price);
    }
}