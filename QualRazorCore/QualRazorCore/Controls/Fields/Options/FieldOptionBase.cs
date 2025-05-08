using QualRazorCore.Core;
using QualRazorCore.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Fields.Options
{
    public abstract class FieldOptionBase:NotifyCore, IOption,INotifyPropertyChanged
    {
    }

    public abstract class FieldOptionBase<TValue>: FieldOptionBase, IOption, INotifyPropertyChanged
    {
        protected TValue _value=default!;
        public TValue Value
        {
            get => _value;
            set
            {
                if(Equals(_value, value)) 
                {
                    return;
                }
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }

}
