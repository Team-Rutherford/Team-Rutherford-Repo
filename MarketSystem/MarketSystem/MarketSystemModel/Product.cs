namespace MarketSystemModel
{
    using System.ComponentModel.DataAnnotations;
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
