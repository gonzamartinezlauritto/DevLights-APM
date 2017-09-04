
using APM.WebApi.Models;
using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using Models = APM.WebAPI.Models;
namespace APM.WebApi.Controllers
{
    [EnableCors("http://localhost:57427", "*", "*")]
    public class SalesController : ApiController
    {
        //// GET: api/Sales
        //[EnableQuery()]
        //public IQueryable <Sale> Get()
        //{
        //    var productRepository = new SaleRepository();
        //    return productRepository.Retrieve().AsQueryable();
        //}


        // GET: api/Sales/5
        public Sale Get(int id)
        {
            
            return new Sale();
        }

        //// POST: api/Sales
        //public void Post([FromBody]Sale product)
        //{
        //    var productRepository = new SaleRepository();
        //    var newPrdoduct = productRepository.Create(product);
        //}

        //// PUT: api/Sales/5
        //public void Put(int id, [FromBody]Sale product)
        //{
        //    var productRepository = new SaleRepository();
        //    var updateSale = productRepository.Save(product);
        //}

        //// DELETE: api/Sales/5
        //public void Delete(int id)
        //{
        //    var productRepository = new SaleRepository();
        //    var deleteSale = productRepository.Dalete(id);
        //}
    }
}
