using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class WorkingSchedule
    {
        public int ScheduleID { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        [Required(ErrorMessage = "Ngày tạo không được để trống")]
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [StringLength(255, ErrorMessage = "Địa điểm không được vượt quá 255 ký tự")]
        public string Location { get; set; }

        [DataType(DataType.Text)]
        public string Participants { get; set; }

        [DataType(DataType.Text)]
        public string Note { get; set; }
    }
}
