using NoteApp.Data.Entities;
using NoteApp.Models;

namespace NoteApp.Data.Repositories
{
    public interface INoteRepository
    {
        Task<U> Get<U>(int id);
        Task<IList<U>> List<U>(int id);
        Task Save(Note task);
        Task Delete(int id, int userId);
    }
}
