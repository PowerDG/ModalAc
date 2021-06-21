using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class PreviewPageInitializationModel
    {
        public Outline Outline { get; set; }
        public PreviewPage ProjectScheme { get; set; }
        
        public ModuleEditBox DefaultModuleEditBox { get; set; }
    }

    public class Outline
    {
        public ProjectScheme projectScheme { get; set; }

        public Dictionary<string,object> OutlineDictionary { get; set; }
}
    public class PreviewPage
    {
        public ProjectScheme ProjectScheme { get; set; }

        public Dictionary<string, PreviewPageModule> OutlineDictionary { get; set; }
    }

    public class PreviewPageModule
    {
        public uint ProjectId { get; set; }

        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ModuleTitle { get; set; }

        public uint SortId { get; set; }
        public List<Element> Elements { get; set; }
    }
} 
