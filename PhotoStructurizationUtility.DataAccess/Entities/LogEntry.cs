using System;
using PhotoStructurizationUtility.Common.Enums;

namespace PhotoStructurizationUtility.DataAccess.Entities
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        public LogNoteType NoteType { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
