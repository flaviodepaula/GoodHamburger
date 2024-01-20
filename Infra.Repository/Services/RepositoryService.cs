using AutoMapper;
using Infra.Common.Result;
using Infra.Repository.Interfaces;
using Infra.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Infra.Repository.Services
{
    public class RepositoryService : IRepository
    {
        private readonly ILogger<RepositoryService> _logger;
        private readonly IMapper _mapper;

        public RepositoryService(ILogger<RepositoryService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<Result<Product>> GetProdutcs()
        {
            throw new NotImplementedException();
        }
    }
}
