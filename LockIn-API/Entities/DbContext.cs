using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<GroupMetric> GroupMetrics { get; set; }
        public DbSet<GroupMemberGoal> GroupMemberGoals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<DietLog> DietLogs { get; set; }
        public DbSet<WaterIntake> WaterIntakes { get; set; }
        public DbSet<StepTracking> StepTracking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");

            // Composite keys for many-to-many and join tables
            modelBuilder.Entity<GroupMember>()
                .HasKey(gm => new { gm.GroupId, gm.UserId });

            modelBuilder.Entity<GroupMetric>()
                .HasKey(gm => new { gm.GroupId, gm.MetricId });

            modelBuilder.Entity<GroupMemberGoal>()
                .HasKey(gmg => new { gmg.GroupId, gmg.UserId, gmg.MetricId });
        }
    }
}
