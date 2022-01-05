using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Data.Models
{
   public class Contract : BaseEntity
    {
        public int Id { get; set; }
        [Required]
       
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        //public string CarRentalId { get; set; }
        //public User CarRental { get; set; }
        public string CustomerId { get; set; }
        public User Customer { get; set; }
    }
}
