using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Model
{
    public class Supermarket
    {
        private ICollection<Product> products;

        public Supermarket()
        {
            this.products = new HashSet<Product>();
        }
        public ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
        public int Id { get; set; }
        public string SupermarketName { get; set; }

    }
}
