
using QualRazorCore.Controls.Dialogs;
using QualRazorCore.Controls.Fields;
using QualRazorCore.Controls.Tables;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using QualRazorCore.Options.BuiltIn;
using QualRazorCore.Options.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace QualRazorCore.Options.Factories
{
    /// <summary>
    /// IOptionFactoryがサービスに登録されていないときに使用する標準のOptionパラメーターを生成するクラス
    /// </summary>
    public class DefaultOptionFactory : IOptionFactory
    {
        /// <summary>
        /// Type別の生成辞書
        /// OptionFactoryの標準を使用して型がないときはここに追加する
        /// </summary>
        private static readonly Dictionary<Type, Func<Type,IOption?>> _optionMap = new()
        {
            [typeof(int)] = (t) => new NumberOption<int>("", true, 0, null,null),
            [typeof(double)] = (t) => new NumberOption<double>("", false, 1, null, null),
            [typeof(bool)] = (t) => new BoolOption<bool>(),
            [typeof(decimal)]=(t)=> new NumberOption<decimal>(string.Empty, true, 1, null, null),
            [typeof(DateTime)]=(t)=>new DateTimeOption(string.Empty,false,Microsoft.AspNetCore.Components.Forms.InputDateType.Date,null),
            [typeof(TimeSpan)] = (t) => new TimespanOption(string.Empty, false, 0, null, BlazorCustomInput.Components.Unit.Hour),
            [typeof(string)] = (t) => new StringOption(string.Empty, false),
            [typeof(ModalDialogContent)] = (t) => new ModalDialogOption(),
            [typeof(TableContent<>)] = (t) =>
            {
                var result = Activator.CreateInstance(
                    typeof(TableSchemaOption<>).MakeGenericType(t.GenericTypeArguments),
                    BindingFlags.Public | BindingFlags.Instance) as IOption;
                return result!;
            }
        };
        /// <summary>
        /// 指定された型に対応する Option を生成する。
        /// ジェネリック型は型定義に基づいて判定される（例: TableContent&lt;T&gt;）。
        /// </summary>
        /// <param name="targetType">生成対象の型</param>
        /// <returns>生成された Option。未定義の場合は null。</returns>
        public IOption? Create<TRzorType>() where TRzorType : RazorCore
        {
            var targetType= typeof(TRzorType);
            Type? keytype = null;
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(FieldContent<,>))    
            {
                keytype = targetType.GenericTypeArguments[1];
            }
            if(targetType == typeof(ModalDialogContent))
            {
                keytype = typeof(ModalDialogContent);
            }

            if (keytype is null || !_optionMap.TryGetValue(keytype, out var function))
            {
                return null;
            }
            return function.Invoke(targetType);
        }
    }
}
