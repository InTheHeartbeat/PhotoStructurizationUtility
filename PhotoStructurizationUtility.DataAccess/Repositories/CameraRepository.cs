using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.DataAccess.Entities;
using PhotoStructurizationUtility.DataAccess.Repositories.Interfaces;

namespace PhotoStructurizationUtility.DataAccess.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        public IList<Camera> GetAll()
        {
            throw new NotImplementedException();
        }

        public Camera GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Camera item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Camera item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Camera item)
        {
            throw new NotImplementedException();
        }
    }
}
