using System.Web;

namespace GridMvc
{
    public class GridCell : IGridCell
    {
        private readonly string _value;

        public GridCell(string value)
        {
            _value = value;
        }

        public bool Encode { get; set; }

        #region IGridCell Members

        public string Value
        {
            get
            {
                return Encode && !string.IsNullOrEmpty(_value)
                           ? HttpUtility.HtmlEncode(_value)
                           : _value;
            }
        }

        #endregion

        public override string ToString()
        {
            return Value;
        }
    }
}