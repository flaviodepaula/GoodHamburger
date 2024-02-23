using Infra.Common.Errors;

namespace Infra.Repository.Errors
{
    public static class RepositoryErrors
    {
        public static Error RequestToDatabaseFailed(string errorMessage)
        {
            return new Error("Repository.Errors.RequestToDatabaseFailed", $"Request to database failed. Message: {errorMessage}.");
        }

        public static readonly Error UnableToRemove = new("Repository.Errors.UnableToRemove", "Unable to remove Order.");
        
        public static readonly Error OrderDoesNotExists = new("Repository.Errors.OrderDoesNotExists", "Order does not Exists.");

        public static Error UnableToCreateOrder(string errorMessage) { 
            return new("Repository.Errors.UnableToCreateOrder", $"Unable to create Order. ErrorMessage: {errorMessage}"); 
        }
        public static Error UnableToUpdateOrder(string errorMessage)
        {
            return new("Repository.Errors.UnableToUpdateOrder", $"Unable to update Order. ErrorMessage: {errorMessage}");
        }

        public static Error DeleteGeneralException(string errorMessage){
            return new Error("Repository.Errors.DeleteGeneralException", $"Error on Delete row. Message: {errorMessage}.");
        }


        public static class Customer
        {
            public static readonly Error UserHasOrders = new("Errors.Repository.Customers.UserHasOrders", "Customer has orders and cannot be deleted.");
            
            public static readonly Error UnableToRemove = new("Errors.Repository.Customers.UnableToRemove", "Unable to remove Customer.");
        
            public static readonly Error CustomerDoesNotExists = new("Errors.Repository.Customers.CustomerDoesNotExists", "Customer does not Exists.");
            public static Error UnableToUpdateCustomer(string errorMessage)
            {
                return new("Errors.Repository.Customers.UnableToUpdateCustomer", $"Unable to update Customer. ErrorMessage: {errorMessage}");
            }
            
        }
    }
}
