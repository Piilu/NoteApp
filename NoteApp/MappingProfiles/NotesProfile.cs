using AutoMapper;
using NoteApp.Data;
using NoteApp.Data.Entities;
using NoteApp.Models;
using NoteApp.Models.Dashboard;

namespace ModelsDemo.MappingProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile() 
        {
            CreateMap<Note, NotesListModel>();
            CreateMap<Note, NoteModel>();

            CreateMap<NotesListModel, Note>()
                .ForMember(m => m.Id, m => m.Ignore())
                .ForMember(m => m.Id, m => m.Ignore());
        }
    }
}
