using Domain.Dtos;
using Infrastructure.CustomerService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController
    {
        private CustomersService _customerService;

        public CustomersController()
        {
            _customerService = new CustomersService();
        }


        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }
        [HttpPost("Insert")]
        public int InsertCustomer(Customer customer)
        {
            return _customerService.InsertCustomer(customer);
        }

        [HttpPut]
        public int UpdateCustomer(Customer customer)
        {
            return _customerService.UpdateCustomer(customer);
        }

        [HttpDelete]
        public int DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }



    }
}
