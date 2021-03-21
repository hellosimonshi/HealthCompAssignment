using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace CustomerDataService.Interfaces
{
    public interface ICustomerDataService<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        int Update(Customer customer);
        Task<int> DeleteAsync(int id);
    }
}
