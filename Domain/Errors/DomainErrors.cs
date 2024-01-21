using Infra.Common.Errors;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static readonly Error RequestToDatabaseFailed = new("Domain.Errors.RequestToDatabaseFailed", "Request to database failed.");
        public static readonly Error OrderWithoutProducts = new("Domain.Errors.OrderWithoutProducts", "Can not create a order without products");
        public static readonly Error ProductDoNotExistOnDatabase = new("Domain.Errors.ProductDoNotExistOnDatabase", "Product do not exist on Database.");
        public static readonly Error DuplicatedItems = new("Domain.Errors.DuplicatedItems", "You cannot order more than one product by type.");
        public static readonly Error UnableToRemove = new("Domain.Errors.UnableToRemove", "Unable to remove Order.");
        public static Error PriceWith0ValueOnDatabase(string product)
        {
            return new Error("Domain.Errors.PriceWith0ValueOnDatabase", $"Price with value 0 on database for product {product}.");
        }
        
    }
}
