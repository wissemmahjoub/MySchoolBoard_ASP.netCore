using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    public class CommentController : Controller

    
    {
        private readonly ToDoDbContext context;
         
    
        public CommentController(ToDoDbContext ctx)
        {
            context = ctx;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



         
        public IActionResult Create()
        {

           
            IEnumerable<Subject> subjects = context.Subjects.ToList();
 

            ViewBag.subjects = new SelectList(subjects, "SubjectId", "SubjectId");

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Comment comm)
        {
            try
            {   //  context.Comments.Add(comm);

                context.Comments.Add(comm);
                await context.SaveChangesAsync();
                await Task.Factory.StartNew(() => {
                    context.Comments.Add(comm);
                    return JsonConvert.SerializeObject(comm);
                });
                return RedirectToAction("GetAllComment");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Create");
            }
        }


        // ***************************************************

        
        public IActionResult CreateComment()
        {
            //IEnumerable<Subject> subjects = context.Subjects.ToList();


            //ViewBag.subjects = new SelectList(subjects, "SubjectId", "SubjectId");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comm)
        {
            try
            {
                context.Comments.Add(comm);
               // context.Comments.Add(comm);
                await context.SaveChangesAsync();
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(comm); });
                return RedirectToAction("GetAllComment");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("CreateComment");
            }
        }

        //***************************************

        [HttpPost]
        public async Task<dynamic> Createsub(Comment co)
        {
            try
            {
                context.Comments.Add(co);
                await context.SaveChangesAsync();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(co); });
            }
            catch (Exception ex)
            {
                var errorMessage = "can t post error" + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }



        //*****************************************

        [HttpGet]
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var comments = context.Comments.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(comments); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetAllComment()
        {

           // IEnumerable<Subject> subjects = context.Subjects.ToList();
            IEnumerable<Comment> comments = context.Comments.ToList();

            try
            {
                //base
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(comments); });


                return View(await context.Comments.ToListAsync());

            }
            catch
            {
                return RedirectToAction("Index");
            }


        }

    }
}
