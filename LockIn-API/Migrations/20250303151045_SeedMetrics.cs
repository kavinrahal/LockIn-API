using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LockIn_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Metrics",
                columns: new[] { "MetricId", "DataType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "int", "Daily step count", "Steps" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "int", "Caloric intake for meals", "Diet" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "int", "Daily water consumption in liters", "Water" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "workout", "Planned workout routine with target sets, reps, and weights", "Workout Routine" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "int", "Amount spent each week", "Weekly Spending" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "MetricId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "MetricId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "MetricId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "MetricId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Metrics",
                keyColumn: "MetricId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));
        }
    }
}
