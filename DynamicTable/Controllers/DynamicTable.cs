using DynamicTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Controllers
{
    public class DynamicTable
    {
        public static ResponseModel GenerateDynamicTable(int tableId,AppDbContext context)
        {
            var tableHeaders = context.TableHeaders
                    .Where(i => i.TableId == tableId)
                    .OrderBy(i => i.Id)
                    .AsEnumerable();

            var tableValue = context.TableValues
                    .Where(i => tableHeaders.Any(a => a.TableId == tableId))
                    .OrderBy(i => i.HeaderId)
                    .ToList();

            var tableGrouped = tableValue
                    .GroupBy(i => i.RowNum)
                    .ToList();

            ResponseModel rm = new ResponseModel();
            rm.TableHeaders = tableHeaders.ToList();
            rm.TableValues = tableValue;
            rm.Grouped = tableGrouped;
            return rm;
        }
    }
}
