using CRS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Data.Models
{
   public class Car : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string CarNumber { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public float PurchasePrice { get; set; }
        public DateTime ProductionYear { get; set; }
        [Required]
        public string VinNo { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public CarStatus Status { get; set; }
        public int CarCompanyId { get; set; }
        public CarCompany CarCompany { get; set; }
        public float RentalPrice  { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<Advertisement> Advertisements { get; set; }

        public Car()
        {
            Status = CarStatus.Free;
        }

        
    }
}



