using EMS.Domain.Entities;
using EMS.Domain.Entities.Views;

namespace EMS.Domain.Dtos;

public class ChuongTrinhKhungMergedResponseDto : ChuongTrinhKhungMerged
{
    public CoSoDaoTao? CoSoDaoTao { get; set; }
    public KhoaHoc? KhoaHoc { get; set; }
    public LoaiDaoTao? LoaiDaoTao { get; set; }
    public NganhHoc? NganhHoc { get; set; }
    public BacDaoTao? BacDaoTao { get; set; }
    public ChuyenNganh? ChuyenNganh { get; set; }
}
