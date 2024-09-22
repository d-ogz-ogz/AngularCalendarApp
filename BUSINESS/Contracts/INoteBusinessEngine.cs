
using SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Contracts
{
    public interface INoteBusinessEngine
    {
       
        public NoteDto AddNote(NoteDto note);
        public List<NoteDto> GetNotes(int? day = null, int? month = null);

    }
}
