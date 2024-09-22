using BUSINESS.Contracts;

using SHARED.DataContracts;
using SHARED.Dtos;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implemetations
{

    public class NoteBusinessEngine : INoteBusinessEngine
    {
        private readonly IUnitOfWork _uow;
        public NoteBusinessEngine(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public NoteDto AddNote(NoteDto note)
        {
            NoteDto noteModel = new NoteDto();
            try
            {
                noteModel.Day = note.Day;
                noteModel.Month = note.Month;
                noteModel.Year = note.Year;
                noteModel.Content = note.Content;
                noteModel.Title = note.Title;
                noteModel.Adding = DateTime.Now;
                _uow.notes.Add(noteModel);
                _uow.Save();
                return noteModel;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteDto> GetNotes(int? day = null, int? month = null)
        {
            List<NoteDto> noteList = new List<NoteDto>();
            var noteData = (day == null && month == null)
                ? this._uow.notes.GetAll().OrderBy(d => d.Adding).Reverse().ToList()
                : this._uow.notes.GetAll(res => res.Day == day && res.Month == month)
                      .OrderBy(d => d.Adding).Reverse().ToList();

            if (noteData != null)
            {
                noteList.AddRange(noteData);
            }

            return noteList;
        }
    }
}
