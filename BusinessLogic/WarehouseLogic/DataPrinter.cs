using Shared.Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic.WarehouseLogic
{
    public class DataPrinter
    {
        public void PrintData(List<Warehouse> warehouseData)
        {
            var isFirstWarehouse = true; 
            foreach(var warehouse in warehouseData)
            {
                if (!isFirstWarehouse)
                {
                    Console.Write(Environment.NewLine);
                }
                Console.WriteLine(warehouse.Name + " (total " + warehouse.TotalAmount + ")");
                PrintMaterial(warehouse.MaterialLists);
                isFirstWarehouse = false;
            }
        }

        private void PrintMaterial(List<Material> materialList)
        {
            foreach (var material in materialList)
                Console.WriteLine(material.Id + " : " + material.Quantity);
        }
    }
}
