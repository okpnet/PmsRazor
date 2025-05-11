using QualRazorCore.Controls.Fields;
using QualRazorCore.Options.BuiltIn;
using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Factories
{
    /// <summary>
    /// IOptionFactoryがサービスに登録されていないときに使用する標準のOptionパラメーターを生成するクラス
    /// </summary>
    public class PropertyFieldOptionFactory : IOptionFactory,IExtendOptionFactory
    {
        /// <summary>
        /// 指定された型に対応する Option を生成する。
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public IOption? Create(Type targetType)
        {
            if (!targetType.IsGenericType || targetType.GetGenericTypeDefinition() != typeof(FieldContent<,>))
                return null;

            var typeArgs = targetType.GenericTypeArguments;
            if (typeArgs.Length != 2) return null;

            var result = Activator.CreateInstance(
                typeof(PropertyFieldOption<,>).MakeGenericType(typeArgs)) as IFieldOption;

            if (result is IFieldOption fieldOpt)
            {
                var fieldType = typeArgs[1];
                var fallback = new DefaultOptionFactory();
                fieldOpt.FieldOption = fallback.Create(fieldType)!;
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IOption? Create<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var result = Activator.CreateInstance(
                typeof(PropertyFieldOption<,>).MakeGenericType(typeof(TModel), typeof(TProperty)), expression) as IFieldOption;

            if (result is IFieldOption fieldOpt)
            {
                var fieldType = typeof(TProperty);
                var fallback = new DefaultOptionFactory();
                fieldOpt.FieldOption = fallback.Create(fieldType)!;
            }

            return result;
        }
    }

}
