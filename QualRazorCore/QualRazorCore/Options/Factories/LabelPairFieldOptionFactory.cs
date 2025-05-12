using QualRazorCore.Controls.Fields;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.BuiltIn;
using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Factories
{
    public class LabelPairFieldOptionFactory: IOptionFactory, IExtendOptionFactory
    {
        /// <summary>
        /// 指定された型に対応する Option を生成する。
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public IOption? Create<TRzorType>() where TRzorType : RazorCore
        {
            var targetType=typeof(TRzorType);
            if (!targetType.IsGenericType || targetType.GetGenericTypeDefinition() != typeof(LabelPairField<,>))    
            {
                return null;
            }

            var typeArgs = targetType.GenericTypeArguments;
            if (typeArgs.Length != 2) return null;

            var fieldKey=Activator.CreateInstance(
                typeof(OptionKey<>).MakeGenericType(typeArgs[1])) as IOptionKey;

            var labelKey = OptionKey<LabelOption>.Create(nameof(FieldContent));

            var result = Activator.CreateInstance(
                typeof(LabelFieldPairOption<,>).MakeGenericType(typeArgs),
                OptionKey<>
                ) as IOption;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IOption? Create<TModel, TProperty>(Type targetType ,Expression<Func<TModel, TProperty>> expression)
        {
            if (!targetType.IsGenericType || targetType.GetGenericTypeDefinition() != typeof(LabelPairField<,>))
                return null;

            var fieldKey = OptionKey<TProperty>.Create(ExpressionHelper.GetPropertyPath(expression));
            var lablelKey = OptionKey<LabelOption>.Create(nameof(LabelOption));

            var result = Activator.CreateInstance(
                typeof(LabelFieldPairOption<,>).MakeGenericType(typeof(TModel), typeof(TProperty)), 
                lablelKey,
                fieldKey) as IOption;

            return result;
        }

        
    }
}
