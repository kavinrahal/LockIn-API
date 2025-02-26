namespace LockIn_API.Entities
{
    public class DietLog
    {
        public Guid DietId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fats { get; set; }
        public string MealType { get; set; } // e.g., breakfast, lunch, dinner, snack
        public DateTime Date { get; set; }
    }
}
