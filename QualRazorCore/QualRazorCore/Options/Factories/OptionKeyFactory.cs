using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.Factories
{
    public static class OptionKeyFactory
    {
        public static OptionKey<TResult> FromExpression<T, TResult>(Expression<Func<T, TResult>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            var name = GetFullPropertyPath(propertyExpression.Body);
            return OptionKey<TResult>.Create(name);
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
