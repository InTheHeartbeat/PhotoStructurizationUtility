using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.DataAccess.Entities;
using PhotoStructurizationUtility.DataAccess.Repositories.Interfaces;

namespace PhotoStructurizationUtility.DataAccess.Repositories
{
    public class LogEntryRepository : ILogEntryRepository
    {
        public IList<LogEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        public LogEntry GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(LogEntry item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(LogEntry item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(LogEntry item)
        {
            throw new NotImplementedException();
        }
    }
}
