using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public record CategoryOfProduct
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ProductDTO Product { get; set; }
    }
}