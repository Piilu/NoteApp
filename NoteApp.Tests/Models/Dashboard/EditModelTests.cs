using System.ComponentModel.DataAnnotations;
using NoteApp.Models.Dashboard;
using Xunit;

namespace NoteApp.Tests.Models.Dashboard
{
    public class EditModelTests
    {
        [Fact]
        public void NoteTitle_Required()
        {
            var model = new EditModel();

            var result = Validator.TryValidateProperty(model.NoteTitle, new ValidationContext(model) { MemberName = "NoteTitle" }, null);

            Assert.False(result);
        }
        
        [Fact]
        public void NoteTitle_Valid()
        {
            var model = new EditModel { NoteTitle = "Valid Note Title" };

            var result = Validator.TryValidateProperty(model.NoteTitle, new ValidationContext(model) { MemberName = "NoteTitle" }, null);

            Assert.True(result);
        }
    }
}
