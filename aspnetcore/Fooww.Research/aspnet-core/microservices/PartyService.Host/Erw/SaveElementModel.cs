using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class SaveElementModel
    {
        public uint ProjectId { get; set; }


        public List<ElementItem> Elements{ get; set; }
}

    public class ElementItem
    {
        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ElementValue { get; set; }
    } 

}
