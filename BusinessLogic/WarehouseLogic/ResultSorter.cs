using Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.WarehouseLogic
{
    public class ResultSorter
    {
        public List<Warehouse> Sort(List<Warehouse> resultToSort)
        {
            var sortedWarehouseList = resultToSort.OrderByDescending(x => x.MaterialLists.Sum(y => y.Quantity)).ThenByDescending(x => x.Name).ToList();

            foreach (var warhouse in sortedWarehouseList)
                warhouse.MaterialLists = warhouse.MaterialLists.OrderBy(x => x.Id).ToList();

            return sortedWarehouseList;
        }
    }
}
