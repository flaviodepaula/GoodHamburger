using Infra.Common.Errors;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static readonly Error RequestToDatabaseFailed = new("Domain.Errors", "Request to database failed.");
        public static readonly Error ProductDoNotExistOnDatabase = new("Domain.Errors", "Product do not exist on Database.");
        public static Error PriceWith0ValueOnDatabase(string product)
        {
            return new Error("Domain.Errors", $"Price with value 0 on database for product {product}.");
        }
        
    }
}
