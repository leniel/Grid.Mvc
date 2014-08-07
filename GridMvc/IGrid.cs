using System.Collections.Generic;
using GridMvc.Columns;
using GridMvc.Html;
using GridMvc.Pagination;

namespace GridMvc
{
    /// <summary>
    ///     Grid.Mvc interface
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        ///     Grid render options
        /// </summary>
        GridRenderOptions RenderOptions { get; }

        /// <summary>
        ///     Grid columns
        /// </summary>
        IGridColumnCollection Columns { get; }

        /// <summary>
        ///     Grid items
        /// </summary>
        IEnumerable<object> ItemsToDisplay { get; }

        ///// <summary>
        /////     Total grid items count
        ///// </summary>
        //int ItemsCount { get; set; }

        /// <summary>
        ///     Displaying grid items count
        /// </summary>
        int DisplayingItemsCount { get; }

        /// <summary>
        ///     Total items count in the grid (after filtering)
        /// </summary>
        int ItemsCount { get;  }

        /// <summary>
        ///     Pager for the grid
        /// </summary>
        IGridPager Pager { get; }

        /// <summary>
        ///     Enable paging view
        /// </summary>
        bool EnablePaging { get; }

        /// <summary>
        ///     Text in empty grid (no items for display)
        /// </summary>
        string EmptyGridText { get; }

        /// <summary>
        ///     Returns the current Grid language
        /// </summary>
        string Language { get; }

        /// <summary>
        ///     Object that sanitize grid column values from dangerous content
        /// </summary>
        ISanitizer Sanitizer { get; }

        IGridSettingsProvider Settings { get; }

        /// <summary>
        ///     Get all css classes mapped to the item
        /// </summary>
        string GetRowCssClasses(object item);

        //void OnPreRender(); //TODO backward Compatibility
    }
}