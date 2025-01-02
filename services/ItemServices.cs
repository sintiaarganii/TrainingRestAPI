using Training2.Models.DB;
using Training2.Models;

namespace Training2.services
{
    public class ItemServices
    {
        private readonly ApplicationContext _context;
        public ItemServices(ApplicationContext contex)
        {
            _context = contex;
        }

        public List<Item> GetListItem()
        {
            var datas = _context.Items.ToList();
            return datas;
        }

        public bool AddItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
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
