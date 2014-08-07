using GridMvc.Filtering;
using GridMvc.Sorting;

namespace GridMvc
{
    /// <summary>
    ///     Setting for grid
    /// </summary>
    public interface IGridSettingsProvider
    {
        IGridSortSettings SortSettings { get; }
        IGridFilterSettings FilterSettings { get; }
        IGridColumnHeaderRenderer GetHeaderRenderer();
    }
}