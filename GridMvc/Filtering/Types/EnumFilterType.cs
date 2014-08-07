using System;
using System.Linq.Expressions;

namespace GridMvc.Filtering.Types
{
    internal sealed class EnumFilterType : FilterTypeBase
    {
        public override Type TargetType
        {
            get { return typeof(Enum); }
        }

        public override GridFilterType GetValidType(GridFilterType type)
        {
            switch(type)
            {
                case GridFilterType.Equals:
                    return type;
                default:
                    return GridFilterType.Equals;
            }
        }

        public override object GetTypedValue(string value)
        {
            return value;
        }

        public override Expression GetFilterExpression(Expression leftExpr, string value, GridFilterType filterType)
        {
            //Custom implementation of string filter type. Case insensitive comparison.

            filterType = GetValidType(filterType);

            object typedValue = GetTypedValue(value);

            if(typedValue == null)
                return null; // incorrect filter value;

            Expression valueExpr = Expression.Constant(typedValue);
            Expression binaryExpression;

            switch(filterType)
            {
                case GridFilterType.Equals:
                    binaryExpression = GetEqualsСompartion(string.Empty, leftExpr, valueExpr);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return binaryExpression;
        }
        private Expression GetEqualsСompartion(string methodName, Expression leftExpr, Expression rightExpr)
        {

            Type targetType = leftExpr.Type;

            var someValue = Expression.Constant(Enum.Parse(targetType, (rightExpr as ConstantExpression).Value.ToString()));
            //Enum.ToObject(targetType, (rightExpr as System.Linq.Expressions.ConstantExpression).Value));

            var equalsExp = Expression.Equal(leftExpr, someValue);

            return equalsExp;
        }
    }
}