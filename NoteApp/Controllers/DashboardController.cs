using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Data.Entities;
using NoteApp.Data.Repositories;
using NoteApp.Models;
using NoteApp.Models.Dashboard;
using NoteApp.Services;
using System.Threading.Tasks;

namespace NoteApp.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly INoteService noteService;
        private readonly INoteRepository noteRespository;

        public DashboardController(UserManager<User> userManager, INoteService noteService, INoteRepository noteRespository)
        {
            this.userManager = userManager;
            this.noteService = noteService;
            this.noteRespository = noteRespository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = Int32.Parse(userManager.GetUserId(User));
            var newModel = new IndexModel();
            var userNotes = await noteService.List<NotesListModel>(userId);

            newModel.Notes = userNotes;
            return View(newModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var model = new EditModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            var note = new Note();
            note.Title = model.NoteTitle;
            note.User = await userManager.GetUserAsync(User);
            await noteRespository.Save(note);

            return Redirect("~/Dashboard");
        }

        [HttpGet]
        public async Task<ActionResult> Note(int id)
        {
            var note = await noteRespository.Get<NoteModel>(id);
            return View(note);
        }

        [HttpPost]
        public async Task<ActionResult> Note(NoteModel model)
        {
            var note = new Note();
            note.Id = model.Id;
            note.Priority = model.Priority;
            note.Content = model.Content;
            note.Title = model.Title;
            note.User = await userManager.GetUserAsync(User);

            await noteRespository.Save(note);
            return PartialView(model);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = Int32.Parse(userManager.GetUserId(User));
            await noteRespository.Delete(id, userId);
            return Redirect("~/Dashboard");
        }
    }
}
