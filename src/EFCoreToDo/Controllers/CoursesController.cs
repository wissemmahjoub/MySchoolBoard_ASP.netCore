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
    public class CoursesController : Controller
    {

        private readonly ToDoDbContext _context;

        public CoursesController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            //var Coursesssss = from m in _context.Courss
            //             select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    Coursesssss = Coursesssss.Where(s => s.Title.Contains(searchString));
            //}
            return View(await _context.Classs.ToListAsync());
            //return View(await Coursesssss.ToListAsync());
        }



        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Courss cr)
        {

            _context.Courss.Add(cr);
            await _context.SaveChangesAsync();
            await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(cr); });
            return RedirectToAction("Index");

        }

        


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Coursess = await _context.Courss.SingleOrDefaultAsync(m => m.id_cours == id);
            if (Coursess == null)
            {
                return NotFound();
            }
            return View(Coursess);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_cours,Description,PublicationDate,Title")] Courss cour)
        {
            if (id != cour.id_cours)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                _context.Update(cour);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index");
            }
            return View(cour);
        }





        public async Task<IActionResult> Delete(int? id)
        {


            var Cours = await _context.Courss.SingleOrDefaultAsync(m => m.id_cours == id);
            if (Cours == null)
            {
                return NotFound();
            }

            return View(Cours);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cours = await _context.Courss.SingleOrDefaultAsync(m => m.id_cours == id);
            _context.Courss.Remove(cours);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }





        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crs = await _context.Courss.SingleOrDefaultAsync(m => m.id_cours == id);
            if (crs == null)
            {
                return NotFound();
            }

            return View(crs);

        }

        private bool CoursExists(int id)
        {
            return _context.Courss.Any(e => e.id_cours == id);
        }

      
    }
}
