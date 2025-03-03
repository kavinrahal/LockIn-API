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
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }

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

            modelBuilder.Entity<DietLog>()
                .HasOne(dl => dl.User)
                .WithMany(u => u.DietLogs)  // Ensure User entity has a collection property for DietLogs
                .HasForeignKey(dl => dl.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Disables cascade delete for this FK

            modelBuilder.Entity<DietLog>()
                .HasOne(dl => dl.Group)
                .WithMany(g => g.DietLogs)  // Ensure Group entity has a collection property for DietLogs
                .HasForeignKey(dl => dl.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMember>()
                .HasOne(dl => dl.User)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(dl => dl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMember>()
                .HasOne(dl => dl.Group)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(dl => dl.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterIntake>()
                .HasOne(w => w.User)
                .WithMany(u => u.WaterIntakes)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WaterIntake>()
                .HasOne(w => w.Group)
                .WithMany(g => g.WaterIntakes)
                .HasForeignKey(w => w.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StepTracking>()
                .HasOne(st => st.User)
                .WithMany(u => u.StepTrackings)
                .HasForeignKey(st => st.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StepTracking>()
                .HasOne(st => st.Group)
                .WithMany(g => g.StepTrackings)
                .HasForeignKey(st => st.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutRoutine>()
                .HasOne(st => st.User)
                .WithMany(u => u.WorkoutRoutines)
                .HasForeignKey(st => st.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutRoutine>()
                .HasOne(st => st.Group)
                .WithMany(g => g.WorkoutRoutines)
                .HasForeignKey(st => st.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMemberGoal>()
                .HasOne(st => st.User)
                .WithMany(u => u.GroupMemberGoals)
                .HasForeignKey(st => st.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMemberGoal>()
                .HasOne(st => st.Group)
                .WithMany(g => g.GroupMemberGoals)
                .HasForeignKey(st => st.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutSession>()
                .HasOne(st => st.User)
                .WithMany(u => u.WorkoutSessions)
                .HasForeignKey(st => st.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutSession>()
                .HasOne(st => st.Group)
                .WithMany(g => g.WorkoutSessions)
                .HasForeignKey(st => st.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed predefined metrics
            modelBuilder.Entity<Metric>().HasData(
                new Metric
                {
                    MetricId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Steps",
                    Description = "Daily step count",
                    DataType = "int"
                },
                new Metric
                {
                    MetricId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Diet",
                    Description = "Caloric intake for meals",
                    DataType = "int"
                },
                new Metric
                {
                    MetricId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Water",
                    Description = "Daily water consumption in liters",
                    DataType = "int"
                },
                new Metric
                {
                    MetricId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Workout Routine",
                    Description = "Planned workout routine with target sets, reps, and weights",
                    DataType = "workout"
                },
                new Metric
                {
                    MetricId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Weekly Spending",
                    Description = "Amount spent each week",
                    DataType = "int"
                }
            );
        }
    }
}
