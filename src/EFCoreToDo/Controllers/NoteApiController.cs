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
    public class NoteApiController : Controller
    {
        private readonly ToDoDbContext _context;

        //
        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<Mark> Get()
        //{ var query = from c in _context.Marks
        //              orderby c.MarkId ascending
        //              select c;
        //    return query.ToList();
        //}
        // Get All
        // api/Product
        //[HttpGet]
        //public IEnumerable<Mark> GetAll()
        //{
        //    return _context.GetAll(); ;
        //}
        //

        // Get All
        // api/Product
        //[HttpGet]
        //public IEnumerable<Mark> GetAll()
        //{
        //    return _context.GeAll();
        //}
        //// Get by Id
        //// api/Product/id
        //[HttpGet("{IdProd}", Name = "GetProduct")]
        //public IActionResult GetById(int MarkId)
        //{
        //    var product = _context.Find(MarkId)
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(Mark);
        //}

        /*// GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Mark> Get(int id)
        {
            var query = from c in _context.Marks
                        orderby c.MarkId ascending
                        where c.MarkId == id
                        select c;
            return query.ToList();
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
          public string Get(int id)
          {
              return "value";
          }
          

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        // Add

        //[Route("api/MarkController")]
        [HttpPost]
        public IActionResult Create([FromBody] Mark mark)
        {

            if (mark == null)
            {
                return BadRequest();
            }

            _context.Add(mark);

            return new ObjectResult("ok");
        }
        //[Route("api/MarkController")]
        [HttpPost]
        public IActionResult Createapi([FromBody] Mark mark)
        {
            //
            if (mark == null)
            {
                return BadRequest();
            }

            _context.Add(mark);

            return new ObjectResult("ok");
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
