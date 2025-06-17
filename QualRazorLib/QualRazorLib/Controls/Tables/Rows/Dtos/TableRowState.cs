using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables.Rows.Dtos
{
    public abstract class TableRowState : NotifyCore, IRowDataHolder
    {
        public abstract object BaseData { get; }
    }

    public class TableRowState<TModel> : TableRowState, IDataHolder<TModel>, IRowDataHolder<TModel>, IRowDataHolder
    {
        public override object BaseData => _data;

        protected TModel _data = default!;
        public TModel Data
        {
            get => _data;
            set
            {
                if(Equals(_data, value)) 
                {
                    return;
                }
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        RowStatus _status = RowStatus.None;
        public RowStatus Status
        {
            get => _status;
            set
            {
                if (_status == value)
                {
                    return;
                }
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        int _rowIndex = 0;
        public int RowIndex
        {
            get => _rowIndex;
            protected set
            {
                if (_rowIndex == value)
                {
                    return;
                }
                _rowIndex = value;
                OnPropertyChanged(nameof(RowIndex));
            }
        }

        public TableRowState(TModel data)
        {
            _data = data;
        }
    }
}
