using api.Models;
using api.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);


        public int Create(Customer customer)
        {
            var SP_Name = "SP_InsertCustomer";
            parameters.Add("@name", customer.CustomerName);

            var create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return create;
        }

        public int Delete(int id)
        {
            var SP_Name = "SP_DeleteCustomer";
            parameters.Add("@id", id);

            var delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return delete;
        }

        public int Update(int id, Customer customer)
        {
            var SP_Name = "SP_UpdateCustomer";
            parameters.Add("@id", id);
            parameters.Add("@name", customer.CustomerName);

            var delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return delete;
        }

        public IEnumerable<Customer> GetAll()
        {
            var SP_Name = "SP_RetrieveCustomer";
            var GetAll = connection.Query<Customer>(SP_Name, commandType: CommandType.StoredProcedure);

            return GetAll;
        }

        public async Task<IEnumerable<Customer>> GetById(int id)
        {
            var SP_Name = "SP_RetrieveCustomerById";
            parameters.Add("@id", id);

            var GetById = await connection.QueryAsync<Customer>(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return GetById;
        }
 
    }
}