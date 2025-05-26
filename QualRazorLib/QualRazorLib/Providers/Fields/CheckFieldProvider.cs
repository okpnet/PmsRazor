using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class CheckFieldProvider<T> : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
    {
        T _trueVale = default!;
        public T TrueValue
        {
            get => _trueVale;
            set
            {
                if (Equals(value, _trueVale))
                {
                    return;
                }
                _trueVale = value;
                OnPropertyChanged(nameof(TrueValue));
            }
        }
        T _falseVale = default!;
        public T FalseValue
        {
            get => _falseVale;
            set
            {
                if (Equals(value, _falseVale))
                {
                    return;
                }
                _trueVale = value;
                OnPropertyChanged(nameof(FalseValue));
            }
        }

        public CheckFieldProvider() : base()
        {
        }

        public CheckFieldProvider(T trueVale, T falseVale) : base()
        {
            _trueVale = trueVale;
            _falseVale = falseVale;
        }
    }
}
