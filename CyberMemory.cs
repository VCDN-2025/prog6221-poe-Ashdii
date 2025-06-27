using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CyberAwarenessBot
{
    public class CyberMemory
    {
        public string Name { get; set; }
        public string FavoriteTopic { get; set; }
        public List<string> Sentiments = new List<string>();
    }
}
