using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Model
{
    interface IMArket
    {
        ICollection<Vendor> Vendors { get; }
        ICollection<Product> Products { get; }
        ICollection<Measure> Mesures { get; }
        ICollection<Supermarket> Supermarkets { get; }
    }
}
