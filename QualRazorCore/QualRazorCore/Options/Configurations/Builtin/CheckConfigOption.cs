using System.ComponentModel;
using QualRazorCore.Core;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.Configurations.Builtin
{
    public class CheckConfigOption<T> : ConfigOption, IConfigOption, IOption, INotifyPropertyChanged
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

        public CheckConfigOption() : base()
        {
        }

        public CheckConfigOption(string? placeHolder, T trueVale, T falseVale) : base()
        {
            _trueVale = trueVale;
            _falseVale = falseVale;
        }
    }

    public class CheckConfigOption : CheckConfigOption<bool>, IConfigOption, IOption, INotifyPropertyChanged
    {
    }
}
