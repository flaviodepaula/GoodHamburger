using Infra.Common.Errors;

namespace Application.Errors
{
    public class ApplicationErrors 
    {
        public static readonly Error InvalidList = new("Application.Errors.InvalidList", "There's and invalid item on list. Please check the list of products.");
    }
}
