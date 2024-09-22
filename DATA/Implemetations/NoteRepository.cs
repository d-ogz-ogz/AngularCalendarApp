
using DOMAIN.Db;
using SHARED.DataContracts;
using SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Implemetations
{
    public class NoteRepository : Repository<NoteDto>, INoteRepository
    {
        private readonly CalendarAppDbContext _db;
        public NoteRepository(CalendarAppDbContext db) : base(db) {

            _db = db;
        }
    }
}
