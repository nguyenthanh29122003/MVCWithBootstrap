using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ.")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Đường dẫn ảnh")]
        public string ImagePath { get; set; }

        [Display(Name = "Phòng ban")]
        [Required(ErrorMessage = "Vui lòng nhập phòng ban.")]
        public string Department { get; set; }
    }
}
