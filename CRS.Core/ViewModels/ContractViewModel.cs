using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.ViewModels
{
   public class ContractViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public CarViewModel Car { get; set; }
        public UserViewModel Customer { get; set; }
    }
}
