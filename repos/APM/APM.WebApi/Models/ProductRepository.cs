using APM.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace APM.WebAPI.Models
{
    /// <summary>
    /// Stores the data in a json file so that no database is required for this
    /// sample application
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// Creates a new product with default values
        /// </summary>
        /// <returns></returns>
        internal Product Create(Product product)
        {
            //Product product = new Product
            //{
            //    ReleaseDate = DateTime.Now
            //};
            product.ReleaseDate = DateTime.Now;

            using (var db = new APMEntities())
            {
                //Add Student object into Students DBset
                db.Products.Add(product);

                // call SaveChanges method to save student into database
                db.SaveChanges();
                return product;
            }





        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Product> Retrieve()
        {
            // var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

            //var json = System.IO.File.ReadAllText(filePath);

            //var products = JsonConvert.DeserializeObject<List<Product>>(json);

            //return products;

            using (var db = new APMEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                return db.Products.ToList();


            }



        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Product Save(Product product)
        {
            using (var db = new APMEntities())
            {
                //Add Student object into Students DBset
                //db.Products.Update(product);
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                // call SaveChanges method to save student into database
                db.SaveChanges();
                return product;
            }

            // Read in the existing products
            //var products = this.Retrieve();

            // Assign a new Id
            //var maxId = products.Max(p => p.ProductId);
            //product.ProductId = maxId + 1;
            //products.Add(product);

            //WriteData(products);
            //return product;
        }


        internal Product Dalete(int id)
        {

            Product prod;

            using (var dbCtx = new APMEntities())
            {
                //var products = this.Retrieve();
                
                prod = dbCtx.Products.Where(p => p.ProductId == id).FirstOrDefault<Product>();
                //var toremove = products.FirstOrDefault(p => p.ProductId == id);
                dbCtx.Entry(prod).State = System.Data.Entity.EntityState.Deleted;
                // call SaveChanges method to save student into database
                dbCtx.SaveChanges();

                return prod;
            }

        }



        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        //    internal Product Save(int id, Product product)
        //{
        //    // Read in the existing products
        //    var products = this.Retrieve();

        //    // Locate and replace the item
        //    var itemIndex = products.FindIndex(p => p.ProductId == product.ProductId);
        //    if (itemIndex > 0)
        //    {
        //        products[itemIndex] = product;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    WriteData(products);
        //    return product;
        //}

        private bool WriteData(List<Product> products)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }







    }
}
