using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.Logging
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
