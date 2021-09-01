using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Models
{
    public class ResponseModel
    {
        public List<TableHeader> TableHeaders { get; set; }
        public List<TableValue> TableValues { get; set; }
        public List<IGrouping<int, TableValue>> Grouped { get; set; }
    }
}
