namespace MarketSystemModel
{
    using System.ComponentModel.DataAnnotations;
    public class Measure : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
