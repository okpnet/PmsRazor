using QualRazorCore.Core;
using System.ComponentModel;

namespace QualRazorCore.Controls.InputFields.Options.Core
{
    public abstract class OptionBase : NotifyCore, INotifyPropertyChanged
    {
        public string? PlaceHolder { get; set; }

        protected OptionBase(string? placeHolder)
        {
            PlaceHolder = placeHolder;
        }
    }
}
