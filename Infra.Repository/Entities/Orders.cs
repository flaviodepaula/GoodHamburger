﻿using System.ComponentModel.DataAnnotations;

namespace Infra.Repository.Entities
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }
        public IEnumerable<Products> Products { get; set; }        
        public decimal TotalAmount { get; set; }

        public Orders()
        {
            
        }
    }
}