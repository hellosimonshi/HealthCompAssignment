using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CustomerDataService;
using CustomerDataService.Interfaces;
using DataAccess.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCompApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    public class CustomersController : ControllerBase
    public class CustomersController : BaseController
    {
        private readonly ICustomerDataService<Customer> customerDataService;
        public CustomersController(ICustomerDataService<Customer> customerDataService)
        {
            this.customerDataService = customerDataService;
            ((ServiceBase)this.customerDataService).Register(this);
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await customerDataService.GetAllAsync();
            return Ok(data);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await customerDataService.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        // POST api/<CustomersController>
        [HttpPost]
//        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            var data = await customerDataService.AddAsync(customer);

            if (modelState != null && !modelState.IsValid)
            {
                return BadRequest(modelState["error"].Errors[0]);
            }
            return Ok(data);
        }

        // PUT api/<CustomersController>
        [HttpPut]
//        [Authorize]
        //public async Task<IActionResult> Update([FromBody] Customer customer)
        //{
        //    var data = await customerDataService.UpdateAsync(customer);
        //    if (!modelState.IsValid)
        //    {
        //        return BadRequest(modelState["error"].Errors[0]);
        //    }

        //    return Ok(data);
        //}
        public IActionResult Update([FromBody] Customer customer)
        {
            var data = customerDataService.Update(customer);
            if (modelState != null && !modelState.IsValid)
            {
                return BadRequest(modelState["error"].Errors[0]);
            }

            return Ok(data);
        }


        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await customerDataService.DeleteAsync(id);
            return Ok(data);
        }
    }
}
