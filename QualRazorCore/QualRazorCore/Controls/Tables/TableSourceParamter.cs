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
        public Guid Key { get; }=Guid.NewGuid();

        public abstract object BaseRow { get; }

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

        protected int _rowindex=-1;
        public int RowIndex
        {
            get => _rowindex;
            protected set
            {
                if (_rowindex == value)
                {
                    return;
                }
                OnPropertyChanged(nameof(RowIndex));
            }
        }

        protected TableSourceParamter(bool isSelected, int rowindex)
        {
            _isSelected = isSelected;
            _rowindex = rowindex;
        }
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

        public TableSourceParamter(bool isSelected, int rowindex,TModel row) : base(isSelected, rowindex)
        {
            _row= row;
        }
    }
}
