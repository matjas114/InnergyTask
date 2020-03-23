using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Constant
{
    public class WarehouseConst
    {
        public static readonly char[] warehouseSpliteChars = { ',', '|' };
        public static readonly char[] materialSpliteCharacters = { ';' };
        public static readonly List<string> skipedLineStrings = new List<string> { "#" };
    }
}
