using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GratitudeApi.Models
{
    internal class NoteRepository : INoteRepository
    {
        private static readonly ConcurrentDictionary<string, Note> Notes = new ConcurrentDictionary<string, Note>();

        public NoteRepository()
        {
            var note = new Note
            {
                Name = "Thankful to Microsoft",
                Description = "I am thankful to Microsoft for creating ASP.NET."
            };
            Add(note);
        }

        public void Add(Note note)
        {
            note.Key = Guid.NewGuid().ToString();
            Notes[note.Key] = note;
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes.Values;
        }

        public Note Find(string key)
        {
            Note note;
            Notes.TryGetValue(key, out note);
            return note;
        }

        public Note Remove(string key)
        {
            Note note;
            Notes.TryGetValue(key, out note);
            Notes.TryRemove(key, out note);
            return note;
        }

        public void Update(Note note)
        {
            Notes[note.Key] = note;
        }
    }
}