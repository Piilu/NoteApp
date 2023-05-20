using System.Collections.Generic;
using NoteApp.Data.Entities;
using NoteApp.Models;
using NoteApp.Models.Dashboard;
using Xunit;

namespace NoteApp.Tests.Models.Dashboard
{
    public class IndexModelTests
    {
        [Fact]
        public void Constructor_InitializesNotesList()
        {
            // Arrange
            var model = new IndexModel();

            // Act

            // Assert
            Assert.NotNull(model.Notes);
            Assert.IsType<List<NotesListModel>>(model.Notes);
        }

        [Fact]
        public void Note_GetSetProperty()
        {
            var model = new IndexModel();
            var note = new NotesListModel();

            model.Note = note;

            Assert.Equal(note, model.Note);
        }

        [Fact]
        public void Notes_GetSetProperty()
        {
            var model = new IndexModel();
            var notes = new List<NotesListModel>();

            model.Notes = notes;

            Assert.Equal(notes, model.Notes);
        }
    }
}
