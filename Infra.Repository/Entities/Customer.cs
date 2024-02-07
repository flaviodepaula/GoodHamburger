﻿namespace Infra.Repository.Entities
{
    public sealed class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address? Address { get; set; }
    }
}
