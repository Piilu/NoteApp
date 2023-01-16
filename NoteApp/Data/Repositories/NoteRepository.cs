using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data.Entities;
using NoteApp.Models;

namespace NoteApp.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper objectMapper;


        public NoteRepository(ApplicationDbContext context, IMapper objectMapper)
        {
            this.context = context;
            this.objectMapper = objectMapper;
        }

        public async Task<U> Get<U>(int id)
        {
            return await context.Notes
                                     .Where(x => x.Id == id)
                                     .ProjectTo<U>(objectMapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync();
        }

        public async Task<IList<U>> List<U>(int id)
        {
            return await context.Notes.Where(x => x.UserId == id)
                                     .OrderByDescending(x => x.Id)
                                     .ProjectTo<U>(objectMapper.ConfigurationProvider)
                                     .ToListAsync();
        }

        public async Task Save(Note note)
        {
            if (note.Id == 0)
            {
                context.Notes.Add(note);
            }
            else
            {
                var newNote = context.Notes.FirstOrDefault(x => x == note);
                newNote.Content = note.Content; //rn it's just here to update content
                //newNote.User = note.User;
                //newNote.Title = note.Title;
                //newNote.Priority = note.Priority;
            }

            await context.SaveChangesAsync();
        }


        public async Task Delete(int id, int userId)
        {
            var note = context.Notes.FirstOrDefault(x => x.Id == id);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }

    }
}
