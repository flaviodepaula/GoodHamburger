using Domain.Customers.DTOs;
using Domain.Support;
using Infra.Common.Result;

namespace Domain.Customers
{
    public record Address
    {
        public string? PostalCode { get; private set; }
        public string? Number { get; private set; }
        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? ReferenceDetails { get; private set; }
        public string? Neighborhood { get; private set; }

        private Address(string? postalCode, string? number, string? street,
                        string? city, string? referenceDetails, string? neighborhood)
        {
            PostalCode = postalCode;
            Number = number;
            Street = street;
            City = city;
            ReferenceDetails = referenceDetails;
            Neighborhood = neighborhood;
        }

        public static Result<Address> NewAddress(string postalCode, string number, string street, 
                                                 string city, string neighborhood, string? referenceDetails)
        {

            var result = IsValidPostalCode(postalCode);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            result = IsValidStreet(street);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);
            
            result = IsValidNumber(number);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);
            
            result = IsValidNeighborhood(neighborhood);            
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);
            
            result = IsValidCity(city);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            return new Address(postalCode, number, street, city, referenceDetails, neighborhood);
        }

        public static Result<Address> NewAddress(AddressDTO? address)
        {
            if(address == null)
                return Result.Failure<Address>(DomainErrors.AddressErrors.InvalidAddress("Address", "address"));

            var result = IsValidPostalCode(address.PostalCode);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            result = IsValidStreet(address.Street);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            result = IsValidNumber(address.Number);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            result = IsValidNeighborhood(address.Neighborhood);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            result = IsValidCity(address.City);
            if (result.IsFailure)
                return Result.Failure<Address>(result.Error);

            return new Address(address.PostalCode, address.Number, address.Street, 
                               address.City, address.ReferenceDetails, address.Neighborhood);
        }

        private static Result<bool> IsValidPostalCode(string? postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
                return Result.Failure<bool>(DomainErrors.AddressErrors.InvalidAddress("PostalCode", "postal code"));

            return true;
        }

        private static Result<bool> IsValidNumber(string? number)
        {
            if (string.IsNullOrEmpty(number))
                return Result.Failure<bool>(DomainErrors.AddressErrors.InvalidAddress("Number", "number"));

            return true;
        }

        private static Result<bool> IsValidStreet(string? street)
        {
            if (string.IsNullOrEmpty(street))
                return Result.Failure<bool>(DomainErrors.AddressErrors.InvalidAddress("Street", "street"));

            return true;
        }

        private static Result<bool> IsValidCity(string? city)
        {
            if (string.IsNullOrEmpty(city))
                return Result.Failure<bool>(DomainErrors.AddressErrors.InvalidAddress("City", "City"));

            return true;
        }

        private static Result<bool> IsValidNeighborhood(string? neighborhood)
        {
            if (string.IsNullOrEmpty(neighborhood))
                return Result.Failure<bool>(DomainErrors.AddressErrors.InvalidAddress("Neighborhood", "neighborhood"));

            return true;
        }
    }
}
