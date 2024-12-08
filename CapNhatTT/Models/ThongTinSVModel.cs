using System.ComponentModel.DataAnnotations;

namespace CapNhatTT_Demo.Models
{
    public class ThongTinSVModel
    {
        public int Id { get; set; }

        

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Tên là bắt buộc.")]
        public string Name { get; set; }

        

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số.")]
        public string Phone { get; set; }


        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string Address { get; set; }



        [Display(Name = "CMND/CCCD")]
        [Required(ErrorMessage = "CMND là bắt buộc.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "CMND phải có đúng 12 chữ số.")]
        public string CMND { get; set; }
    }
}
