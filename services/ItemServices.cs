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
        public Item GetById(int id)
        {
            var IdItem = _context.Items.FirstOrDefault(x => x.Id == id);
            if (IdItem != null)
            {
                return IdItem;
            }
            return null;
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

        public bool UpdateItem(Item item)
        {
            try
            {
                var ItemOld = _context.Items.Where(x => x.Id == item.Id).FirstOrDefault();
                if (ItemOld != null)
                {
                    ItemOld.ItemName = item.ItemName;
                    ItemOld.Quantity = item.Quantity;
                    ItemOld.DateExp = item.DateExp;
                    ItemOld.Supplier = item.Supplier;
                    ItemOld.AddressSupp = item.AddressSupp;

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

        public bool DeleteItem(int id)
        {
            try
            {
                var ItemData = _context.Items.FirstOrDefault(x => x.Id == id);

                if (ItemData != null)
                {
                    _context.Items.Remove(ItemData);
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
