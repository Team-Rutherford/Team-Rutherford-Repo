using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductName { get; set; }

        public int VendorId { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
