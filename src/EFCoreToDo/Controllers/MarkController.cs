using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    public class MarkController : Controller
    {
        private readonly ToDoDbContext _context;
        public MarkController(ToDoDbContext context)
        {
            _context = context;
        }

    

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult AddMark()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> MarkList()
        {

            IEnumerable<Mark> markAll = _context.Marks.ToList();

            try
            {
                //WebService Json Format .
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(markAll); });

                //List to The view

                return View(await _context.Marks.ToListAsync());

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMark(Mark mark)
        {
            try
            {
                _context.Marks.Add(mark);
                await _context.SaveChangesAsync();
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(mark); });
                return RedirectToAction("MarkList");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("MarkList");
            }
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MArks = await _context.Marks.SingleOrDefaultAsync(m => m.MarkId == id);
            if (MArks == null)
            {
                return NotFound();
            }
            return View(MArks);
        }

        // POST: Module/Edit/5 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkId,CC,DS,Exam")] Mark Mar)
        {
            if (id != Mar.MarkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                _context.Update(Mar);
                await _context.SaveChangesAsync();


                return RedirectToAction("MarkList");
            }
            return View(Mar);
        }



        public async Task<IActionResult> Delete(int? id)
        {


            var MarkSelected = await _context.Marks.SingleOrDefaultAsync(m => m.MarkId == id);
            if (MarkSelected == null)
            {
                return RedirectToAction("Error");
            }

            return View(MarkSelected);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var MarkSelected = await _context.Marks.SingleOrDefaultAsync(m => m.MarkId == id);
            _context.Marks.Remove(MarkSelected);
            await _context.SaveChangesAsync();
            return RedirectToAction("MarkList");
        }


        //---------------Web Service (WebApi)-----------

        [HttpGet]
        public async Task<dynamic> GetAllapiMark()
        {
            try
            {
                var MARKList = _context.Marks.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(MARKList); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
            

        }

        //[HttpPost]
        //public async Task<dynamic> CreateApi(Mark mrk)
        //{
        //    try
        //    {
        //        _context.Marks.Add(mrk);
        //        await _context.SaveChangesAsync();
        //        return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(mrk); });
        //    }
        //    catch (Exception ex)
        //    {
        //        var errorMessage = "Failure to POST. Stack Trace: " + ex.StackTrace;
        //        Console.WriteLine(errorMessage);
        //        return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
        //    }
        //}

        //[Route("api/ProductController")]
        [HttpPost]
        public IActionResult Createapi([FromBody] Mark mark)
        {

            if (mark == null)
            {
                return BadRequest();
            }
            
            _context.Add(mark);

            return new ObjectResult("ok");
        }
    }

    //[HttpPost]
    //public async Task<dynamic> CreateApiNote([FromBody]Mark markk)
    //{
    //    try
    //    {
            
    //        _context.Marks.Add(markk);
    //        await Context.SaveChangesAsync();
    //        return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(markk); });
    //    }
    //    catch (Exception ex)
    //    {
    //        var errorMessage = "Failure to POST. Stack Trace: " + ex.StackTrace;
    //        Console.WriteLine(errorMessage);
    //        return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
    //    }
    //}




}
    
