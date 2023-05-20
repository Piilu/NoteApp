using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using NoteApp.Data.Entities;
using NoteApp.Data.Repositories;
using NoteApp.Models;
using NoteApp.Models.Dashboard;
using Xunit;

namespace NoteApp.Tests.Data.Repositories
{
    public class NoteRepositoryTests
    {
        [Fact]
        public async Task Get_ReturnsNoteModel()
        {
            int id = 1;
            var fakeNoteRepository = A.Fake<INoteRepository>();
            A.CallTo(() => fakeNoteRepository.Get<NoteModel>(id)).Returns(Task.FromResult(new NoteModel()));

            var result = await fakeNoteRepository.Get<NoteModel>(id);

            Assert.NotNull(result);
            Assert.IsType<NoteModel>(result);
        }


        [Fact]
        public async Task Save_CallsSaveMethod()
        {
            var fakeNoteRepository = A.Fake<INoteRepository>();
            var note = new Note();

            await fakeNoteRepository.Save(note);

            A.CallTo(() => fakeNoteRepository.Save(note)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task Delete_CallsDeleteMethod()
        {
            int id = 1;
            int userId = 2;
            var fakeNoteRepository = A.Fake<INoteRepository>();

            await fakeNoteRepository.Delete(id, userId);

            A.CallTo(() => fakeNoteRepository.Delete(id, userId)).MustHaveHappenedOnceExactly();
        }
    }
}
