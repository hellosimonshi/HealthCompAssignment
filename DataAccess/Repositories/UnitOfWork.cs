using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICustomerRepository customerRepository)
        {
            Customers = customerRepository;
        }
        public ICustomerRepository Customers { get; }
    }
}
