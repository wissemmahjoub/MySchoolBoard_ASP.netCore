using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EFCoreToDo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

// For more informationss on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    [EnableCors("CorsPolicy")]
    public class TimeTableController : Controller
    {
        private readonly ToDoDbContext _context;

        private readonly IHostingEnvironment _environment;
        public TimeTableController(IHostingEnvironment environment, ToDoDbContext context)
        {
            _environment = environment;
            _context = context;

        }


        // GET: /<controller>/
        public IActionResult Create()
        {

            IEnumerable<Classs> classess = _context.Classs.ToList();



            ViewBag.classess = new SelectList(classess, "ClasssId", "ClasseName");






            return View();
        }






        [HttpPost]
        public async Task<IActionResult> Create(ICollection<IFormFile> files, [Bind("TimeTableId,DateDebut,DateFin,idclassee")] TimeTable tl)
        {
            try
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting file into buffer.
                        byte[] buffer = null;
                        using (var stream = file.OpenReadStream())
                        {
                            buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, (int)stream.Length);
                        }

                        // Converting buffer into base64 code.
                        string base64FileRepresentation = Convert.ToBase64String(buffer);


                        tl.filenamee = string.Format("{0}_{1}", DateTime.UtcNow.ToString("yyyyMMddHHmmss"), file.FileName);
                        tl.filecode = base64FileRepresentation;
                        // Saving it into database.
                        _context.TimeTables.Add(tl);
                        await _context.SaveChangesAsync();
                    }
                }
                ViewBag.Files = _context.TimeTables.ToList();
                ViewBag.Message = "File uploaded successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Message = string.Format("Error: {0}", ex.ToString());
            }

            return View();
        }

        public FileStreamResult Download(string fileName)
        {
            // Fetching file encoded code from database.
            //  _context.TimeTables.Add
            string code = _context.TimeTables.ToList().FirstOrDefault(x => x.filenamee.Equals(fileName)).filecode;

            // Converting to code to byte array
            byte[] bytes = Convert.FromBase64String(code);

            // Converting byte array to memory stream.
            MemoryStream stream = new MemoryStream(bytes);

            // Create final file stream result.
            FileStreamResult fileStream = new FileStreamResult(stream, "*/*");

            // File name with file extension.
            fileStream.FileDownloadName = fileName;
            return fileStream;
        }

        //*******************************************************************************
        //*******************************************************************************

        [HttpPost]
        public async Task<dynamic> CreateApi([FromBody]TimeTable tll)
        {
            try
            {
                _context.TimeTables.Add(tll);
                await _context.SaveChangesAsync();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(tll); });
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
        public async Task<string> EditApi([FromBody]TimeTable item)
        {
            try
            {
                var dbItem = _context.TimeTables.FirstOrDefault(m => m.TimeTableId == item.TimeTableId);



                dbItem.DateDebut = item.DateDebut;
                dbItem.DateFin = item.DateFin;
                dbItem.filenamee = item.filenamee;
                dbItem.filecode = item.filecode;


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
        public async Task<dynamic> DeleteApi([FromBody]TimeTable item)
        {
            try
            {
                var dbItem = _context.TimeTables.FirstOrDefault(m => m.TimeTableId == item.TimeTableId);
                if (dbItem == null)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        return JsonConvert.SerializeObject(new { msg = "Failure to DELETE.  Item not found." });
                    });
                }
                _context.TimeTables.Remove(dbItem);
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


        //***************************
        //***********************************************************************************
        [HttpGet]
        public async Task<dynamic> GetAllapi()
        {
            try
            {
                var TimeListe = _context.TimeTables.ToList();
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(TimeListe); });
            }
            catch (Exception ex)
            {
                var errorMessage = "Failure to GET. Stack Trace: " + ex.StackTrace;
                Console.WriteLine(errorMessage);
                return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(new { msg = errorMessage }); });
            }
        }
        //***********************************************************************************



    }


}
