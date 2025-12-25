using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReCreate_View_vw_ChuongTrinhKhung_Merged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW ""vw_ChuongTrinhKhung_Merged"" AS
                SELECT
                    t.""Id"",
                    t.""MaChuongTrinh"",
                    t.""TenChuongTrinh"",
                    t.""IsBlock"",
                    t.""GhiChu"",
                    t.""GhiChuTiengAnh"",
                    t.""IdCoSoDaoTao"",
                    t.""IdKhoaHoc"",
                    t.""IdLoaiDaoTao"",
                    t.""IdNganhHoc"",
                    t.""IdBacDaoTao"",
                    t.""IdChuyenNganh"",
                    false AS ""IsNienChe"",
                    t.""IdNguoiCapNhat"",
                    t.""IdNguoiTao"",
                    t.""IsDeleted"",
                    t.""NgayCapNhat"",
                    t.""NgayTao""
                FROM public.""ChuongTrinhKhungTinChi"" t

                UNION ALL

                SELECT
                    n.""Id"",
                    n.""MaChuongTrinh"",
                    n.""TenChuongTrinh"",
                    n.""IsBlock"",
                    n.""GhiChu"",
                    n.""GhiChuTiengAnh"",
                    n.""IdCoSoDaoTao"",
                    n.""IdKhoaHoc"",
                    n.""IdLoaiDaoTao"",
                    n.""IdNganhHoc"",
                    n.""IdBacDaoTao"",
                    n.""IdChuyenNganh"",
                    true AS ""IsNienChe"",
                    n.""IdNguoiCapNhat"",
                    n.""IdNguoiTao"",
                    n.""IsDeleted"",
                    n.""NgayCapNhat"",
                    n.""NgayTao""
                FROM public.""ChuongTrinhKhungNienChe"" n;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS ""vw_ChuongTrinhKhung_Merged"";
            ");
        }
    }
}
