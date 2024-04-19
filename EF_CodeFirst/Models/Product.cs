using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models
{
    public class Product
    {
        [Key]//Khoa chinh
        public long ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Không thể để trống tên sản phẩm")]// Bat buoc phai nhap
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Cannot use special charecters in Product name.")] //Regex
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 charecters")]
        public string ProductName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]// Format
        [Required]
        [Range(0, 100000, ErrorMessage = "Giá sản phẩm phải trong khoảng 0 - 100.000")]
        public Nullable<decimal> Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]// Format
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }

        [Required]
        public Nullable<long> CategoryID { get; set; }

        [Required]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<long> Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}