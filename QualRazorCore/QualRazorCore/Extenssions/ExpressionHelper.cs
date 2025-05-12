using System.Linq.Expressions;
using System.Reflection;

namespace QualRazorCore.Extenssions
{
    public static class ExpressionHelper
    {
        public static string GetPropertyPath<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression)
        {
            return GetFullPropertyPath(propertyExpression.Body);
        }

        /// <summary>
        /// ゲッター式を生成する。プロパティではないとき、InvalidOperationExceptionが発生する。
        /// </summary>
        /// <typeparam name="TOwner"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Func<TOwner, TProperty> BuildGetter<TOwner, TProperty>(Expression<Func<TOwner, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is not MemberExpression memberExpr)
                throw new ArgumentException("Expression must be a MemberExpression", nameof(propertyExpression));

            // チェック用にメンバーを辿る
            Expression? current = memberExpr;
            while (current is MemberExpression m)
            {
                if (m.Member is not PropertyInfo prop)
                    throw new ArgumentException("Member is not a property", nameof(propertyExpression));

                var getter = prop.GetGetMethod(nonPublic: false);
                if (getter == null)
                    throw new InvalidOperationException($"Property '{prop.Name}' does not have a public getter.");

                current = m.Expression;
            }

            // 式の再構築なしで、そのまま使用
            return propertyExpression.Compile();
        }
        /// <summary>
        /// セッター式を生成する。セッターがパブリックではないときInvalidOperationExceptionの例外が発生する。
        /// </summary>
        /// <typeparam name="TOwner"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Action<TOwner, TProperty> BuildSetter<TOwner, TProperty>(Expression<Func<TOwner, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is not MemberExpression memberExpr)
                throw new ArgumentException("Expression must be a MemberExpression", nameof(propertyExpression));

            // 右辺: value（代入する値）
            var valueParam = Expression.Parameter(typeof(TProperty), "value");

            // 左辺の最も深いプロパティ（例: Baz）を探す
            var memberStack = new Stack<MemberExpression>();
            Expression? current = memberExpr;

            while (current is MemberExpression m)
            {
                memberStack.Push(m);
                current = m.Expression;
            }

            if (memberStack.Count == 0)
                throw new ArgumentException("No valid member expression found", nameof(propertyExpression));

            // 所有者（TOwner）のパラメータ（例: x）
            var ownerParam = propertyExpression.Parameters[0];

            // 左辺の構築（ネストされたオブジェクトのプロパティアクセスを構築）
            Expression? targetExpr = ownerParam;
            while (memberStack.Count > 1) // 最後は setter の対象なので飛ばす
            {
                var m = memberStack.Pop();
                targetExpr = Expression.MakeMemberAccess(targetExpr, m.Member);
            }

            var finalMember = memberStack.Pop();
            if (finalMember.Member is not PropertyInfo finalProp)
                throw new ArgumentException("The final member is not a property.", nameof(propertyExpression));

            var setterMethod = finalProp.GetSetMethod(nonPublic: false);
            if (setterMethod == null)
                throw new InvalidOperationException($"Property '{finalProp.Name}' does not have a public setter.");

            // 左辺: targetExpr.FinalProperty = value
            var assignExpr = Expression.Assign(
                Expression.Property(targetExpr!, finalProp),
                valueParam
            );

            var lambda = Expression.Lambda<Action<TOwner, TProperty>>(assignExpr, ownerParam, valueParam);
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
