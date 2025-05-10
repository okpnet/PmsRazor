using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Forms
{
    public class FormOption<TModel> : NotifyCore, INotifyPropertyChanged
    {
        ObservableCollection<IPropertyValueOption> _propertyValueOptions=new();

        public ReadOnlyObservableCollection<IPropertyValueOption> ValueOptions =>new(_propertyValueOptions);

        public void AddPropertyOption<TPropertyValue>(Expression<Func<TModel,TPropertyValue>> property)
        {

        }
    }
}
