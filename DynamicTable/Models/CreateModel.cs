using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Models
{
    public class CreateModel
    {
        public List<TableHeader> TableHeaders { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
