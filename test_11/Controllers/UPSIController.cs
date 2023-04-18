using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test_11;

namespace test_11.Controllers
{
    public class UPSIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<UPSI> Get()
        {
            return UPSIData.UPSIs;
        }

        // GET api/<controller>/5
        public UPSI Get(int id)
        {
            return UPSIData.UPSIs.FirstOrDefault(u => u.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]UPSI value)
        {
            UPSIData.UPSIs.Add(value);
            //save to database
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]UPSI value)
        {
            var upsi = UPSIData.UPSIs.FirstOrDefault(u => u.Id == id);
            upsi.Name = value.Name;
            upsi.Description = value.Description;

            //save to database
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var upsi = UPSIData.UPSIs.FirstOrDefault(u => u.Id == id);
            UPSIData.UPSIs.Remove(upsi);

            //delete from database
        }
    }
}