using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LockIn_API.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupMemberGoalHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMemberGoals",
                table: "GroupMemberGoals");

            migrationBuilder.AddColumn<Guid>(
                name: "GoalId",
                table: "GroupMemberGoals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupMemberGoals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMemberGoals",
                table: "GroupMemberGoals",
                column: "GoalId");

            migrationBuilder.CreateTable(
                name: "GroupMemberGoalHistories",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupMemberGoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalValue = table.Column<int>(type: "int", nullable: true),
                    WorkoutRoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMemberGoalHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_GroupMemberGoalHistories_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupMemberGoalHistories_Metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "Metrics",
                        principalColumn: "MetricId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMemberGoalHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupMemberGoalHistories_WorkoutRoutines_WorkoutRoutineId",
                        column: x => x.WorkoutRoutineId,
                        principalTable: "WorkoutRoutines",
                        principalColumn: "RoutineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberGoals_GroupId",
                table: "GroupMemberGoals",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberGoalHistories_GroupId",
                table: "GroupMemberGoalHistories",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberGoalHistories_MetricId",
                table: "GroupMemberGoalHistories",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberGoalHistories_UserId",
                table: "GroupMemberGoalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMemberGoalHistories_WorkoutRoutineId",
                table: "GroupMemberGoalHistories",
                column: "WorkoutRoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMemberGoalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMemberGoals",
                table: "GroupMemberGoals");

            migrationBuilder.DropIndex(
                name: "IX_GroupMemberGoals_GroupId",
                table: "GroupMemberGoals");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "GroupMemberGoals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GroupMemberGoals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMemberGoals",
                table: "GroupMemberGoals",
                columns: new[] { "GroupId", "UserId", "MetricId" });
        }
    }
}
