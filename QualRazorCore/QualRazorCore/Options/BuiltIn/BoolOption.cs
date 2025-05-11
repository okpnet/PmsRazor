using System.ComponentModel;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.BuiltIn
{
    public class BoolOption<T> : FieldOption,IOption, INotifyPropertyChanged
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

        public BoolOption():base()
        {
        }

        public BoolOption(string? placeHolder, T trueVale, T falseVale) : base()
        {
            _trueVale = trueVale;
            _falseVale = falseVale;
        }
    }
}
