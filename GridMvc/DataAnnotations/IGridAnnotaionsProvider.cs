using System.Reflection;

namespace GridMvc.DataAnnotations
{
    internal interface IGridAnnotaionsProvider
    {
        GridColumnAttribute GetAnnotationForColumn<T>(PropertyInfo pi);
        GridHiddenColumnAttribute GetAnnotationForHiddenColumn<T>(PropertyInfo pi);

        bool IsColumnMapped(PropertyInfo pi);

        GridTableAttribute GetAnnotationForTable<T>();
    }
}