using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using my_pospointe.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_pospointe.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET: api/<TransactionsController>
        [HttpGet("{startdate}/{enddate}")]
        public IEnumerable<TblTransMain> Get(DateTime startdate ,DateTime enddate)
        {
            const string HeaderKeyName = "db";
            Request.Headers.TryGetValue(HeaderKeyName, out StringValues dbvalue);
            using (var context = new _167Context("Server=" + clsConnections.server + "," + clsConnections.port + ";Initial Catalog=" + dbvalue + ";Persist Security Info=False;User ID=" + clsConnections.username + ";Password=" + clsConnections.password + ";Connection Timeout=30;Encrypt=True;TrustServerCertificate=True"))
            {
               // return context.TblTransMains.ToList();
               return context.TblTransMains.Where(x => x.SaleDate >= startdate && x.SaleDate <= enddate).ToList();
            }
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public TblTransMain Get(int id)
        {
            const string HeaderKeyName = "db";
            Request.Headers.TryGetValue(HeaderKeyName, out StringValues dbvalue);
            using (var context = new _167Context("Server=" + clsConnections.server + "," + clsConnections.port + ";Initial Catalog=" + dbvalue + ";Persist Security Info=False;User ID=" + clsConnections.username + ";Password=" + clsConnections.password + ";Connection Timeout=30;Encrypt=True;TrustServerCertificate=True"))
            {
                return context.TblTransMains.FirstOrDefault(item => item.InvoiceId == id);

            }
        }

        //// POST api/<TransactionsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TransactionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TransactionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
