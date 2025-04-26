using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Rows
{
    public abstract class TableRowState : NotifyCore, ITableRowState
    {
        public abstract object BaseModel { get; }
        public Guid Key { get; } = Guid.NewGuid();

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
    }

    public class TableRowState<TModel> : TableRowState, ITableRowState<TModel>, ITableRowState
    {

        TModel _model;
        public TModel Model
        {
            get => _model;
            set
            {
                if (Equals(value, _model))
                {
                    return;
                }
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public override object BaseModel => _model;
    }
}
