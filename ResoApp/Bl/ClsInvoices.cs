using ResoApp;
using ResoApp.Models;

namespace ResturantApp.Bl
{

    public interface IClsInvoices
    {
        public void Save(TbInvoice oinvoice);
        public List<TbInvoice> GetAll();
    }
    public class ClsInvoices : IClsInvoices
    {
        DbResturantContext context;
        public ClsInvoices(DbResturantContext _context)
        {
            context = _context;
        }
        public List<TbInvoice> GetAll()
        {
            try
            {
                var result = context.TbInvoices.ToList();
                return result;
            }
            catch(Exception ex )
            {
                return new List<TbInvoice>();
            }
        }
        public void Save(TbInvoice oinvoice)
        {
            try
            {
                context.TbInvoices.Add(oinvoice);
                context.SaveChanges();  
                    
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
