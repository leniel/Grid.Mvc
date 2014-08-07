using System.Collections.Generic;
using System.Linq;

namespace GridMvc.Tests
{
    public class TestGrid : Grid<TestModel>
    {
        public TestGrid(IEnumerable<TestModel> items)
            : base(items)
        {
        }
    }
}