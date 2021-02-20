using api.Models;
using api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace api.Controllers
{
    public class CustomersController : ApiController
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public IHttpActionResult Get()
        {
            var result = customerRepository.GetAll();

            return Ok(result);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await customerRepository.GetById(id);

            return Ok(result);
        }

        public IHttpActionResult Create(Customer customer)
        {
            var result = customerRepository.Create(customer);

            return Ok("Berhasil Membuat Customer Baru");
        }

        public IHttpActionResult Delete(int id)
        {
            var result = customerRepository.Delete(id);

            return Ok("Berhasil Menghapus Customer");
        }

        public IHttpActionResult Put(int id, Customer customer)
        {
            var result = customerRepository.Update(id, customer);

            return Ok("Berhasil Mengupdate Data Customer");
        }

    }
}
