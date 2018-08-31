using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStructurizationUtility.App.Models
{
    public class HistoryItemViewModel
    {
        public string Message { get; set; }
        public Color Color { get; set; }

        public HistoryItemViewModel(string message, Color color)
        {
            Message = message;
            Color = color;
        }
    }
}
