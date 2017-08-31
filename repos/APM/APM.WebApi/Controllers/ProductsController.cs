
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
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        public IQueryable <Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }


        // GET: api/Products/5
        public Product Get(int id)
        {
            var productRepository = new ProductRepository();

            var products = productRepository.Retrieve();

            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                product = new Product();
            }

            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var newPrdoduct = productRepository.Create(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var updateProduct = productRepository.Save(product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            var productRepository = new ProductRepository();
            var deleteProduct = productRepository.Dalete(id);
        }
    }
}
