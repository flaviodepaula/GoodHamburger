using Domain.Models.Products;

namespace WebApi.Models
{
    public record RequestOrderModel
    {
        public string Description { get; set; }
        public CategoryOfProduct Category { get; set; }

        public RequestOrderModel(string description, CategoryOfProduct category)
        {
            Description = description;
            Category = category;
        } 
    }
}
