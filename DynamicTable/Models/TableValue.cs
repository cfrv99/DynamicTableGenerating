using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Models
{
    public class TableValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int RowNum { get; set; }
        public int HeaderId { get; set; }
    }
}
