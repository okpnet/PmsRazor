using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Helper
{
    public static class OptionKeyFactory
    {
        public static IOptionKey CreateDefaultKey<T>() =>
            new OptionKey(typeof(T).Name, typeof(T));

        public static IOptionKey CreatePropertyPathkey<T, R>(Expression<Func<T, R>> expression) =>
            new OptionKey(string.Join(".", typeof(T).Name, ExpressionHelper.GetPropertyPath(expression)), typeof(T));

        public static IOptionKey CreatePropertyPathkey<T, R>(this T value, Expression<Func<T, R>> expression) => CreatePropertyPathkey(expression);

        public static IOptionKey CreateTypePathkey<T, R>(Type type, Expression<Func<T, R>> expression) =>
            new OptionKey(string.Join(".", type.Name, ExpressionHelper.GetPropertyPath(expression)), type);



        [Obsolete]
        public static IOptionKey CreatePropertyPathkeyWithOutSelfType<T, R>(Expression<Func<T, R>> expression) =>
            new OptionKey(ExpressionHelper.GetPropertyPath(expression), typeof(T));

        [Obsolete]
        public static IOptionKey CreateTypePathkeyWithOutSelfType<T, R>(Type type, Expression<Func<T, R>> expression) =>
            new OptionKey(ExpressionHelper.GetPropertyPath(expression), type);

    }
}
