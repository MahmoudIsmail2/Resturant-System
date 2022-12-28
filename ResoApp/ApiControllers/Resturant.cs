using Microsoft.AspNetCore.Mvc;
using ResturantApp.Bl;
using ResoApp.Models;
using ResoApp;
using System.Text.Json.Nodes;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Resturant : ControllerBase
    {
         IClsCategories clsTbCategory;
        IClsInvoices clsInvoices;
        public Resturant(IClsCategories _clsTbCategory,IClsInvoices _clsInvoices)
        {
            clsTbCategory = _clsTbCategory;
            clsInvoices = _clsInvoices;
        }
        // GET: api/<Resturant>
        [HttpGet("GetCategories")]
        public List<TbCategory> GetCategoryies()
        {
            try
            {
                var TbCategory = clsTbCategory.GetAll();
                return TbCategory;
            }
            catch
            {
                return new List<TbCategory>();
            }
        }
        [HttpGet("GetOrders")]
        public List<TbInvoice> GetOrders()
        {
            try
            {
                var result= clsInvoices.GetAll();
                return result;
            }
            catch
            {
                return new List<TbInvoice>();
            }
        }

        // GET api/<Resturant>/5
        [HttpGet("{GetCategoryById}/{id}")]
        public List<TbItem> GetCategoryById(int id)
        {
            var lst = clsTbCategory.GetItems(id).ToList();
            return lst;
        }

        //api
        // POST api/<Resturant>
        [HttpPost("Postorder")]
        public void Postorder([FromBody] Sporder result)
        {
            TbInvoice invoice = new TbInvoice();
            invoice.Invoicetotal = result.Count;
            invoice.InvoiceDate = DateTime.Now;
            invoice.InvoiceItems = result.Items;
            clsInvoices.Save(invoice);
        }

        // PUT api/<Resturant>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Resturant>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
