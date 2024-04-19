using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvertisementID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự.")]
        public string Title { get; set; }

        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập URL hình ảnh.")]
        [StringLength(255, ErrorMessage = "URL hình ảnh không được vượt quá 255 ký tự.")]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập URL.")]
        [StringLength(255, ErrorMessage = "URL không được vượt quá 255 ký tự.")]
        [DataType(DataType.Url)]
        public string URL { get; set; }
    }
}
