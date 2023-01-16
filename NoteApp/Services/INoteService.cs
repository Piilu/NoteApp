using NoteApp.Data;

namespace NoteApp.Services
{
    public interface INoteService
    {
        Task<U> Get<U>(int id);
        Task<IList<U>> List<U>(int id);

    }
}
