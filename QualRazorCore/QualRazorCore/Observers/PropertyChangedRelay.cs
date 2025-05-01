using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Observers
{
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
