using NoteApp.Data.Entities;
using NoteApp.Models.Dashboard;
using Xunit;

namespace NoteApp.Tests.Models.Dashboard
{
    public class NoteModelTests
    {
        [Fact]
        public void Id_GetSetProperty()
        {
            var model = new NoteModel();
            int id = 1;

            model.Id = id;

            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void UserId_GetSetProperty()
        {
            var model = new NoteModel();
            int userId = 1;

            model.UserId = userId;

            Assert.Equal(userId, model.UserId);
        }

        [Fact]
        public void Title_GetSetProperty()
        {
            var model = new NoteModel();
            string title = "Test Title";

            model.Title = title;

            Assert.Equal(title, model.Title);
        }

        [Fact]
        public void Content_GetSetProperty()
        {
            var model = new NoteModel();
            string content = "Test Content";

            model.Content = content;

            Assert.Equal(content, model.Content);
        }

        [Fact]
        public void Priority_GetSetProperty()
        {
            var model = new NoteModel();
            string priority = "High";

            model.Priority = priority;

            Assert.Equal(priority, model.Priority);
        }
    }
}
