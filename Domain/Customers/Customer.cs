using Domain.Customers.DTOs;
using Domain.Support;
using Infra.Common.Result;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Domain.Customers
{
    public class Customer
    {
        private readonly Guid _id;
        private string _name;
        private string _email;
        private string _phone;
        private Address _address;
        private bool _actived;

        public Guid CustomerId { get => _id; }
        public string Name { get => _name; }
        public Address? Address { get => _address; }
        public string Email { get => _email; }
        public string Phone { get => _phone; }
        public bool Actived { get => _actived; }

        private Customer()
        {
            _id = Guid.NewGuid();
        }

        public static Result<Customer> NewCustomer(string name, Address address, string email, string phone, bool actived)
        {
            Customer customer = new() { 
                _name = name,
                _address = address,
                _email = email,
                _phone = phone,
                _actived = actived
            };

            var result = customer.IsValid();
            if (result.IsFailure)
                return Result.Failure<Customer>(result.Error);

            return customer;
        }

        private Result<bool> IsValid()
        {
            if(!IsEmailValid())
                return Result.Failure<bool>(DomainErrors.CustomerErrors.InvalidEmail);
            if(!IsPhoneValid())
                return Result.Failure<bool>(DomainErrors.CustomerErrors.InvalidPhone);

            return true;
        }

        private bool IsEmailValid()
        {
            string emailRegex = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";

            if (!Regex.Match(_email, emailRegex).Success)
                return false;

            return true;
        }
        
        private bool IsPhoneValid()
        {
            string phoneRegex = @"/^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$/";

            if (!Regex.Match(_phone, phoneRegex).Success)
                return false;

            return true;
        }
        
        public CustomerDTO ToCustomerDTO()
        {
            CustomerDTO dto = new();
            dto.Name = this.Name;
            dto.CustomerId = this.CustomerId;            
            dto.Email = this.Email;
            dto.Phone = this.Phone;

            AddressDTO addressDTO = new()
            {
                Neighborhood = this.Address!.Neighborhood,
                Number = this.Address!.Number,
                ReferenceDetails = this.Address!.ReferenceDetails,
                City = this.Address!.City,
                PostalCode = this.Address!.PostalCode
            };

            dto.Address = addressDTO;

            return dto;
        }
    }
}
