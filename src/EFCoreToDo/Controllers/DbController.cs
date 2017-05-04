
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EFCoreToDo.Models;

namespace EFCoreToDo.Controllers
{
    public class DbController : Controller
    {
        private readonly ToDoDbContext _context;

        public DbController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<dynamic> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<dynamic> Create(Subject item)
        {
            try
            {
               
                _context.Subjects.Add(item);
                await _context.SaveChangesAsync();
                await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(item); });
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to POST. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }

        [HttpGet]
        public async Task<dynamic> GetAll()
        {
            try
            {
                var items = _context.Subjects.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(items); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }

        [HttpPut]
        public async Task<string> Update(ToDoItem item)
        {
            try
            {
                var dbItem = _context.ToDoItems.FirstOrDefault(m => m.Id == item.Id);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to PUT.  Item not found." });
                    });
                }
                dbItem.Text = item.Text;
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(dbItem);
                });
            }
            catch(Exception ex)
            {
                var errorMessage = "Failure to PUT. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.SerializeObject(new { msg = errorMessage });
                });
            }
        }

        [HttpDelete]
        public async Task<dynamic> Delete(ToDoItem item)
        {
            try
            {
                var dbItem = _context.ToDoItems.FirstOrDefault(m => m.Id == item.Id);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.ToDoItems.Remove(dbItem);
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