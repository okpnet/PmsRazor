using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Extenssions
{
    public static class ExpressionHelper
    {
        public static string GetPropertyPath<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression)
        {
            return GetFullPropertyPath(propertyExpression.Body);
        }

        public static Func<TOwner, TOptionType> BuildGetter<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression)
        {
            return propertyExpression.Compile();
        }

        public static Action<TOwner, TOptionType> BuildSetter<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression)
        {
            if (propertyExpression.Body is not MemberExpression memberExpr)
                throw new ArgumentException("Expression must be a MemberExpression", nameof(propertyExpression));

            var target = propertyExpression.Parameters[0];
            var valueParam = Expression.Parameter(typeof(TOptionType), "value");

            var assign = Expression.Assign(memberExpr, valueParam);
            var lambda = Expression.Lambda<Action<TOwner, TOptionType>>(assign, target, valueParam);

            return lambda.Compile();

        }

        private static string GetFullPropertyPath(Expression expression)
        {
            var stack = new Stack<string>();

            while (expression is MemberExpression memberExpr)
            {
                stack.Push(memberExpr.Member.Name);
                expression = memberExpr.Expression!;
            }

            return string.Join(".", stack);
        }
    }
}
