using Infra.Common.Errors;

namespace Domain.Support
{
    public static class DomainErrors
    {
        public static class OrderErrors
        {
            public static readonly Error RequestToDatabaseFailed = new("Domain.Errors.RequestToDatabaseFailed", "Request to database failed.");
            public static readonly Error OrderWithoutProducts = new("Domain.Errors.OrderWithoutProducts", "Can not create a order without products");
            public static readonly Error DuplicatedItems = new("Domain.Errors.DuplicatedItems", "You cannot order more than one product by type.");
            public static readonly Error UnableToRemove = new("Domain.Errors.UnableToRemove", "Unable to remove Order.");

        }
        public static class ProductErrors
        { 
            public static readonly Error ProductDoNotExistOnDatabase = new("Domain.Errors.ProductDoNotExistOnDatabase", "Product do not exist on Database.");
            public static Error PriceWith0ValueOnDatabase(string product)
            {
                return new Error("Domain.Errors.PriceWith0ValueOnDatabase", $"Price with value 0 on database for product {product}.");
            }
        }

        public static class CustomerErrors 
        {
            public static readonly Error InvalidEmail = new("Domain.CustomerErrors.InvalidEmail", "Invalid e-mail, please verify it.");
            public static readonly Error InvalidPhone = new("Domain.CustomerErrors.InvalidPhone", "Invalid phone number, please verify it.");
            public static readonly Error InvalidName = new("Domain.CustomerErrors.InvalidName", "Invalid name, please verify it.");
        }

        public static class AddressErrors
        {
            public static Error InvalidAddress(string fieldName, string fieldText)
            {
                return new($"Domain.Address.{fieldName}", $"Invalid {fieldText}, please verify it.");
            }            
        }
    }
}
