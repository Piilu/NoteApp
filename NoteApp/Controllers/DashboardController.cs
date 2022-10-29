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
        private readonly UserManager<User> userManager;

        public DashboardController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        } 

        // GET: DashboardController
        [HttpGet]
        public ActionResult Index()
        {
            var userId = Int32.Parse(userManager.GetUserId(User));

            var newModel = new IndexModel();
            newModel.UserNotes = context.Notes.Where(x => x.UserId == userId).OrderBy(x=>x.Id).Reverse().ToList();
            newModel.NoteTitle = "";
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            var userId = Int32.Parse(userManager.GetUserId(User));

            context.Notes.Add(new Note
            {
                Title = model.NoteTitle,
                Content = "",
                UserId = userId,
            });
            context.SaveChanges();

            return Redirect("~/Dashboard");
        }


        // GET: DashboardController/Edit/5
        [HttpGet]
        public ActionResult Note(int id)
        {
            var model = new NoteModel();
            var noteData = context.Notes.FirstOrDefault(x => x.Id == id);
            model.NoteId = noteData.Id;
            model.Note = noteData;
            return View(model);
        }

        [HttpPost]
        public ActionResult Note(NoteModel model)
        {
            context.Notes.Add(model.Note);
            context.SaveChanges();
            return View(model);
        }

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
