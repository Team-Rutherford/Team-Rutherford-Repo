﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MarketSystemModel
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public double TaxPercentage { get; set; }
    }
}
