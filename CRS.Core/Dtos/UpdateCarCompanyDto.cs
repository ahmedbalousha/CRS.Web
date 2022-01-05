using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.Dtos
{
    public class UpdateCarCompanyDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم التصنيف")]
        public string Name { get; set; }
    }
}
