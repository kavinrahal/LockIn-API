namespace LockIn_API.Entities
{
    public class StepTracking
    {
        public Guid StepId { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public int StepCount { get; set; }
        public DateTime Date { get; set; }
    }
}
