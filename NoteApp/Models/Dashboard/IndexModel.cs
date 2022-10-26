using NoteApp.Data.Entities;

namespace NoteApp.Models.Dashboard
{
    public class IndexModel
    {
        public string NoteTitle { get; set; }
        public List<Note> UserNotes { get; set; } = new List<Note>();
    }
}
