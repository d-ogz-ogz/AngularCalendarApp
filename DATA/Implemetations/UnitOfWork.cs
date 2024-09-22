
using DOMAIN.Db;
using SHARED.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Implemetations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalendarAppDbContext _db;
        public UnitOfWork(CalendarAppDbContext db)
        {
            _db = db;
            notes = new NoteRepository(_db);

        }

        public INoteRepository notes { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
