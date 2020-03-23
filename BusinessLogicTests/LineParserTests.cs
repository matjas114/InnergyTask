using BusinessLogic.WarehouseLogic;
using Shared.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BusinessLogicTests
{
    public class LineParserTests
    {
        private string correctLine;

        private void PrepareData()
        {
            correctLine = "Maple Dovetail Drawerbox;COM-124047;WH-A,15";
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("               ")]
        public void ShouldReturnEmptyObjectWhenTextIsNullEmptyOrHasOnlyWhiteSpace(string line)
        {
            var result = new LineParser().Parse(line);
            Assert.Empty(result);
        }

        [Fact]
        public void ShouldReturnCorrectWarehouseName()
        {
            PrepareData();

            var result = new LineParser().Parse(correctLine);

            Assert.Equal("WH-A", result.First().Name);
        }

        [Fact]
        public void ShouldReturnCorrectMaterialId()
        {
            PrepareData();

            var result = new LineParser().Parse(correctLine);

            Assert.Equal("COM-124047", result.First().MaterialLists.First().Id);
        }

        [Fact]
        public void ShouldReturnCorrectMaterialQuantity()
        {
            PrepareData();

            var result = new LineParser().Parse(correctLine);

            Assert.Equal(15, result.First().MaterialLists.First().Quantity);
        }
    }
}
