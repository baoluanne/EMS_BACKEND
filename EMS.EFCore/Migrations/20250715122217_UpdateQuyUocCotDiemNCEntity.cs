using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuyUocCotDiemNCEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ThuongXuyen1",
                table: "QuyUocCotDiem_NC",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThuongXuyen2",
                table: "QuyUocCotDiem_NC",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThuongXuyen3",
                table: "QuyUocCotDiem_NC",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThuongXuyen4",
                table: "QuyUocCotDiem_NC",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThuongXuyen5",
                table: "QuyUocCotDiem_NC",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThuongXuyen1",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "ThuongXuyen2",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "ThuongXuyen3",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "ThuongXuyen4",
                table: "QuyUocCotDiem_NC");

            migrationBuilder.DropColumn(
                name: "ThuongXuyen5",
                table: "QuyUocCotDiem_NC");
        }
    }
}
