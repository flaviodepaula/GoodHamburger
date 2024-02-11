namespace Infra.Repository.Entities
{
    public class Address 
    {
        public string? PostalCode { get; set; }        
        public string? Number { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }        
        public string? ReferenceDetails { get; set; }
        public string? Neighborhood { get; set; }
        
    }
}