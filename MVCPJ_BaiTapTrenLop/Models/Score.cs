using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCPJ_BaiTapTrenLop.Models
{
    public class Score
    {
        [Key]
        public int ScoreID { get; set; }

        [Display(Name = "Môn học")]
        [Required(ErrorMessage = "Vui lòng nhập môn học.")]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        [Display(Name = "Lớp học")]
        [Required(ErrorMessage = "Vui lòng nhập lớp học.")]
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        [Display(Name = "Ảnh điểm")]
        public string ScoreImage { get; set; }
    }
}