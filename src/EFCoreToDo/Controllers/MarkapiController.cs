using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    [Route("api/[controller]")]
    public class MarkapiController : Controller
    {

        private readonly ToDoDbContext _context;


       /* // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        */

            
                 // GET: api/values
    

        [HttpGet]
        public IEnumerable<Mark> Get()
        {
            var query = from c in _context.Marks
                        orderby c.MarkId ascending
                        select c;
            return query.ToList();
        }
       
          // GET api/values/5
        [HttpGet("{MarkId}")]
        public IEnumerable<Mark> Get(int MarkId)
        {
            var query = from c in _context.Marks
                        orderby c.MarkId ascending
                        where c.MarkId == MarkId
                        select c;
            return query.ToList();
        }



        

       

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //        Mark MRKS = _context.Marks.ToList<>(id);
        //        if (MRKS == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Marks.Remove(MRKS);
        //        _context.SaveChanges();

        //        return Ok(MRKS);
        //    }
        //}
    }
}


