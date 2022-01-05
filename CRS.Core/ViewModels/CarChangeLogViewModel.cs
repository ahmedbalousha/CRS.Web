using CRS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Core.ViewModels
{
    public class CarChangeLogViewModel
    {
        public DateTime ChangeAt { get; set; }

        public CarStatus Old { get; set; }

        public CarStatus New { get; set; }
    }
}
