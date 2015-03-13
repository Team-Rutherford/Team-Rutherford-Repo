namespace MarketSystemModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Design;

    public class Sale : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SupermarketId { get; set; }
        public Supermarket Supermarket { get; set; }
        public double Quantity { get; set; }
    }
}
