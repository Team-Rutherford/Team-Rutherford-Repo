namespace MarketSystemModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VendorExpense
    {
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime? Date { get; set; }
        public double Expenses { get; set; }
    }
}
