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
    // [EnableCors("AllowSpecificOrigin")]
    [EnableCors("CorsPolicy")]
    public class ModuleController : Controller
    {
        private readonly ToDoDbContext _context;
        //hh
        public ModuleController(ToDoDbContext context)
        {
            _context = context;
        }
        //-

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            IEnumerable<Module> modulesss = _context.Modules.ToList();

            try
            {
                //WebService Json Format .
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(modulesss); });

                //List to The view
                return View(await _context.Modules.ToListAsync());

            }
            catch
            {
                return View(await _context.Modules.ToListAsync());
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MOdules = await _context.Modules.SingleOrDefaultAsync(m => m.ModuleId == id);
            if (MOdules == null)
            {
                return NotFound();
            }
            return View(MOdules);
        }

        // POST: Module/Edit/5 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModuleId,ModuleName,ModuleCoeif")] Module Modu)
        {
            if (id != Modu.ModuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                _context.Update(Modu);
                await _context.SaveChangesAsync();


                return RedirectToAction("GetAll");
            }
            return View(Modu);
        }

        //retourner view de confirmation de la suppression 

        public async Task<IActionResult> Delete(int? id)
        {


            var ModuleSelectionne = await _context.Modules.SingleOrDefaultAsync(m => m.ModuleId == id);
            if (ModuleSelectionne == null)
            {
                return RedirectToAction("Error");
            }

            return View(ModuleSelectionne);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //---> contre des attaques type XSRF.
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var MOduleSelectionne = await _context.Modules.SingleOrDefaultAsync(m => m.ModuleId == id);
            _context.Modules.Remove(MOduleSelectionne);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }


        [HttpGet]
        public async Task<IActionResult> ListeHomeworkByModul(int? id)
        {
            List<Homework> AllModules = await _context.Homeworks.ToListAsync();
            List<Homework> Homworkfiltree = new List<Homework> { };

            foreach (var item in AllModules)
            {
                if (item.idmodule == id)
                {
                    Homworkfiltree.Add(item);
                }
            }
            return View(Homworkfiltree);
        }

        //*

        //***************** RESTful webService **********************************************

        //***********************************************************************************
        [HttpGet]
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var ModuleList = _context.Modules.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(ModuleList); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }
        //***********************************************************************************

        [HttpGet]
        public async Task<dynamic> ListeHomeworkByModulApi([FromBody]int? id)
        {


            List<Homework> AllModules = await _context.Homeworks.ToListAsync();
            List<Homework> Homworkfiltree = new List<Homework> { };

            foreach (var item in AllModules)
            {
                if (item.idmodule == id)
                {
                    Homworkfiltree.Add(item);
                }

            }

            try
            {

                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(Homworkfiltree); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }




        //***********************************************************************************

        [HttpPost]
        public async Task<dynamic> Create([FromBody]Module mdl)
        {
            try
            {
                _context.Modules.Add(mdl);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(mdl); });
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
        public async Task<string> EditApi([FromBody]Module item)
        {
            try
            {
                var dbItem = _context.Modules.FirstOrDefault(m => m.ModuleId == item.ModuleId);



                dbItem.ModuleCoeif = item.ModuleCoeif;
                dbItem.ModuleName = item.ModuleName;
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
        public async Task<dynamic> DeleteApii([FromBody]Module mod)
        {
            try
            {
                var dbItem = _context.Modules.FirstOrDefault(m => m.ModuleId == mod.ModuleId);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.Modules.Remove(dbItem);
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



        //***********************************************************************************
        [HttpDelete("{id}")]
        public async Task<dynamic> DeleteApiid([FromBody]int id)
        {
            try
            {
                var dbItem = _context.Modules.FirstOrDefault(m => m.ModuleId == id);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.Modules.Remove(dbItem);
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


