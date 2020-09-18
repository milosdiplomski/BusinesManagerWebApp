using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinesManagerWebApp.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa76b3f4-b5df-4856-a1ab-fba3b322182c", "2c24bdb4-05ff-4f0d-8201-a9057a90fe36", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87cb9305-c3c3-47a1-b17a-b41a809873d0", "93048d7f-88a1-49a9-b3d2-33eefb1345e3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87cb9305-c3c3-47a1-b17a-b41a809873d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa76b3f4-b5df-4856-a1ab-fba3b322182c");
        }
    }
}
