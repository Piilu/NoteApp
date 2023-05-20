using FakeItEasy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Controllers;
using NoteApp.Data.Entities;
using NoteApp.Data.Repositories;
using NoteApp.Models;
using NoteApp.Models.Dashboard;
using NoteApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NoteApp.Tests.Controllers
{
    public class DashboardControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResultWithModel()
        {
            var userId = 1;
            var notesListModel = new List<NotesListModel>();

            var userManager = A.Fake<UserManager<User>>();
            A.CallTo(() => userManager.GetUserId(null)).Returns(userId.ToString());

            var noteService = A.Fake<INoteService>();

            var noteRepository = A.Fake<INoteRepository>();

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = await controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<IndexModel>(result.Model);
            var model = result.Model as IndexModel;
            Assert.Equal(notesListModel, model.Notes);
        }

        [Fact]
        public void Edit_Get_ReturnsViewResultWithEditModel()
        {
            var userManager = A.Fake<UserManager<User>>();
            var noteService = A.Fake<INoteService>();
            var noteRepository = A.Fake<INoteRepository>();

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = controller.Edit() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<EditModel>(result.Model);
        }

        [Fact]
        public async Task Edit_Post_RedirectsToDashboard()
        {
            var editModel = new EditModel { NoteTitle = "Test Note" };

            var userManager = A.Fake<UserManager<User>>();
            var noteService = A.Fake<INoteService>();
            var noteRepository = A.Fake<INoteRepository>();

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = await controller.Edit(editModel) as RedirectResult;

            Assert.NotNull(result);
            Assert.Equal("~/Dashboard", result.Url);
        }

        [Fact]
        public async Task Note_Get_ReturnsViewResultWithNoteModel()
        {
            var noteModel = new NoteModel();
            var noteId = 1;

            var userManager = A.Fake<UserManager<User>>();
            var noteService = A.Fake<INoteService>();
            var noteRepository = A.Fake<INoteRepository>();
            A.CallTo(() => noteRepository.Get<NoteModel>(noteId)).Returns(Task.FromResult(noteModel));

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = await controller.Note(noteId) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NoteModel>(result.Model);
            Assert.Equal(noteModel, result.Model);
        }

        [Fact]
        public async Task Note_Post_ReturnsPartialViewWithNoteModel()
        {
            var noteModel = new NoteModel();

            var userManager = A.Fake<UserManager<User>>();
            var noteService = A.Fake<INoteService>();
            var noteRepository = A.Fake<INoteRepository>();

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = await controller.Note(noteModel) as PartialViewResult;

            Assert.NotNull(result);
            Assert.IsType<NoteModel>(result.Model);
            Assert.Equal(noteModel, result.Model);
        }

        [Fact]
        public async Task Delete_ReturnsRedirectToDashboard()
        {
            var noteId = 1;
            var userId = 1;

            var userManager = A.Fake<UserManager<User>>();
            A.CallTo(() => userManager.GetUserId(null)).Returns(userId.ToString());

            var noteService = A.Fake<INoteService>();
            var noteRepository = A.Fake<INoteRepository>();

            var controller = new DashboardController(userManager, noteService, noteRepository);

            var result = await controller.Delete(noteId) as RedirectResult;

            Assert.NotNull(result);
            Assert.Equal("~/Dashboard", result.Url);
        }
    }
}
