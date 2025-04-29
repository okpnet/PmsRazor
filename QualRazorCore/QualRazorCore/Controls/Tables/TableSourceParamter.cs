using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables
{
    public abstract class TableSourceParamter:NotifyCore
    {
        public abstract object BaseRow { get; }
    }
    public class TableSourceParamter<TModel>: TableSourceParamter
    {
        public override object BaseRow => Row??default!;

        protected TModel _row = default!;
        public TModel Row
        {
            get => _row;
            set
            {
                if (Equals( _row , value))
                {
                    return;
                }
                _row = value;
                OnPropertyChanged(nameof(Row));
            }
        }

        protected bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                {
                    return;
                }
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }


    }
}
