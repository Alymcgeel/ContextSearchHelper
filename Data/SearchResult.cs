using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SearchResult
    {
        public string Path { get; set; }
        public string Type { get; set; }
        public string AdditionalInformation { get; set; }
        public string Icon { get; set; }

        public string Score { get; set; }

        public SearchResult()
        {
            Path = String.Empty;
            Type = String.Empty;
            AdditionalInformation = String.Empty;
            Icon = String.Empty;
        }
    }
}
