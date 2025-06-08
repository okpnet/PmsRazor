using QualRazorLib.Helpers;
using QualRazorLib.Presentation.Facades;
using System.Linq.Expressions;

namespace QualRazorLib.Models.Conditions
{
    /// <summary>
    /// 単一のプロパティやオブジェクトに対する絞り込み条件を保持するDTOの基底クラスです。
    /// プロパティ名（またはプロパティパス）と、複数の条件（ConditionEntry）を管理します。
    /// </summary>
    public abstract class ValueFilterModel : IValueFilter
    {
        /// <summary>
        /// 絞り込み条件のリスト。
        /// </summary>
        protected List<ConditionEntry> _values = [];

        /// <summary>
        /// 絞り込み対象のプロパティ名（またはプロパティパス）。
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 絞り込み条件のリスト（読み取り専用）。
        /// </summary>
        public IReadOnlyList<ConditionEntry> Conditions => _values;

        /// <summary>
        /// プロパティ名と条件リストを指定して初期化します。
        /// </summary>
        /// <param name="name">プロパティ名またはプロパティパス</param>
        /// <param name="values">条件エントリの配列</param>
        public ValueFilterModel(string name, params ConditionEntry[] values)
        {
            ArgumentNullException.ThrowIfNull(name);
            Name = name;
            foreach (var value in values)
            {
                _values.Add(value);
            }
        }
    }

    /// <summary>
    /// 単一のプロパティに対する型安全な絞り込み条件を保持するDTOクラスです。
    /// プロパティを表す式（PropertyExpression）と、条件リストを管理します。
    /// </summary>
    /// <typeparam name="TModel">絞り込み対象のモデルの型</typeparam>
    /// <typeparam name="TValue">絞り込み対象のプロパティの型</typeparam>
    public class ValueFilterModel<TModel, TValue> : ValueFilterModel, IValueFilter<TModel, TValue>, IValueFilter
    {
        /// <summary>
        /// 絞り込み対象プロパティを表す式。
        /// </summary>
        public Expression<Func<TModel, TValue>> PropertyExpression { get; }

        /// <summary>
        /// プロパティ式と条件リストを指定して初期化します。
        /// </summary>
        /// <param name="propertyExpression">プロパティを表す式</param>
        /// <param name="values">条件エントリの配列</param>
        public ValueFilterModel(Expression<Func<TModel, TValue>> propertyExpression, params ConditionEntry[] values) :
            base(ExpressionHelper.GetPropertyPath(propertyExpression), values)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);
            PropertyExpression = propertyExpression;
        }
    }
}