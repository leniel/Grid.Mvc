using System.Globalization;
using System.Web;
using System.Web.Mvc;
using GridMvc.Columns;
using GridMvc.Pagination;
using GridMvc.Utility;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Renderer for sortable column.
    ///     Object renders column name as link
    /// </summary>
    internal class QueryStringSortColumnHeaderRenderer : IGridColumnHeaderRenderer
    {
        private readonly QueryStringSortSettings _settings;

        public QueryStringSortColumnHeaderRenderer(QueryStringSortSettings settings)
        {
            _settings = settings;
        }

        public IHtmlString Render(IGridColumn column)
        {
            return MvcHtmlString.Create(GetSortHeaderContent(column));
        }

        protected string GetSortHeaderContent(IGridColumn column)
        {
            var sortTitle = new TagBuilder("div");
            sortTitle.AddCssClass("grid-header-title");

            if (column.SortEnabled)
            {
                var columnHeaderLink = new TagBuilder("a")
                    {
                        InnerHtml = column.Title
                    };
                string url = GetSortUrl(column.Name, column.Direction);
                columnHeaderLink.Attributes.Add("href", url);
                sortTitle.InnerHtml += columnHeaderLink.ToString();
            }
            else
            {
                var columnTitle = new TagBuilder("span")
                    {
                        InnerHtml = column.Title
                    };
                sortTitle.InnerHtml += columnTitle.ToString();
            }

            if (column.IsSorted)
            {
                sortTitle.AddCssClass("sorted");
                sortTitle.AddCssClass(column.Direction == GridSortDirection.Ascending ? "sorted-asc" : "sorted-desc");

                var sortArrow = new TagBuilder("span");
                sortArrow.AddCssClass("grid-sort-arrow");
                sortTitle.InnerHtml += sortArrow.ToString();
            }
            return sortTitle.ToString();
        }

        private string GetSortUrl(string columnName, GridSortDirection? direction)
        {
            //switch direction for link:
            GridSortDirection newDir = direction == GridSortDirection.Ascending
                                           ? GridSortDirection.Descending
                                           : GridSortDirection.Ascending;
            //determine current url:
            var builder = new CustomQueryStringBuilder(_settings.Context.Request.QueryString);
            string url =
                builder.GetQueryStringExcept(new[]
                    {
                        GridPager.DefaultPageQueryParameter,
                        _settings.ColumnQueryParameterName,
                        _settings.DirectionQueryParameterName
                    });
            if (string.IsNullOrEmpty(url))
                url = "?";
            else
                url += "&";
            return string.Format("{0}{1}={2}&{3}={4}", url, _settings.ColumnQueryParameterName, columnName,
                                 _settings.DirectionQueryParameterName,
                                 ((int) newDir).ToString(CultureInfo.InvariantCulture));
        }
    }
}