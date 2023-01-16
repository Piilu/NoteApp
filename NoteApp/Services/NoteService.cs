using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using NoteApp.Data.Repositories;

namespace NoteApp.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper objectMapper;
        private readonly INoteRepository noteRepository;


        public NoteService(ApplicationDbContext dataContext, IMapper objectMapper, INoteRepository noteRepository)
        {
            this.context = dataContext;
            this.objectMapper = objectMapper;
            this.noteRepository = noteRepository;
        }

        public async Task<U> Get<U>(int id)
        {
            return await noteRepository.Get<U>(id);
        }

        public async Task<IList<U>> List<U>(int id)
        {
            return await noteRepository.List<U>(id);
        }
    }
}
