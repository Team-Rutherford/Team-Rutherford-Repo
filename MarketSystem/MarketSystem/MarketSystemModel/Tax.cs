using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MarketSystemModel
{
    class Tax
    {
        [Key]
        public int Id { get; set; }
        public float TaxPercentage { get; set; }
    }
}
