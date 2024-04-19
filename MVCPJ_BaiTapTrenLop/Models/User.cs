using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Không để trống tên tài khoản.")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự.")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Không để trống mật khẩu.")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải từ 1 đến 100 ký tự.", MinimumLength = 1)]
        public string Password { get; set; }

        [StringLength(100, ErrorMessage = "Họ và tên không được quá 100 ký tự.")]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "Đường dẫn ảnh đại diện không được quá 100 ký tự.")]
        public string Avatar { get; set; }

        [Required(ErrorMessage = "Không để trống.")]
        [StringLength(100, ErrorMessage = "Email phải từ 1 đến 100 ký tự.", MinimumLength = 1)]
        [EmailAddress(ErrorMessage = "Không đúng định dạng Email.")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Số điện thoại không được quá 100 ký tự.")]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không được quá 200 ký tự.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Không để trống.")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
