using Shared.Constant;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogic.WarehouseLogic
{
    public class TextReader
    {
        private string line = null;
        private List<Warehouse> result = new List<Warehouse>();

        public List<Warehouse> GetDataFromText(string textToRead)
        {
            
            var parser = new LineParser();

            StringReader reader = new StringReader(textToRead);
            
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == string.Empty || WarehouseConst.skipedLineStrings.Any(x=>line.StartsWith(x)))
                    continue;
                               
                foreach (var warehouse in parser.Parse(line))
                {
                    var existedWarehouse = FindWarehouse(warehouse);
                    if (existedWarehouse == null)
                    {
                        result.Add(warehouse);
                        continue;
                    }
                    var existedMaterialInWarehouse = FindMaterialInWarehouse(existedWarehouse, warehouse.MaterialLists.First());
                    if (existedMaterialInWarehouse == null)
                    {
                        existedWarehouse.MaterialLists.AddRange(warehouse.MaterialLists);
                        existedWarehouse.TotalAmount += warehouse.MaterialLists.Sum(x => x.Quantity);
                    }
                }
            }
            return result;
        }

        private Material FindMaterialInWarehouse(Warehouse existsWarehouse, Material material)
        {
            return existsWarehouse.MaterialLists.Find(x=>x.Id == material.Id);
        }

        private Warehouse FindWarehouse(Warehouse warehouse)
        {
            return result.Find(x => x.Name == warehouse.Name);
        }
    }
}
