using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Repositories.Interface
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Task<IEnumerable<Customer>> GetById(int id);

        int Create(Customer customer);

        int Delete(int id);

        int Update(int id, Customer customer);

    }
}
