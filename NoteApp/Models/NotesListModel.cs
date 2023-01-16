using NoteApp.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.Models
{
    public class NotesListModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Priority { get; set; }

    }
}
