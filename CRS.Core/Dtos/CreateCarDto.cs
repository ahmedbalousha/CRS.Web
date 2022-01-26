using CRS.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.Dtos
{
   public class CreateCarDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم السيارة")]
        public string CarNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "لون السيارة")]
        public string Color { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع السيارة")]
        public string Type { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "سعر شراء السيارة")]
        public float PurchasePrice { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "موديل السيارة")]
        [DataType(DataType.Date)]
        public DateTime ProductionYear { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم الشاصي السيارة")]
        public string VinNo { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة السيارة")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "مالك السيارة")]
        public string OwnerId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "شركة السيارة")]
        public int CarCompanyId { get; set; }
        [Display(Name = "سعر تأجير السيارة")]
        public float RentalPrice { get; set; }
        
        
    }
}
