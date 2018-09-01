using System;
using PhotoStructurizationUtility.Common.Enums;

namespace PhotoStructurizationUtility.Common.Logging
{
    public class LogNote
    {
        public LogNoteType NoteType { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public LogNote(string message, LogNoteType noteType = LogNoteType.Message, bool captureCreatedDateTime = true)
        {
            NoteType = noteType;
            Created = DateTime.Now;
            Message = captureCreatedDateTime ? Created.ToString("g") + " " + message : message;            
        }
    }
}
