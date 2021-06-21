using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class Element
    {
        public uint ProjectId { get; set; }

        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ElementTitle { get; set; }

        public uint ElementType{ get; set; }

        public Dictionary<string, object> OptionalField { get; set; }

        public uint SortId { get; set; }
    }
}
