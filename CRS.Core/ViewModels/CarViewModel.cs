using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.ViewModels
{
   public class CarViewModel
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }

        public float  PurchasePrice { get; set; }
        public string ProductionYear { get; set; }
        public string VinNo { get; set; }
        public string ImageUrl { get; set; }
        public UserViewModel Owner { get; set; }
        public string Status { get; set; }
        public CarCompanyViewModel CarCompany { get; set; }
        public float RentalPrice { get; set; }
        

    }
}
