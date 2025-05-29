using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Providers.Fields
{
    public interface IInputTypeProvider
    {
        FieldDataType InputType { get; } // "text", "number", "date"など


    }
    public interface IInputTypeProvider<TModel, TProperty> : IInputTypeProvider
        where TModel : class
    {
        TModel Model { get; set; } // モデルのインスタンス
        TProperty Value { get; set; } // プロパティの値
        Action<TModel, TProperty>? Setter { get; set; } // セッター
        Func<TModel, TProperty> Getter { get; } // ゲッター
        Expression<Func<TModel, TProperty>> PropertyExpression { get; } // プロパティの式
    }
