using Microsoft.AspNetCore.Mvc.Rendering;
using NoteApp.Data.Entities;

namespace NoteApp.Models.Dashboard
{
    public class IndexModel
    {
        public IndexModel()
        {
            Notes = new List<NotesListModel>();
        }

        public NotesListModel Note { get; set; }
        public IList<NotesListModel> Notes { get; set; }

    }
}
