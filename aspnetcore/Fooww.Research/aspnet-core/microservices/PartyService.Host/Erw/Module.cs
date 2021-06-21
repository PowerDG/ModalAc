using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class Module
    {
        public uint ProjectId { get; set; }

        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ModuleTitle { get; set; }

        public uint SortId { get; set; }
    }
}
