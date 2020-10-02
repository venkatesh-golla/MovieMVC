using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMVC.Data_Access.Migrations
{
    public partial class ChangedEMployeeForeignkeyInAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Appointments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
