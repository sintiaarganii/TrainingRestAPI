using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Training2.Models;
using Training2.Models.DB;

namespace Training2.services
{
    public class CustomerServices
    {
        private readonly ApplicationContext _context;
        public CustomerServices(ApplicationContext contex)
        {
            _context = contex;
        }

        public List<Customer> GetListCustomers()
        {
            var datas = _context.Customers.ToList();
            return datas;
        }

        public Customer GetById(int id)
        {
            var customerId = _context.Customers.FirstOrDefault(x => x.id == id);
            if(customerId != null)
            {
                return customerId;
            }
            return null;
        }

        public bool createCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.id == customer.id).FirstOrDefault();
                if (customerOld != null)
                {
                    customerOld.nama = customer.nama;
                    customerOld.alamat = customer.alamat;
                    customerOld.city = customer.city;
                    customerOld.PhoneNumber = customer.PhoneNumber;


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
