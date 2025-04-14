using Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IConfiguration _configuration;
        public ServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
