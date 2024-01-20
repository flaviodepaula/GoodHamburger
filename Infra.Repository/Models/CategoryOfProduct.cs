using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Models
{
    public record CategoryOfProduct
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}