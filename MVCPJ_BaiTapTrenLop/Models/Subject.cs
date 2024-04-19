using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên môn học.")]
        [StringLength(100, ErrorMessage = "Tên môn học không được vượt quá 100 ký tự.")]
        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Giá")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Giá tiền phải là một số hợp lệ.")]
        public decimal Price { get; set; }
    }
}