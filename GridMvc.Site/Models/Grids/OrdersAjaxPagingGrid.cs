using System.Linq;
using GridMvc.Pagination;

namespace GridMvc.Site.Models.Grids
{
    public class OrdersAjaxPagingGrid : OrdersGrid
    {
        public OrdersAjaxPagingGrid(IQueryable<Order> items, int page, bool renderOnlyRows)
            : base(items)
        {
            Pager = new AjaxGridPager(this) { CurrentPage = page }; ; //override  default pager
            RenderOptions.RenderRowsOnly = renderOnlyRows;
        }
    }

    public class AjaxGridPager : IGridPager
    {
        private readonly IGrid _grid;

        public AjaxGridPager(IGrid grid)
        {
            _grid = grid;
        }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string TemplateName
        {
            get
            {
                //Custom view name to render this pager
                return "_AjaxGridPager";
            }
        }

        /// <summary>
        ///     Returns true if the pager has pages
        /// </summary>
        public bool HasPages
        {
            get
            {
                return _grid.ItemsToDisplay.Count() >= PageSize;
            }
        }

        public void Initialize<T>(IQueryable<T> items)
        {
            //do nothing
        }
    }
}