using System.Linq;

namespace GridMvc.Pagination
{
    /// <summary>
    ///     Cut's the current page from items collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagerGridItemsProcessor<T> : IGridItemsProcessor<T> where T : class
    {
        private readonly IGridPager _pager;

        public PagerGridItemsProcessor(IGridPager pager)
        {
            _pager = pager;
        }

        #region IGridItemsProcessor<T> Members

        public IQueryable<T> Process(IQueryable<T> items)
        {
            _pager.Initialize(items); //init pager

            if (_pager.CurrentPage <= 0) return items; //incorrect page

            int skip = (_pager.CurrentPage - 1)*_pager.PageSize;
            return items.Skip(skip).Take(_pager.PageSize);
        }

        #endregion
    }
}