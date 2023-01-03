using NoteApp.Data.Entities;

namespace NoteApp.Models.Dashboard
{
    public class IndexModel
    {
        public List<Note> UserNotes { get; set; } = new List<Note>();
    }
}
