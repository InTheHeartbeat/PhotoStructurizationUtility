using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.DataAccess.Entities;
using PhotoStructurizationUtility.DataAccess.Repositories.Interfaces;

namespace PhotoStructurizationUtility.DataAccess.Repositories
{
    public class HistoryEntryRepository : IHistoryEntryRepository
    {
        public IList<HistoryEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        public HistoryEntry GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(HistoryEntry item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(HistoryEntry item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(HistoryEntry item)
        {
            throw new NotImplementedException();
        }
    }
}
