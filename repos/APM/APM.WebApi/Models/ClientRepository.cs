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
    public class ClientRepository
    {
        /// <summary>
        /// Creates a new client with default values
        /// </summary>
        /// <returns></returns>
        internal Client Create(Client client)
        {
           
            using (var db = new APMEntities())
            {
                //Add Student object into Students DBset
                db.Clients.Add(client);

                // call SaveChanges method to save student into database
                db.SaveChanges();
                return client;
            }





        }

        /// <summary>
        /// Retrieves the list of clients.
        /// </summary>
        /// <returns></returns>
        internal List<Client> Retrieve()
        {
           
            using (var db = new APMEntities())
            {
                return db.Clients.ToList();


            }



        }

        /// <summary>
        /// Saves a new client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        internal Client Save(Client client)
        {
            using (var db = new APMEntities())
            {
                //Add Student object into Students DBset
                //db.Clients.Update(client);
                db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                // call SaveChanges method to save student into database
                db.SaveChanges();
                return client;
            }

         
        }


        internal Client Dalete(int id)
        {

            Client prod;

            using (var dbCtx = new APMEntities())
            {
                //var clients = this.Retrieve();
                
                prod = dbCtx.Clients.Where(p => p.ClientId == id).FirstOrDefault<Client>();
                //var toremove = clients.FirstOrDefault(p => p.ClientId == id);
                dbCtx.Entry(prod).State = System.Data.Entity.EntityState.Deleted;
                // call SaveChanges method to save student into database
                dbCtx.SaveChanges();

                return prod;
            }

        }

        private bool WriteData(List<Client> clients)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/client.json");

            var json = JsonConvert.SerializeObject(clients, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }


    }
}
