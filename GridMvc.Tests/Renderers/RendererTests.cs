using System.IO;
using System.Linq;
using System.Web;
using GridMvc.Columns;
using GridMvc.Filtering;
using GridMvc.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GridMvc.Tests.Renderers
{
    /// <summary>
    /// Summary description for SortTests
    /// </summary>
    [TestClass]
    public class RendererTests
    {
        [TestInitialize]
        public void Init()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
        }

        [TestMethod]
        public void TestGridHeaderRenderer()
        {
            var renderer = new GridHeaderRenderer();
            var column = new GridColumn<TestModel, string>(c => c.Title, null);
            var htmlstring = renderer.Render(column);
            Assert.IsNotNull(htmlstring);
            var html = htmlstring.ToHtmlString();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(html));
            Assert.IsTrue(html.Contains("<th"));
            Assert.IsTrue(html.Contains("class=\"grid-header\""));
        }

        [TestMethod]
        public void TestGridCellRenderer()
        {
            var renderer = new GridCellRenderer();
            var column = new GridColumn<TestModel, string>(c => c.Title, null);
            var cell = new GridCell("test");
            var htmlstring = renderer.Render(column, cell);

            Assert.IsNotNull(htmlstring);
            var html = htmlstring.ToHtmlString();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(html));

            Assert.IsTrue(html.Contains("<td"));
            Assert.IsTrue(html.Contains(">test</td>"));
            Assert.IsTrue(html.Contains("class=\"grid-cell\""));
            Assert.IsTrue(html.Contains("data-name=\"Title\""));
        }

        [TestMethod]
        public void TestGridFilterHeaderRenderer()
        {
            var settings = new QueryStringFilterSettings();
            var renderer = new QueryStringFilterColumnHeaderRenderer(settings);

            var column = new GridColumn<TestModel, string>(c => c.Title, new TestGrid(Enumerable.Empty<TestModel>()));

            var htmlstring = renderer.Render(column);
            Assert.IsNotNull(htmlstring);
            var html = htmlstring.ToHtmlString();
            Assert.IsTrue(string.IsNullOrEmpty(html));

            column.Filterable(true);

            htmlstring = renderer.Render(column);
            Assert.IsNotNull(htmlstring);
            html = htmlstring.ToHtmlString();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(html));

            Assert.IsTrue(html.Contains("data-filterdata="));
            Assert.IsTrue(html.Contains("class=\"grid-filter\""));
            Assert.IsTrue(html.Contains("class=\"grid-filter-btn\""));
            Assert.IsTrue(html.Contains("data-widgetdata="));
        }

        [TestMethod]
        public void TestGridSortHeaderRenderer()
        {
            var settings = new QueryStringSortSettings();
            var renderer = new QueryStringSortColumnHeaderRenderer(settings);

            var column = new GridColumn<TestModel, string>(c => c.Title, new TestGrid(Enumerable.Empty<TestModel>()));

            var htmlstring = renderer.Render(column);
            Assert.IsNotNull(htmlstring);
            var html = htmlstring.ToHtmlString();
            Assert.IsTrue(!html.Contains("<a"));
            Assert.IsTrue(html.Contains("<span"));

            column.Sortable(true);

            htmlstring = renderer.Render(column);
            Assert.IsNotNull(htmlstring);
            html = htmlstring.ToHtmlString();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(html));
            Assert.IsTrue(html.Contains("<a"));

            Assert.IsTrue(html.Contains("class=\"grid-header-title\""));
        }
    }
}