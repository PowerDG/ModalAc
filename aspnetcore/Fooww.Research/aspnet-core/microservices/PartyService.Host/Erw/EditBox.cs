using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyService.Host.Erw
{
    public class ModuleEditBox
    {
        public uint ProjectId { get; set; }

        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ModuleTitle { get; set; }
        public List<ModuleEditElement> elements { get; set; }
    }


    public class ModuleEditElement
    {
        public uint ProjectId { get; set; }

        public uint ModuleId { get; set; }

        public uint ElementId { get; set; }

        public string ElementTitle { get; set; }

        /// <summary>
        /// 类型 后续换成枚举
        /// </summary>
        public uint ElementType { get; set; }
        /// <summary>
        /// 可选项
        /// </summary>
        public Dictionary<string, object> OptionalField { get; set; }

        public uint SortId { get; set; }
    }
}
