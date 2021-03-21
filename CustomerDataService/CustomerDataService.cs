using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDataService.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace CustomerDataService
{
    class CustomerDataService : ServiceBase, ICustomerDataService<Customer>
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerDataService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(Customer customer)
        {
            if(await CheckNameDuplicate(customer.Id, customer.Name))
            {
                Controller.modelState.AddModelError("error","name duplicated");
                return -1;
            }
            var data = await unitOfWork.Customers.AddAsync(customer);
            return data;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var data = await unitOfWork.Customers.DeleteAsync(id);
            return data;
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            var data = await unitOfWork.Customers.GetAllAsync();
            return data;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var data = await unitOfWork.Customers.GetByIdAsync(id);
            return data;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            if (await CheckNameDuplicate(customer.Id, customer.Name))
            {
                Controller.modelState.AddModelError("error", "name duplicated");
                return -1;
            }

            var data = await unitOfWork.Customers.UpdateAsync(customer);
            return data;
        }

        private async Task<bool> CheckNameDuplicate(int id, string name)
        {
            var allCustomers = await unitOfWork.Customers.GetAllAsync();

            return allCustomers.Any<Customer>(cust => cust.Id != id && cust.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
