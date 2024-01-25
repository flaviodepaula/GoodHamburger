﻿using Domain.Models.Products;
using Infra.Common.Result;

namespace Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync(CancellationToken cancellationToken);
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync(CancellationToken cancellationToken);
        Task<Result<IEnumerable<Product>>> GetAllExtrasAsync(CancellationToken cancellationToken);
    }
}
