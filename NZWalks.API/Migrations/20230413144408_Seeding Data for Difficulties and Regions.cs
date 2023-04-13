using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4eabb0c0-e9de-49cf-a923-37f0c8cb928d"), "Easy" },
                    { new Guid("50d9d0ad-6a65-49cc-b4f2-11aeaebbd37a"), "Medium" },
                    { new Guid("8f68da09-2a5f-4926-a586-45e3e81c6cc3"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("045a66a0-b083-41f1-b0cc-e6c1d373df29"), "BOP", "Bay of Plenty", null },
                    { new Guid("0a59e642-d2f2-4703-9780-29db063dc387"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("36942c10-2f18-4694-8426-93feccb2385e"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("36aab4af-aa37-4fae-a6e5-5d41a22d8cb1"), "STL", "Southland", null },
                    { new Guid("6f1407ae-2864-4e8e-ad4b-790b08f4c58b"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cd226cec-185d-4bce-b4e3-269371940945"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4eabb0c0-e9de-49cf-a923-37f0c8cb928d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("50d9d0ad-6a65-49cc-b4f2-11aeaebbd37a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8f68da09-2a5f-4926-a586-45e3e81c6cc3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("045a66a0-b083-41f1-b0cc-e6c1d373df29"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0a59e642-d2f2-4703-9780-29db063dc387"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("36942c10-2f18-4694-8426-93feccb2385e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("36aab4af-aa37-4fae-a6e5-5d41a22d8cb1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6f1407ae-2864-4e8e-ad4b-790b08f4c58b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cd226cec-185d-4bce-b4e3-269371940945"));
        }
    }
}
