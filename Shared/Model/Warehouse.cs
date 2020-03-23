using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    public class Warehouse
    {
        public long TotalAmount { get; set; }
        public string Name { get; set; }
        public List<Material> MaterialLists { get; set; }
    }
}
