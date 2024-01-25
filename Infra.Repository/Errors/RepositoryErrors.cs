using Infra.Common.Errors;

namespace Infra.Repository.Errors
{
    public static class RepositoryErrors
    {
        public static Error RequestToDatabaseFailed(string errorMessage)
        {
            return new Error("Repository.Errors.RequestToDatabaseFailed", $"Request to database failed. Message: {errorMessage}.");
        }
    }
}
