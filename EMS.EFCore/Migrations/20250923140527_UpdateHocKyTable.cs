using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHocKyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Nếu dữ liệu cũ không quan trọng → ép NULL
            migrationBuilder.Sql(@"
                ALTER TABLE ""HocKy""
                ALTER COLUMN ""TuNgay"" TYPE timestamp with time zone
                USING NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""HocKy""
                ALTER COLUMN ""DenNgay"" TYPE timestamp with time zone
                USING NULL;
            ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TuNgay",
                table: "HocKy",
                type: "integer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DenNgay",
                table: "HocKy",
                type: "integer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
