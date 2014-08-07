using System.Runtime.Serialization;
using System.Web;

namespace GridMvc.Filtering
{
    /// <summary>
    ///     Structure that specifies filter settings for each column
    /// </summary>
    [DataContract]
    public struct ColumnFilterValue
    {
        //[DataMember(Name = "columnName")]
        public string ColumnName;

        [DataMember(Name = "filterType")] 
        public GridFilterType FilterType;

        public string FilterValue;

        [DataMember(Name = "filterValue")]
        internal string FilterValueEncoded
        {
            get { return HttpUtility.UrlEncode(FilterValue); }
            set { FilterValue = value; }
        }

        public static ColumnFilterValue Null
        {
            get { return default(ColumnFilterValue); }
        }

        public static bool operator ==(ColumnFilterValue a, ColumnFilterValue b)
        {
            return a.ColumnName == b.ColumnName && a.FilterType == b.FilterType && a.FilterValue == b.FilterValue;
        }

        public static bool operator !=(ColumnFilterValue a, ColumnFilterValue b)
        {
            return a.ColumnName != b.ColumnName || a.FilterType != b.FilterType || a.FilterValue != b.FilterValue;
        }
    }
}