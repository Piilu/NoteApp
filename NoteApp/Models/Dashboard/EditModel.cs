using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models.Dashboard
{
    public class EditModel
    {
        [Display(Name ="Note name:")]
        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string NoteTitle { get; set; }
    }
}
