using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum ContextType
    {
        Phrase,
        URL
    }
    public class ContextSet
    {
        public string Value { get; set; }
        
        public string Type { get; set; }
        
    }
}
