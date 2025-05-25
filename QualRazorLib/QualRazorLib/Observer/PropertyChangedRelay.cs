using System.ComponentModel;

namespace QualRazorLib.Observer
{
    /// <summary>
    /// INotifyPropertyChangedを実装したオブジェクトの、指定したプロパティの変更イベントを監視し、
    /// プロパティ値の取得および変更時の処理をデリゲートで簡単に登録できるヘルパークラスです。
    /// <para>
    /// ・監視対象のプロパティ名、値の取得方法、変更時のコールバックを指定してインスタンス化します。<br/>
    /// ・Disposeを呼ぶことでイベント購読を解除できます。<br/>
    /// ・静的メソッドCreateにより、簡易的にIDisposableとして利用可能です。
    /// </para>
    /// </summary>
    /// <typeparam name="TSource">監視対象となるINotifyPropertyChanged実装クラスの型</typeparam>
    /// <typeparam name="TResult">監視するプロパティの型</typeparam>
    public class PropertyChangedRelay<TSource, TResult> : IDisposable where TSource : INotifyPropertyChanged
    {
        private readonly TSource _source;
        private readonly string _propertyName;
        private readonly Func<TSource, TResult> _valueSelector;
        private readonly Action<TResult> _onChanged;
        private readonly PropertyChangedEventHandler _handler;

        /// <summary>
        /// プロパティ変更監視の購読を開始します。
        /// </summary>
        /// <param name="source">監視対象のINotifyPropertyChanged実装インスタンス</param>
        /// <param name="propertyName">監視するプロパティ名</param>
        /// <param name="valueSelector">プロパティ値を取得するデリゲート</param>
        /// <param name="onChanged">プロパティ変更時に呼び出すコールバック</param>
        public PropertyChangedRelay(
            TSource source,
            string propertyName,
            Func<TSource, TResult> valueSelector,
            Action<TResult> onChanged)
        {
            _source = source;
            _propertyName = propertyName;
            _valueSelector = valueSelector;
            _onChanged = onChanged;

            // PropertyChangedイベントハンドラを生成し、プロパティ名一致時のみコールバックを実行
            _handler = (sender, e) =>
            {
                if (e.PropertyName == _propertyName)
                {
                    var value = _valueSelector(_source);
                    _onChanged(value);
                }
            };

            _source.PropertyChanged += _handler;
        }

        /// <summary>
        /// イベント購読を解除します。
        /// </summary>
        public void Dispose()
        {
            _source.PropertyChanged -= _handler;
        }

        /// <summary>
        /// プロパティ変更監視の購読を簡易的に生成します。
        /// </summary>
        /// <param name="source">監視対象のINotifyPropertyChanged実装インスタンス</param>
        /// <param name="propertyName">監視するプロパティ名</param>
        /// <param name="valueSelector">プロパティ値を取得するデリゲート</param>
        /// <param name="onChanged">プロパティ変更時に呼び出すコールバック</param>
        /// <returns>IDisposable（Disposeで購読解除）</returns>
        public static IDisposable Create<T, R>(T source,
            string propertyName,
            Func<T, R> valueSelector,
            Action<R> onChanged) where T : INotifyPropertyChanged
        {
            var result = new PropertyChangedRelay<T, R>(source, propertyName, valueSelector, onChanged);
            return result;
        }
    }
}