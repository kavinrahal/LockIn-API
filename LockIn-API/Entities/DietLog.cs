using LockIn_API.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class DietLog
    {
        [Key]
        public Guid DietId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public string FoodName { get; set; } = string.Empty;

        [Required]
        public int Calories { get; set; }

        [Required]
        public float Protein { get; set; }

        [Required]
        public float Carbs { get; set; }

        [Required]
        public float Fats { get; set; }

        [Required]
        public string MealType { get; set; } = string.Empty; // breakfast, lunch, dinner, snack

        [Required]
        public DateTime Date { get; set; }
    }
}
