using QualRazorCore.Controls.InputFields.Options.Core;
using QualRazorCore.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class BoolOption<T>:OptionBase, IOption, INotifyPropertyChanged
    {
        T _trueVale=default!;
        public T TrueValue
        {
            get => _trueVale;
            set
            {
                if(Equals(value, _trueVale)) 
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

        public BoolOption(string? placeHolder, T trueVale, T falseVale):base(placeHolder)
        {
            _trueVale = trueVale;
            _falseVale = falseVale;
        }
    }
}
