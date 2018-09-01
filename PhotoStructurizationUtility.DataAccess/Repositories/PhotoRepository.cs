using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.DataAccess.Entities;
using PhotoStructurizationUtility.DataAccess.Repositories.Interfaces;

namespace PhotoStructurizationUtility.DataAccess.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public IList<Photo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Photo GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Photo item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Photo item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Photo item)
        {
            throw new NotImplementedException();
        }
    }
}
