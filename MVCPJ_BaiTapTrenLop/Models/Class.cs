using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên lớp.")]
        [StringLength(100, ErrorMessage = "Tên lớp không được vượt quá 100 ký tự.")]
        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; }
    }

}