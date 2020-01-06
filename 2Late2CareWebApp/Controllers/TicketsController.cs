using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace _2Late2CareWebApp.Controllers
{
    public class TicketsController : ApiController
    {
        // GET api/tickets
        public IEnumerable<string> Get()
        {
            return new string[] { "ticket1\n", "ticket2\n", "ticket3\n" };
        }

        // GET api/tickets/5
        public string Get(int id)
        {
            StringBuilder sbr = new StringBuilder();
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("fr-FR");
            sbr.Append("ticket : ");
            sbr.Append(id);
            sbr.AppendLine();
            sbr.Append(culture.NativeName);
            sbr.AppendLine();
            sbr.Append(localDate.ToString(culture));
            return sbr.ToString();
        }

        // POST api/tickets
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tickets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tickets/5
        public void Delete(int id)
        {
        }
    }
}