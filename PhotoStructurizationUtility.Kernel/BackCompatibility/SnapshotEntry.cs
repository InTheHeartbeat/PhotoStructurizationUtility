using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStructurizationUtility.Kernel.BackCompatibility
{
    public class SnapshotEntry
    {
        public string OldPath { get; set; }
        public string NewPath { get; set; }
        public string FileName { get; set; }
        public DateTime Created { get; set; }        
    }
}
