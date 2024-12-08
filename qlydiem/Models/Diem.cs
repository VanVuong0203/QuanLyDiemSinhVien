    using System.ComponentModel.DataAnnotations;

    namespace qlydiem.Models
    {
        public class Diem
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [Display(Name = "Mã số sinh viên")]
            public string MSSV { get; set; }    

            [Required]
            [Display(Name = "Mã học phần")]
            public string MaHP { get; set; }

            [Required]
            [Range(1, 4, ErrorMessage = "Số tín chỉ phải từ 1 đến 4")]
            [Display(Name = "Số tín chỉ")]
            public int SoTinChi { get; set; }

            [Required]
            [Range(0, 10, ErrorMessage = "Điểm quá trình phải từ 0 đến 10")]
            [Display(Name = "Điểm quá trình")]
            public double DiemQuaTrinh { get; set; }  // Thay float bằng double

            [Required]
            [Range(0, 10, ErrorMessage = "Điểm cuối kỳ phải từ 0 đến 10")]
            [Display(Name = "Điểm cuối kỳ")]
            public double DiemCuoiKy { get; set; }  // Thay float bằng double

            // Điểm hệ 10 được tính từ DiemQuaTrinh và DiemCuoiKy
            [Display(Name = "Điểm hệ 10")]
            public double Diem10
            {
                get
                {
                    return (DiemQuaTrinh * 0.3 + DiemCuoiKy * 0.7);
                }
            }

            // Điểm hệ 4 được tính từ Diem10
            [Display(Name = "Điểm hệ 4")]
            public double Diem4
            {
                get
                {
                    if (Diem10 >= 8.5) return 4.0;
                    if (Diem10 >= 8.0) return 3.5;
                    if (Diem10 >= 7.0) return 3.0;
                    if (Diem10 >= 6.5) return 2.5;
                    if (Diem10 >= 5.5) return 2.0;
                    if (Diem10 >= 5.0) return 1.5;
                    if (Diem10 >= 4.0) return 1.0;
                    return 0.0;
                }
            }

            // Kết quả sẽ tính từ điểm hệ 10
            [Display(Name = "Kết quả")]
            public string KetQua
            {
                get
                {
                    return Diem10 >= 4.0 ? "Đạt" : "Không đạt";
                }
            }

            [Required]
            [Display(Name = "Học kỳ")]
            public int HocKy { get; set; }

            [Required]
            [Display(Name = "Năm học")]
            public string NamHoc { get; set; }
        }
    }
