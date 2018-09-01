using System;

namespace PhotoStructurizationUtility.DataAccess.Entities
{
    public class HistoryEntry
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public string OldPath { get; set; }
        public string NewPath { get; set; }        
        public DateTime Created { get; set; }
    }
}
