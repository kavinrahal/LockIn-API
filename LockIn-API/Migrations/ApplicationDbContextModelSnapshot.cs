﻿// <auto-generated />
using System;
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LockIn_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LockIn_API.Entities.DietLog", b =>
                {
                    b.Property<Guid>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Protein")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DietId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("DietLogs");
                });

            modelBuilder.Entity("LockIn_API.Entities.Exercise", b =>
                {
                    b.Property<Guid>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("LockIn_API.Entities.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateFrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.HasIndex("AdminId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMember", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMemberGoal", b =>
                {
                    b.Property<Guid>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GoalValue")
                        .HasColumnType("int");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MetricId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WorkoutRoutineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GoalId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MetricId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutRoutineId");

                    b.ToTable("GroupMemberGoals");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMemberGoalHistory", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArchivedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GoalValue")
                        .HasColumnType("int");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupMemberGoalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MetricId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WorkoutRoutineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HistoryId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MetricId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutRoutineId");

                    b.ToTable("GroupMemberGoalHistories");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMetric", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MetricId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "MetricId");

                    b.HasIndex("MetricId");

                    b.ToTable("GroupMetrics");
                });

            modelBuilder.Entity("LockIn_API.Entities.Metric", b =>
                {
                    b.Property<Guid>("MetricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetricId");

                    b.ToTable("Metrics");

                    b.HasData(
                        new
                        {
                            MetricId = new Guid("00000000-0000-0000-0000-000000000001"),
                            DataType = "int",
                            Description = "Daily step count",
                            Name = "Steps"
                        },
                        new
                        {
                            MetricId = new Guid("00000000-0000-0000-0000-000000000002"),
                            DataType = "int",
                            Description = "Caloric intake for meals",
                            Name = "Diet"
                        },
                        new
                        {
                            MetricId = new Guid("00000000-0000-0000-0000-000000000003"),
                            DataType = "int",
                            Description = "Daily water consumption in liters",
                            Name = "Water"
                        },
                        new
                        {
                            MetricId = new Guid("00000000-0000-0000-0000-000000000004"),
                            DataType = "workout",
                            Description = "Planned workout routine with target sets, reps, and weights",
                            Name = "Workout Routine"
                        },
                        new
                        {
                            MetricId = new Guid("00000000-0000-0000-0000-000000000005"),
                            DataType = "int",
                            Description = "Amount spent each week",
                            Name = "Weekly Spending"
                        });
                });

            modelBuilder.Entity("LockIn_API.Entities.RoutineExercise", b =>
                {
                    b.Property<Guid>("RoutineExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<Guid>("RoutineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("RoutineExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineExercises");
                });

            modelBuilder.Entity("LockIn_API.Entities.StepTracking", b =>
                {
                    b.Property<Guid>("StepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StepCount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StepId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("StepTracking");
                });

            modelBuilder.Entity("LockIn_API.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("LockIn_API.Entities.WaterIntake", b =>
                {
                    b.Property<Guid>("WaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Liters")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WaterId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("WaterIntakes");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutRoutine", b =>
                {
                    b.Property<Guid>("RoutineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoutineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoutineId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutRoutines");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutSession", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoutineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoutineId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutSessionExercise", b =>
                {
                    b.Property<Guid>("SessionExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualReps")
                        .HasColumnType("int");

                    b.Property<int>("ActualSets")
                        .HasColumnType("int");

                    b.Property<float?>("ActualWeight")
                        .HasColumnType("real");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("SessionId");

                    b.ToTable("WorkoutSessionExercises");
                });

            modelBuilder.Entity("LockIn_API.Entities.DietLog", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("DietLogs")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("DietLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LockIn_API.Entities.Group", b =>
                {
                    b.HasOne("LockIn_API.Entities.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMember", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("GroupMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMemberGoal", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("GroupMemberGoals")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.Metric", "Metric")
                        .WithMany()
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("GroupMemberGoals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany()
                        .HasForeignKey("WorkoutRoutineId");

                    b.Navigation("Group");

                    b.Navigation("Metric");

                    b.Navigation("User");

                    b.Navigation("WorkoutRoutine");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMemberGoalHistory", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("GroupMemberGoalHistories")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.Metric", "Metric")
                        .WithMany()
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("GroupMemberGoalHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany()
                        .HasForeignKey("WorkoutRoutineId");

                    b.Navigation("Group");

                    b.Navigation("Metric");

                    b.Navigation("User");

                    b.Navigation("WorkoutRoutine");
                });

            modelBuilder.Entity("LockIn_API.Entities.GroupMetric", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("GroupMetrics")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.Metric", "Metric")
                        .WithMany()
                        .HasForeignKey("MetricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Metric");
                });

            modelBuilder.Entity("LockIn_API.Entities.RoutineExercise", b =>
                {
                    b.HasOne("LockIn_API.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("WorkoutRoutine");
                });

            modelBuilder.Entity("LockIn_API.Entities.StepTracking", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("StepTrackings")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("StepTrackings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LockIn_API.Entities.WaterIntake", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("WaterIntakes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("WaterIntakes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutRoutine", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("WorkoutRoutines")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("WorkoutRoutines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutSession", b =>
                {
                    b.HasOne("LockIn_API.Entities.Group", "Group")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany()
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.User", "User")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");

                    b.Navigation("WorkoutRoutine");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutSessionExercise", b =>
                {
                    b.HasOne("LockIn_API.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LockIn_API.Entities.WorkoutSession", "WorkoutSession")
                        .WithMany("SessionExercises")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("WorkoutSession");
                });

            modelBuilder.Entity("LockIn_API.Entities.Group", b =>
                {
                    b.Navigation("DietLogs");

                    b.Navigation("GroupMemberGoalHistories");

                    b.Navigation("GroupMemberGoals");

                    b.Navigation("GroupMembers");

                    b.Navigation("GroupMetrics");

                    b.Navigation("StepTrackings");

                    b.Navigation("WaterIntakes");

                    b.Navigation("WorkoutRoutines");

                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("LockIn_API.Entities.User", b =>
                {
                    b.Navigation("DietLogs");

                    b.Navigation("GroupMemberGoalHistories");

                    b.Navigation("GroupMemberGoals");

                    b.Navigation("GroupMembers");

                    b.Navigation("StepTrackings");

                    b.Navigation("WaterIntakes");

                    b.Navigation("WorkoutRoutines");

                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutRoutine", b =>
                {
                    b.Navigation("RoutineExercises");
                });

            modelBuilder.Entity("LockIn_API.Entities.WorkoutSession", b =>
                {
                    b.Navigation("SessionExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
