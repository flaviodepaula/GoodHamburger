﻿using Domain.Products.Models;

namespace WebApi.Models
{
    public record RequestProductViewModel
    {
        public RequestProductViewModel(IEnumerable<RequestProduct> products)
        {
            Products = products;
        }

        public IEnumerable<RequestProduct> Products { get; set; }        
    }

    public record RequestProduct
    {
        public string Description { get; set; }
        public RequestProduct(string description)
        {
            Description = description;
        }
    }
}
