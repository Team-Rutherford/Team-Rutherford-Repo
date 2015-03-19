namespace MarketSystemModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Sale : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int SupermarketId { get; set; }
        public virtual Supermarket Supermarket { get; set; }
        public double Quantity { get; set; }

        public bool Equals(Sale other)
        {
            if ((this.ProductId == other.ProductId) &&
                (this.Date.Date == other.Date.Date) &&
                (this.SupermarketId == other.SupermarketId))
            {
                return true;
            }

            return false;
        }
    }
}
