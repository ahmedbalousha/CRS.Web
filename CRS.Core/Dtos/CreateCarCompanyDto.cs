using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.Dtos
{
    public class CreateCarCompanyDto
    {
        [Required]
        [Display(Name = "اسم الشركة")]
        public string Name { get; set; }
    }
}
