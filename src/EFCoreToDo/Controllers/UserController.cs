using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreToDo.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    public class UserController : Controller
    { 
            private ToDoDbContext context;
     
             
        public UserController(ToDoDbContext ctx)
     {
        context = ctx;
    
    }


    [HttpGet]

    public async Task<IActionResult> GetAllUser()
    {
        IEnumerable<User> users = context.users.ToList();

        try
        {
            //base
            await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(users); });


            return View(await context.users.ToListAsync());

        }
        catch
        {
            return RedirectToAction("Index");
        }


    }
    // GET: /<controller>/
    public IActionResult Index()
    {
        return View();
    }
}
}
