using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Data.Entities;
using NoteApp.Models.Dashboard;

namespace NoteApp.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext context;

        public DashboardController(ApplicationDbContext context)
        {
            this.context = context;
        } 

        // GET: DashboardController
        [HttpGet]
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            var newModel = new IndexModel();
            newModel.UserNotes = context.Notes.Where(x => x.UserId == 1).ToList();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            Console.WriteLine($"Testing {model.NoteTitle}");
            context.Notes.Add(new Note
            {
                Title = model.NoteTitle,
                Content = "Test",
                UserId = 1,
            });
            context.SaveChanges();

            return View(model);
        }


        // GET: DashboardController/Details/5
        public ActionResult Note()//int id
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        [HttpGet]
        public ActionResult Note(int id)
        {
            var model = new NoteModel();
            var noteData = context.Notes.FirstOrDefault(x => x.Id == id);
            model.Id = noteData.Id;
            model.Content = noteData.Content;
            return View(model);
        }

        // POST: DashboardController/Edit/5
        /*   [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Note()
           {
               try
               {
                   return RedirectToAction(nameof(Index));
               }
               catch
               {
                   return View();
               }
           }
        */
        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
