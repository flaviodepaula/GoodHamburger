﻿using Domain.Support;
using Infra.Common.Result;
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

        public Guid CustomerId { get => _id; }
        public string Name { get => _name; }
        public Address? Address { get => _address; }
        public string Email { get => _email; }
        public string Phone { get => _phone; }

        private Customer()
        {
            _id = Guid.NewGuid();
        }

        public static Result<Customer> NewCustomer(string name, Address address, string email, string phone)
        {
            Customer customer = new() { 
                _name = name,
                _address = address,
                _email = email,
                _phone = phone
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
         
    }
}
