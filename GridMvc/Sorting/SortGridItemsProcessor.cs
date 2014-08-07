using System;
using System.Linq;
using GridMvc.Columns;

namespace GridMvc.Sorting
{
    /// <summary>
    ///     Settings grid items, based on current sorting settings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SortGridItemsProcessor<T> : IGridItemsProcessor<T> where T : class
    {
        private readonly IGrid _grid;
        private IGridSortSettings _settings;

        public SortGridItemsProcessor(IGrid grid, IGridSortSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            _grid = grid;
            _settings = settings;
        }

        public void UpdateSettings(IGridSortSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            _settings = settings;
        }

        #region IGridItemsProcessor<T> Members

        public IQueryable<T> Process(IQueryable<T> items)
        {
            if (string.IsNullOrEmpty(_settings.ColumnName))
                return items;
            //determine gridColumn sortable:
            var gridColumn = _grid.Columns.FirstOrDefault(c => c.Name == _settings.ColumnName) as IGridColumn<T>;
            if (gridColumn == null || !gridColumn.SortEnabled)
                return items;
            foreach (var columnOrderer in gridColumn.Orderers)
            {
                items = columnOrderer.ApplyOrder(items, _settings.Direction);
            }
            return items;
        }

        #endregion
    }
}