using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Class1
{
    public interface IProductsApplication
    {
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAndExtrasAsync();
        Task<Result<IEnumerable<Product>>> GetAllSandwichesAsync();
        Task<Result<IEnumerable<Product>>> GetAllExtrasAsync();

    }
}
