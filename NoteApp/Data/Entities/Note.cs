using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.Data.Entities
{
    public class Note
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Priority { get; set; }

        public User User { get; set; }
    }
}
