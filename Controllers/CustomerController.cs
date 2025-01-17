﻿using Microsoft.AspNetCore.Mvc;
using Training2.Models;
using Training2.Models.DB;
using Training2.Models.DTO;
using Training2.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _services;
        private object _context;
        private Customer customer;

        public CustomerController(CustomerServices services)
        {
            _services = services;
        }
        // GET: api/<ValuesController>
        //[Route("GetListCustomer")]
        [HttpGet("GetListCustomer")]
        public IActionResult Get()
        {
            try
            {
                var customerList = _services.GetListCustomers();
                var response = new GeneralResponse
                {
                    statusCode = "01",
                    statusDesc = "Success",
                    Data = customerList
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var customerList = _services.GetListCustomers();
                var response = new GeneralResponse
                {
                    statusCode = "99",
                    statusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        //[Route("GetListByID")]
        [HttpGet]
        [Route("getCustomerById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _services.GetCustomerById(id);
                if (customer == null)
                {
                    var responseNotFound = new GeneralResponse
                    {
                        statusCode = "02",
                        statusDesc = "Customer Not Found",
                        Data = null
                    };
                    return NotFound(responseNotFound);
                }

                var responseSuccess = new GeneralResponse
                {
                    statusCode = "01",
                    statusDesc = "Success",
                    Data = customer
                };
                return Ok(responseSuccess);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    statusCode = "99",
                    statusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }

        // POST api/<ValuesController>
        [HttpPost("InsertCustomer")]
        public IActionResult Post(CustomerReqDTO customer) //lebih fleksible 
        {
            try
            {
                var insertCustomer = _services.createCustomer(customer);
                if (insertCustomer)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        statusCode = "01",
                        statusDesc = "insert Customer success",
                        Data = null
                    };
                    return Ok(responseSuccess);
                }
                var responseFailed = new GeneralResponse
                {
                    statusCode = "02",
                    statusDesc = "insert Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    statusCode = "99",
                    statusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }

        
        // PUT api/<ValuesController>/5
        [HttpPut("Update Customer")]
        public IActionResult Put(int Id, CustomerReqDTO customer)
        {
            try {
                var updateCustomer = _services.UpdateCustomer(Id, customer);
                if (updateCustomer)
                {
                    var response = new GeneralResponse
                    {
                        statusCode = "01",
                        statusDesc = "Update Success",
                        Data = null
                    };
                    return Ok(response);
                }

                var responseFail = new GeneralResponse
                {
                    statusCode = "02",
                    statusDesc = "Update Failed",
                    Data = null
                };
                return BadRequest(responseFail);
            }
            catch (Exception ex) {
                var responseFail = new GeneralResponse
                {
                    statusCode = "99",
                    statusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFail);
            }
        }

        // DELETE api/<ValuesController>/5
        //[Route("Delete Customer")]
        [HttpDelete("DeleteCustomer")]
        public IActionResult Delete(int id)
        {
            try
            {
                var DeleteCust = _services.DeleteCustomer(id);
                if (DeleteCust)
                {
                    var response = new GeneralResponse
                    {
                        statusCode = "01",
                        statusDesc = "Delete Success",
                        Data = null
                    };
                    return Ok("success");
                }
                var responsefail = new GeneralResponse
                {

                    statusCode = "02",
                    statusDesc = "Id Not Found",
                    Data = null
                };

                return BadRequest(responsefail);
            }
            catch (Exception ex)
            {
                var responsefail = new GeneralResponse
                {

                    statusCode = "99",
                    statusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responsefail);
            }
        }
    }
}
