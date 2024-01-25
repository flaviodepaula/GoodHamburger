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
        
        public static readonly Error UnableToCreateOrder = new("Repository.Errors.UnableToCreateOrder", "Unable to create Order.");

        public static Error GeneralException(string errorMessage)
        {
            return new Error("Repository.Errors.GeneralException", $"Error on Delete row. Message: {errorMessage}.");
        }
    }
}
