using System;

namespace GridMvc.Filtering.Types
{
    /// <summary>
    ///     Object contains some logic for filtering decimal columns
    /// </summary>
    internal sealed class DecimalFilterType : FilterTypeBase
    {
        public override Type TargetType
        {
            get { return typeof (Decimal); }
        }

        public override GridFilterType GetValidType(GridFilterType type)
        {
            switch (type)
            {
                case GridFilterType.Equals:
                case GridFilterType.GreaterThan:
                case GridFilterType.LessThan:
                case GridFilterType.GreaterThanOrEquals:
                case GridFilterType.LessThanOrEquals:
                    return type;
                default:
                    return GridFilterType.Equals;
            }
        }

        public override object GetTypedValue(string value)
        {
            decimal dec;
            if (!decimal.TryParse(value, out dec))
                return null;
            return dec;
        }
    }
}