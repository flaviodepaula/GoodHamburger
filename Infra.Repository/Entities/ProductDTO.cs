using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public record ProductDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public CategoryOfProduct Category { get; set; }
    }
}
