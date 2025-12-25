using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddLHP_LopDuKienTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LopHocPhan_LopDuKien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopHocPhan = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLopDuKien = table.Column<Guid>(type: "uuid", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    IdNguoiTao = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdNguoiCapNhap = table.Column<Guid>(type: "uuid", nullable: true),
                    NguoiCapNhapId = table.Column<Guid>(type: "uuid", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhan_LopDuKien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_LopDuKien_LopHocPhan_IdLopHocPhan",
                        column: x => x.IdLopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_LopDuKien_LopHoc_IdLopDuKien",
                        column: x => x.IdLopDuKien,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiCapNhapId",
                        column: x => x.NguoiCapNhapId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LopHocPhan_LopDuKien_NguoiDung_NguoiTaoId",
                        column: x => x.NguoiTaoId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_IdLopDuKien",
                table: "LopHocPhan_LopDuKien",
                column: "IdLopDuKien");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_IdLopHocPhan_IdLopDuKien",
                table: "LopHocPhan_LopDuKien",
                columns: new[] { "IdLopHocPhan", "IdLopDuKien" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_NguoiCapNhapId",
                table: "LopHocPhan_LopDuKien",
                column: "NguoiCapNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_LopDuKien_NguoiTaoId",
                table: "LopHocPhan_LopDuKien",
                column: "NguoiTaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LopHocPhan_LopDuKien");
        }
    }
}
