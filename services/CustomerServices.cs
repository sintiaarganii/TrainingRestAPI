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
    }
}
