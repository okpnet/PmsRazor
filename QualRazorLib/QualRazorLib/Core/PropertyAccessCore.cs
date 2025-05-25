using QualRazorLib.Helpers;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorLib.Core
{
    /// <summary>
    /// プロパティ変更イベントを監視し、プロパティ名や型情報を保持する基底クラスです。
    /// このクラスは、派生クラスでプロパティへのアクセス方法を提供するための共通機能を持ちます。
    /// </summary>
    public abstract class PropertyAccessCore : NotifyCore, INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティを一意に識別するキー。
        /// </summary>
        public Guid Key { get; } = Guid.NewGuid();

        /// <summary>
        /// アクセス対象プロパティの名前。
        /// </summary>
        protected string _propertyName = string.Empty;

        /// <summary>
        /// アクセス対象プロパティの名前。
        /// 値が変更されると PropertyChanged イベントが発火します。
        /// </summary>
        public string PropertyName
        {
            get => _propertyName;
            set
            {
                if (_propertyName == value)
                {
                    return;
                }
                _propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }

        /// <summary>
        /// アクセス対象プロパティの型情報。
        /// </summary>
        public abstract Type PropertyValueType { get; }
    }

    /// <summary>
    /// 指定したクラスインスタンスのプロパティにアクセスするためのクラスです。
    /// コンストラクタで指定したプロパティに対して、値の取得・設定やプロパティ名・型情報の取得が可能です。
    /// </summary>
    /// <typeparam name="TModel">プロパティを持つクラスの型</typeparam>
    /// <typeparam name="TResult">プロパティの型</typeparam>
    public class PropertyAccessCore<TModel, TResult> : PropertyAccessCore, INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティの値を取得するためのデリゲート。
        /// </summary>
        protected Func<TModel, TResult> _getter;

        /// <summary>
        /// プロパティの値を取得するためのデリゲート。
        /// 値が変更されると PropertyChanged イベントが発火します。
        /// </summary>
        public Func<TModel, TResult> Getter
        {
            get => _getter;
            set
            {
                if (Equals(value, _getter))
                {
                    return;
                }
                _getter = value;
                OnPropertyChanged(nameof(Getter));
            }
        }

        /// <summary>
        /// プロパティの値を設定するためのデリゲート。
        /// </summary>
        protected Action<TModel, TResult>? _setter;

        /// <summary>
        /// プロパティの値を設定するためのデリゲート。
        /// 値が変更されると PropertyChanged イベントが発火します。
        /// </summary>
        public Action<TModel, TResult>? Setter
        {
            get => _setter;
            set
            {
                if (Equals(_setter, value))
                {
                    return;
                }
                _setter = value;
                OnPropertyChanged(nameof(Setter));
            }
        }

        /// <summary>
        /// アクセス対象プロパティの型情報。
        /// </summary>
        public override Type PropertyValueType => typeof(TResult);

        /// <summary>
        /// プロパティ式からプロパティ名・Getter・Setterを生成して初期化します。
        /// </summary>
        /// <param name="propertyExpression">アクセス対象プロパティを示す式</param>
        protected PropertyAccessCore(Expression<Func<TModel, TResult>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _propertyName = ExpressionHelper.GetPropertyPath(propertyExpression);
            _getter = ExpressionHelper.BuildGetter(propertyExpression);
            _setter = ExpressionHelper.BuildSetter(propertyExpression);
        }

        /// <summary>
        /// プロパティ名とプロパティ式からプロパティ情報を初期化します。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="propertyExpression">アクセス対象プロパティを示す式</param>
        protected PropertyAccessCore(string propertyName, Expression<Func<TModel, TResult>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _propertyName = propertyName;
            _getter = ExpressionHelper.BuildGetter(propertyExpression);
            _setter = ExpressionHelper.BuildSetter(propertyExpression);
        }
    }
}