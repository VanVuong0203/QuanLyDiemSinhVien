using System.ComponentModel.DataAnnotations;

namespace QuanLiDiem.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; } // Mã định danh tự động tăng

        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        public string? HoTen { get; set; }

        [Required(ErrorMessage = "CCCD là bắt buộc.")]
        public string? CCCD { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string? SDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Ngành học là bắt buộc.")]
        public string? NganhHoc { get; set; }

        [Required(ErrorMessage = "Điểm TBM 1 là bắt buộc.")]
        [Range(0, 10, ErrorMessage = "Điểm TBM 1 phải trong khoảng từ 0 đến 10.")]
        public decimal? DTB1 { get; set; }

        [Required(ErrorMessage = "Điểm TBM 2 là bắt buộc.")]
        [Range(0, 10, ErrorMessage = "Điểm TBM 2 phải trong khoảng từ 0 đến 10.")]
        public decimal? DTB2 { get; set; }

        [Required(ErrorMessage = "Điểm TBM 3 là bắt buộc.")]
        [Range(0, 10, ErrorMessage = "Điểm TBM 3 phải trong khoảng từ 0 đến 10.")]
        public decimal? DTB3 { get; set; }

        [Required(ErrorMessage = "Xếp loại là bắt buộc.")]
        public string? XepLoai { get; set; }
    }


}
