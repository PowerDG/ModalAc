using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class ProjectScheme
    {
        public uint ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectDetail { get; set; }

        public string Version { get; set; }
        
        public List<Module> modules { get; set; }
    }
}
