using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorCustomInput.Components;
using QualRazorCore.Controls.InputFields.Options.Core;
using QualRazorCore.Options;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class StringOption:OptionBase, IOption, INotifyPropertyChanged
    {
        bool _isMultiLine;
        public bool IsMutiLine
        {
            get => _isMultiLine;
            set
            {
                if (_isMultiLine == value)
                {
                    return;
                }
                _isMultiLine = value;
                OnPropertyChanged(nameof(IsMutiLine));
            }
        }

        public virtual TextEditType TextEditType => TextEditType.Text;

        public StringOption(string? placeHolder, bool isMultiLine):base(placeHolder)
        {
            _isMultiLine = isMultiLine;
        }
    }
}
