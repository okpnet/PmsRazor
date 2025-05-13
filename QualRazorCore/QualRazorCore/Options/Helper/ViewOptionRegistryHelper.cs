using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.ViewOptions.Builtin;
using QualRazorCore.Options.ViewOptions.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Helper
{
    public static class ViewOptionRegistryHelper
    {
        public static IOptionKey? RegisterFromType<TRazor>(this IViewOptionRegistry registry) where TRazor : OptionParameterRazorCore
        {
            var key = OptionKeyFactory.CreateDefaultKey<TRazor>();
            registry.Register(key, new ViewOption());
            return key;
        }

        public static IOptionKey? RegisterFromType<TRazor>(this IViewOptionRegistry registry, Dictionary<string, object> addribute) where TRazor : OptionParameterRazorCore
        {
            var key = OptionKeyFactory.CreateDefaultKey<TRazor>();
            registry.Register(key, new ViewOption(addribute));
            return key;
        }

        public static IOptionKey? RegisterFromExpression<TRazor, TRefProperty>(
            this IViewOptionRegistry registry,
            Expression<Func<TRazor, TRefProperty>> refExpression) where TRazor : OptionParameterRazorCore
        {
            var key = OptionKeyFactory.CreatePropertyPathkey(refExpression);
            registry.Register(key, new ViewOption());
            return key;
        }

        public static IOptionKey? RegisterFromExpression<TRazor, TRefProperty>(
            this IViewOptionRegistry registry,
            Expression<Func<TRazor, TRefProperty>> refExpression,
            Dictionary<string, object> attribute) where TRazor : OptionParameterRazorCore
        {
            var name = string.Join(".", typeof(TRazor).Name, ExpressionHelper.GetPropertyPath(refExpression));
            var key = OptionKeyFactory.CreatePropertyPathkey(refExpression);
            registry.Register(key, new ViewOption(attribute));
            return key;
        }
    }
}
