using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    public class SubjectController : Controller
    {
         

        private readonly ToDoDbContext context;
        public SubjectController(ToDoDbContext ctx)
        {
            context = ctx;
        }
        


        [HttpGet]
        public IActionResult CreateSubject()
        {

            return View();
        }
        //

        [HttpPost]
        public async Task<IActionResult> CreateSubject(Subject Subject)
        {                                   
            try
            {
                context.Subjects.Add(Subject);
                await context.SaveChangesAsync();
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(Subject); });
                return RedirectToAction("GetAllSubject");

            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
                return RedirectToAction("Create", script);

            }
        }

        [HttpGet]
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var subjects = context.Subjects.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(subjects); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }

        [HttpGet]
        public async Task<IActionResult> SubjectList()
        {

            IEnumerable<Subject> subjectAll = context.Subjects.ToList();

            try
            {
                //WebService Json Format .
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(subjectAll); });

                //List to The view aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

                return View(await context.Subjects.ToListAsync());

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", e.Message);
            }
        }

        //[HttpGet]

        //public async Task<IActionResult> GetAllSubject()
        //{
        //    IEnumerable<Subject> subjects = context.Subjects.ToList();

        //    try
        //    {
        //        //base
        //        await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(subjects); });


        //        return View(await context.Subjects.ToListAsync());

        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index");
        //    }


        //} 
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



     

    }
}
