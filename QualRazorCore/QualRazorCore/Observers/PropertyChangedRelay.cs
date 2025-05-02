using System.ComponentModel;

namespace QualRazorCore.Observers
{
    /// <summary>
    /// プロパティ変更イベントを監視します
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class PropertyChangedRelay<TSource, TResult> : IDisposable where TSource : INotifyPropertyChanged
    {
        private readonly TSource _source;
        private readonly string _propertyName;
        private readonly Func<TSource, TResult> _valueSelector;
        private readonly Action<TResult> _onChanged;
        private readonly PropertyChangedEventHandler _handler;

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

        public void Dispose()
        {
            _source.PropertyChanged -= _handler;
        }
        /// <summary>
        /// イベント監視するデリゲートを生成
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="valueSelector"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        public static IDisposable Create(TSource source,
            string propertyName,
            Func<TSource, TResult> valueSelector,
            Action<TResult> onChanged)
        {
            var result=new PropertyChangedRelay<TSource, TResult>(source, propertyName, valueSelector, onChanged);
            return result;
        }
    }
}
