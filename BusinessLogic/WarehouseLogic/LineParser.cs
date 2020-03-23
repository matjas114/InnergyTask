using Shared.Constant;
using Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.WarehouseLogic
{
    public class LineParser
    {
        public List<Warehouse> Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line) ||  (line == string.Empty))
                return new List<Warehouse>();
            var warehouseList = new List<Warehouse>();
            var materialSplitedLine = line.Split(WarehouseConst.materialSpliteCharacters);
            var warehouseSplitedLine = materialSplitedLine.Last().Split(WarehouseConst.warehouseSpliteChars);

            var materialId = materialSplitedLine[materialSplitedLine.Length - 2];

            for (int i = 0; i < warehouseSplitedLine.Length; i += 2)
            {
                var quantity = int.Parse(warehouseSplitedLine[i + 1]);
                var material = new Material() { Id = materialId, Quantity = quantity };
                warehouseList.Add(new Warehouse { Name = warehouseSplitedLine[i], TotalAmount = quantity, MaterialLists = new List<Material>() { material } });
            }
            return warehouseList;
        }
    }
}
