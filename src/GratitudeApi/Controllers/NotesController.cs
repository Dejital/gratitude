using System.Collections.Generic;
using GratitudeApi.Models;
using Microsoft.AspNet.Mvc;

namespace GratitudeApi.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        [FromServices]
        public INoteRepository Notes { get; set; }

        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return Notes.GetAll();
        }

        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetById(string id)
        {
            var note = Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(note);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
            {
                return HttpBadRequest();
            }
            Notes.Add(note);
            return CreatedAtRoute("GetNote", new {controller = "Notes", id = note.Key}, note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Note note)
        {
            if (note == null)
            {
                return HttpBadRequest();
            }

            var existingNote = Notes.Find(id);
            if (existingNote == null)
            {
                return HttpNotFound();
            }

            Notes.Update(note);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Notes.Remove(id);
        }
    }
}
