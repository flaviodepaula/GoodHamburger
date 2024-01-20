using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Models
{
    public record Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public CategoryOfProduct Category { get; set; }
    }
}
