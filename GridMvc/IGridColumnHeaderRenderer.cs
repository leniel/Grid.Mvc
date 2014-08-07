using System.Web;
using GridMvc.Columns;

namespace GridMvc
{
    /// <summary>
    ///     Renderer of the header
    /// </summary>
    public interface IGridColumnHeaderRenderer
    {
        /// <summary>
        ///     Render grid header
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>HTML</returns>
        IHtmlString Render(IGridColumn column);
    }
}