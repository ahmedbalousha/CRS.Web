using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.Dtos
{
    
   public class CreateContractDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة اتفاقية التاجير")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إجمالي سعر التأجير")]
        public float Price { get; set; }
        [Display(Name = "بداية تنفيذ الإتفاقية")]
        public DateTime StartDate { get; set; }
        [Display(Name = "نهاية تنفيذ الإتفاقية")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "السيارة")]
        public int CarId { get; set; }
        public CreateUserDto Customer { get; set; }
        [Display(Name = "العميل المستأجر")]
        public string CustomerId { get; set; }
    }
}
