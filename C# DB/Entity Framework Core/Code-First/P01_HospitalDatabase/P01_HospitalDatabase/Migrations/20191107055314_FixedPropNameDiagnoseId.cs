using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class FixedPropNameDiagnoseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiangnoseId",
                table: "Diagnoses",
                newName: "DiagnoseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiagnoseId",
                table: "Diagnoses",
                newName: "DiangnoseId");
        }
    }
}
