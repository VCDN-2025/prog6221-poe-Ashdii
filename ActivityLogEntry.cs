using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBotGUI
{
    public class ActivityLogEntry
    {
        public DateTime Timestamp { get; } = DateTime.Now;
        public string Action { get; }

        public ActivityLogEntry(string action)
        {
            Action = action;
        }
    }
}
