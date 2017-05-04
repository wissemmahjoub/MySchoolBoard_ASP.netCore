using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ClassController : Controller
    {
        private readonly ToDoDbContext _context;

        public ClassController(ToDoDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/ chems

        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            return View(await _context.Classs.ToListAsync());
        }



        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(Classs cl)
        //{

        //    _context.Classs.Add(cl);
        //    await _context.SaveChangesAsync();
        //    await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(cl); });
        //    return RedirectToAction("Index");

        //}

      




        
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var Classes = _context.Classs.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(Classes); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classs.SingleOrDefaultAsync(m => m.ClasssId == id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }

        // POST: Students/Edit/5 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasssId,NbreEtudiants,Speciality,ClasseName,Level")] Classs clas)
        {
            if (id != clas.ClasssId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                _context.Update(clas);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index");
            }
            return View(clas);
        }

        public async Task<IActionResult> Delete(int? id)
        {


            var Classes = await _context.Classs.SingleOrDefaultAsync(m => m.ClasssId == id);
            if (Classes == null)
            {
                return NotFound();
            }

            return View(Classes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classes = await _context.Classs.SingleOrDefaultAsync(m => m.ClasssId == id);
            _context.Classs.Remove(classes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPut]
        public async Task<string> UpdateAPI(Classs c)
        {
            try
            {
                var dbItem = _context.Classs.FirstOrDefault(m => m.ClasssId == c.ClasssId);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to PUT.  Item not found." });
                    });
                }
                dbItem.Level = c.Level;
                dbItem.ClasseName= c.ClasseName;
                dbItem.NbreEtudiants = c.NbreEtudiants;
                dbItem.Speciality = c.Speciality;

                _context.Update(dbItem);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(dbItem);
                });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to PUT. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(new { msg = errorMessage });
                });

            }

        }




        //***************** RESTful webService **********************************************

      




        //***********************************************************************************

        [HttpPost]
        public async Task<dynamic> Create([FromBody]Classs cll)
        {
            try
            {
                _context.Classs.Add(cll);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(cll); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to POST. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }

        //***********************************************************************************

        [HttpPut]
        public async Task<string> EditApi([FromBody]Classs item)
        {
            try
            {
                var dbItem = _context.Classs.FirstOrDefault(m => m.ClasssId == item.ClasssId);

                dbItem.ClasseName = item.ClasseName;
                dbItem.Level = item.Level;
                dbItem.NbreEtudiants = item.NbreEtudiants;
                dbItem.Speciality = item.Speciality;
                _context.Update(dbItem);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(dbItem);
                });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to PUT. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(new { msg = errorMessage });
                });
            }
        }

        //***********************************************************************************
        [HttpDelete]
        public async Task<dynamic> DeleteApi([FromBody] Classs cl)
        {
            try
            {
                var dbItem = _context.Classs.FirstOrDefault(m => m.ClasssId == cl.ClasssId);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.Classs.Remove(dbItem);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(dbItem);
                });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to DELETE. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(new { msg = errorMessage });
                });
            }
        }



    }
}
