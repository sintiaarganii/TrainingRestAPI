using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Training2.Models;
using Training2.Models.DB;
using Training2.Models.DTO;

namespace Training2.services
{
    public class CustomerServices
    {
        private readonly ApplicationContext _context;
        public CustomerServices(ApplicationContext contex)
        {
            _context = contex;
        }

        public List<CustomerDTO> GetListCustomers()
        {
            var datas = _context.Customers.Select(x => new CustomerDTO
            {
                Id = x.id.ToString(),
                nama = x.nama,
                alamat = x.alamat,
                city = x.city,
                PhoneNumber = x.PhoneNumber,
                CreateDate = x.CreateDate != null ? x.CreateDate.Value.ToString("dd/MM/yyyy H:mm:ss") : "",
                UpdateDate = x.UpdateDate != null ? x.UpdateDate.Value.ToString("dd/MM/yyyy H:mm:ss") : "",
            }).ToList();
            return datas;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.id == id);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDTO
            {
                Id = customer.id.ToString(),
                nama = customer.nama,
                alamat = customer.alamat,
                city = customer.city,
                PhoneNumber = customer.PhoneNumber,
                CreateDate = customer.CreateDate != null ? customer.CreateDate.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                UpdateDate = customer.UpdateDate != null ? customer.UpdateDate.Value.ToString("dd/MM/yyy HH:mm:ss") : ""
            };
        }


        public bool createCustomer(CustomerReqDTO customer)
        {
            try
            {
                var insertDataCust = new Customer
                {
                    nama = customer.nama,
                    alamat = customer.alamat,
                    city = customer.city,
                    PhoneNumber = customer.PhoneNumber,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                };

                _context.Customers.Add(insertDataCust);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(int Id, CustomerReqDTO customer)
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.id == Id).FirstOrDefault();

                if (customerOld != null)
                {
                    customerOld.nama = customer.nama;
                    customerOld.alamat = customer.alamat;
                    customerOld.city = customer.city;
                    customerOld.PhoneNumber = customer.PhoneNumber;
                    customerOld.CreateDate = customerOld.CreateDate;
                    customerOld.UpdateDate = DateTime.Now;

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var customerData = _context.Customers.FirstOrDefault(x => x.id == id);

                if (customerData != null)
                {
                    _context.Customers.Remove(customerData);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
