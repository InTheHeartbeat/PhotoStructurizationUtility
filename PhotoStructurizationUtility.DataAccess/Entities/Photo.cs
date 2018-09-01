using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStructurizationUtility.DataAccess.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime TakenDateTime { get; set; }
        public Guid CameraId { get; set; }
    }
}
