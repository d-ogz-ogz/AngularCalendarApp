using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.DataContracts
{
    public interface IUnitOfWork : IDisposable
    {
        INoteRepository notes { get; }
       
        public void Save() { }
    }
}
