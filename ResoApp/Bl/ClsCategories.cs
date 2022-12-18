using ResoApp;
using ResoApp.Models;
namespace ResturantApp.Bl
{
    public interface IClsCategories
    {
        public List<TbCategory> GetAll();
        public List<TbItem> GetItems(int id);

    }
    public class ClsCategories : IClsCategories
    {
        DbResturantContext context;
        public ClsCategories(DbResturantContext _context)
        {
            context = _context;
        }
        public List<TbCategory> GetAll()
        {
            try
            {
                var categories = context.TbCategories.ToList();
                return categories;
            }
            catch (Exception ex)
            {
                return new List<TbCategory>();
            }
        }
        public List<TbItem> GetItems(int id)
        {
            try
            {
                var lstitems = context.TbItems.Where(a => a.Categoryid == id).ToList();

                return lstitems;
            }
            catch (Exception ex)
            {
                return new List<TbItem>();
            }
        }
    }
}
