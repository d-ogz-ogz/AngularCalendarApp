using BUSINESS.Contracts;
using Microsoft.AspNetCore.Mvc;
using SHARED.Dtos;
using System;

namespace AngularCalendarApp.Server.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteBusinessEngine _noteEngine;
        public NoteController(INoteBusinessEngine noteEngine)
        {
            _noteEngine = noteEngine;
        }
        [HttpGet("GetNotes")]
        public List<NoteDto> GetNotes(int? day = null, int? month = null)
        {
            return _noteEngine.GetNotes(day, month);
        }
        [HttpPost("AddNote")]
        public NoteDto AddNote(NoteDto note)
        {
            return _noteEngine.AddNote(note);
        }
    }
}
