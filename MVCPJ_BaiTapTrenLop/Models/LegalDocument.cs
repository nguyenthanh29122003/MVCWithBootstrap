using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class LegalDocument
    {
        public int DocumentID { get; set; }

        [Display(Name = "Số hiệu")]
        public string SerialNumber { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống.")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống.")]
        public string Content { get; set; }

        [Display(Name = "Tóm tắt")]
        public string Summary { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Đường dẫn tệp")]
        [Required(ErrorMessage = "Đường dẫn tệp không được để trống.")]
        public string FilePath { get; set; }
    }
}
