using CRS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Data.Models
{
    public class CarChangeLog
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public DateTime ChangeAt { get; set; }

        public CarStatus Old { get; set; }

        public CarStatus New { get; set; }
    }
}
