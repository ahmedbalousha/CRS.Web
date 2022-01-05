using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.Dtos
{
   public class UpdateContractDto
    {
        
        public int Id { get; set; }
        [Display(Name = "صورة اتفاقية التاجير")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إجمالي سعر التأجير")]
        public float Price { get; set; }
        [Display(Name = "بداية تنفيذ الإتفاقية")]
        public DateTime StartDate { get; set; }
        [Display(Name = "نهاية تنفيذ الإتفاقية")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "السيارة")]
        public int CarId { get; set; }
        [Display(Name = "العميل المستأجر")]
        public string CustomerId { get; set; }
    }
}
