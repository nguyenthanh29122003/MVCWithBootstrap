using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class News
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
        [StringLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập URL hình ảnh.")]
        [StringLength(255, ErrorMessage = "URL hình ảnh không được vượt quá 255 ký tự.")]
        [DataType(DataType.ImageUrl)]
        public string TitleImage { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung.")]
        [AllowHtml]
        public string Content { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày xuất bản.")]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn một danh mục.")]
        public int CategoryID { get; set; }

        // Thuộc tính CategoryName để lưu tên của danh mục
        public string CategoryName { get; set; }
    }
}
