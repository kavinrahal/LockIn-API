namespace LockIn_API.Entities
{
    public class WaterIntake
    {
        public Guid WaterId { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public float Liters { get; set; }
        public DateTime Date { get; set; }
    }
}
