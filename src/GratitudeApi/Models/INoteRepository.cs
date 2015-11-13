using System.Collections.Generic;

namespace GratitudeApi.Models
{
    public interface INoteRepository
    {
        void Add(Note note);
        IEnumerable<Note> GetAll();
        Note Find(string key);
        Note Remove(string key);
        void Update(Note note);
    }
}