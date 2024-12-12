﻿using System.ComponentModel.DataAnnotations;

namespace QuanLiDiem.Models
{
    public class DanhSachSinhVien
    {
        [Key]  // Đánh dấu MSSV là khóa chính
        public string? MSSV { get; set; }  // Mã số sinh viên
        public string? HoTen { get; set; }  // Họ tên
        public string? CCCD { get; set; }  // Căn cước công dân
        public string? SDT { get; set; }  // Số điện thoại
        public string? DiaChi { get; set; }  // Địa chỉ
        public string? NganhHoc { get; set; }  // Mã ngành
        public string? TenTaiKhoan { get; set; }  // Tên tài khoản
        public string? MatKhau { get; set; }  // Mật khẩu
        public string? VaiTro { get; set; }  // Vai trò
    }
}
