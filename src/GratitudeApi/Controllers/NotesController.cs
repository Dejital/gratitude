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
    }
}
