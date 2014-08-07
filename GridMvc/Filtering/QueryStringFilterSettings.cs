using System;
using System.Linq;
using System.Web;

namespace GridMvc.Filtering
{
    /// <summary>
    ///     Object gets filter settings from query string
    /// </summary>
    public class QueryStringFilterSettings : IGridFilterSettings
    {
        public const string DefaultTypeQueryParameter = "grid-filter";
        private const string FilterDataDelimeter = "__";
        public const string DefaultFilterInitQueryParameter = "gridinit";
        public readonly HttpContext Context;
        private readonly DefaultFilterColumnCollection _filterValues = new DefaultFilterColumnCollection();

        #region Ctor's

        public QueryStringFilterSettings()
            : this(HttpContext.Current)
        {
        }

        public QueryStringFilterSettings(HttpContext context)
        {
            if (context == null)
                throw new ArgumentException("No http context here!");
            Context = context;

            string[] filters = Context.Request.QueryString.GetValues(DefaultTypeQueryParameter);
            if (filters != null)
            {
                foreach (string filter in filters)
                {
                    ColumnFilterValue column = CreateColumnData(filter);
                    if (column != ColumnFilterValue.Null)
                        _filterValues.Add(column);
                }
            }
        }

        #endregion

        private ColumnFilterValue CreateColumnData(string queryParameterValue)
        {
            if (string.IsNullOrEmpty(queryParameterValue))
                return ColumnFilterValue.Null;

            string[] data = queryParameterValue.Split(new[] {FilterDataDelimeter}, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length != 3)
                return ColumnFilterValue.Null;
            GridFilterType type;
            if (!Enum.TryParse(data[1], true, out type))
                type = GridFilterType.Equals;

            return new ColumnFilterValue {ColumnName = data[0], FilterType = type, FilterValue = data[2]};
        }

        #region IGridFilterSettings Members

        public IFilterColumnCollection FilteredColumns
        {
            get { return _filterValues; }
        }

        public bool IsInitState
        {
            get
            {
                if (FilteredColumns.Any()) return false;
                return Context.Request.QueryString[DefaultFilterInitQueryParameter] != null;
            }
        }

        #endregion
    }
}