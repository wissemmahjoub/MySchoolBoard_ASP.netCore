using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Cors;


// For more information on enabling MVC for empty prrojects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    [EnableCors("CorsPolicy")]
    public class HomeworkController : Controller
    {
        private readonly ToDoDbContext _context;

        public HomeworkController(ToDoDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }




        // GET: /<controller>/
        public IActionResult Create()
        {

            // -- liste des modules : pour les envoyer au view 
            // -- de creation d'un Homework

            IEnumerable<Module> modules = _context.Modules.ToList();

            // ---- ici on va prendre la valeur de L'id on affichant
            // ---- le Nom du module (dans le formulaire)

            ViewBag.modules = new SelectList(modules, "ModuleId", "ModuleName");

            return View();
        }




        //[HttpPost]
        //public async Task<IActionResult> Create(Homework homwrkk)
        //{
        //    try
        //    {

        //        _context.Homeworks.Add(homwrkk);
        //        await _context.SaveChangesAsync();
        //        await Task.Factory.StartNew(() => {
        //            _context.Homeworks.Add(homwrkk);
        //            return JsonConvert.SerializeObject(homwrkk);
        //        });
        //        return RedirectToAction("GetAll");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return RedirectToAction("Create");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //List to The view
                return View(await _context.Homeworks.ToListAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // -- liste des modules : pour les envoyer au view 
            // -- de creation d'un Homework

            IEnumerable<Module> modules = _context.Modules.ToList();

            // ---- ici on va prendre la valeur de L'id on affichant
            // ---- le Nom du module (dans le formulaire)

            ViewBag.modules = new SelectList(modules, "ModuleId", "ModuleName");

            var HomeWrkk = await _context.Homeworks.SingleOrDefaultAsync(m => m.HomeworkId == id);
            if (HomeWrkk == null)
            {
                return NotFound();
            }
            return View(HomeWrkk);
        }

        // POST: Homework/Edit/5 




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeworkId,HomeworkDescription,DateLimit,difficulty,Label,idmodule")] Homework homwrk)
        {
            if (id != homwrk.HomeworkId)
            {
                return RedirectToAction("Error");
            }

            if (ModelState.IsValid)
            {
                _context.Update(homwrk);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetAll");
            }
            return View(homwrk);
        }



        public async Task<IActionResult> Delete(int? id)
        {


            var HomeworkSelectionne = await _context.Homeworks.SingleOrDefaultAsync(m => m.HomeworkId == id);
            if (HomeworkSelectionne == null)
            {
                return RedirectToAction("Error");
            }

            return View(HomeworkSelectionne);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var HomeworkSelectionne = await _context.Homeworks.SingleOrDefaultAsync(m => m.HomeworkId == id);
            _context.Homeworks.Remove(HomeworkSelectionne);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }



        public string GetNameModuleById(int id)

        {
            string resut = "";
            IEnumerable<Module> modules = _context.Modules.ToList();
            foreach (var item in modules)
            {
                if (item.ModuleId == id)
                {
                    resut = item.ModuleName;
                }
            }
            return resut;
        }

        public int GetNumberHomeworkByModule(int idMod)
        {
            int result = 0;
            IEnumerable<Homework> allHomwrk = _context.Homeworks.ToList();


            foreach (var item in allHomwrk)
            {
                if (item.idmodule == idMod)
                {
                    result = result + 1;
                }
            }

            return result;
        }


        //**** statistique *****
        [HttpGet]
        public async Task<IActionResult> HomeworkmoduleStat()
        {
            List<Module> modules = await _context.Modules.ToListAsync();

            List<string> NameModule = new List<string> { };
            List<int> NombreHomework = new List<int> { };

            //NameModule.Add("A");
            //NameModule.Add("B");

            //NombreHomework.Add(2);
            //NombreHomework.Add(3);

            //--- remplissage des 2 list :
            // -- list1 : NameModule --> contient la liste des noms des modules
            // -- list2 : NombreHomework --> Contient le nombre de homework de chaque modules
            foreach (var item in modules)
            {
                NameModule.Add(item.ModuleName);
                NombreHomework.Add(GetNumberHomeworkByModule(item.ModuleId));
            }



            // convert it in json
            string dataNameModule = JsonConvert.SerializeObject(NameModule, Formatting.None);
            string dataNombreHomework = JsonConvert.SerializeObject(NombreHomework, Formatting.None);
            // store it in viewdata/ viewbag
            ViewBag.dataNameModule = new HtmlString(dataNameModule);
            ViewBag.dataNombreHomework = new HtmlString(dataNombreHomework);



            return View();
        }


        //***************** RESTful webService **********************************************

        //***********************************************************************************
        [HttpGet]
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var HomeworkAlll = _context.Homeworks.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(HomeworkAlll); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
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

        [HttpDelete("{id}")]
        public IActionResult DeleteApi([FromBody]int id)
        {
            var homewrk = _context.Homeworks.SingleOrDefault(x => x.HomeworkId == id);
            if (homewrk == null)
            {
                return NotFound();
            }
            _context.Homeworks.Remove(homewrk);

            return NoContent();
        }


        //***********************************************************************************

        [HttpPost]
        public async Task<dynamic> Create([FromBody]Homework hmrk)
        {
            try
            {
                _context.Homeworks.Add(hmrk);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(hmrk); });
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
        public async Task<string> EditApi([FromBody]Homework item)
        {
            try
            {
                var dbItem = _context.Homeworks.FirstOrDefault(m => m.HomeworkId == item.HomeworkId);



                dbItem.HomeworkDescription = item.HomeworkDescription;
                dbItem.Label = item.Label;
                dbItem.difficulty = item.difficulty;
                dbItem.DateLimit = item.DateLimit;
                dbItem.idmodule = item.idmodule;
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
        public async Task<dynamic> DeleteApi([FromBody]Homework item)
        {
            try
            {
                var dbItem = _context.Homeworks.FirstOrDefault(m => m.HomeworkId == item.HomeworkId);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.Homeworks.Remove(dbItem);
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
        //--

    }
}
