using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Core;
using System.Collections.ObjectModel;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables.Options
{
    public class TableSchemaOption<TModel> : NotifyCore where TModel:class
    {
        ObservableCollection<ITableColumn> _columns = new();
        public ObservableCollection<ITableColumn> Columns => _columns;

        protected ITalkPageResult<TModel> _pageResult = default!;
        public ITalkPageResult<TModel> PageResult
        {
            get => _pageResult;
            set
            {
                if (Equals(_pageResult , value))
                {
                    return;
                }
                _pageResult = value;
                OnPropertyChanged(nameof(PageResult));
            }
        }

        protected TableInformationOption _informationOption=new();
        public TableInformationOption InformationOption
        {
            get => _informationOption;
            set
            {
                if (Equals(_informationOption , value))
                {
                    return;
                }
                _informationOption = value;
                OnPropertyChanged(nameof(InformationOption));
            }
        }

        protected TableColumnOption _columnOption = new();

        public TableColumnOption ColumnOption
        {
            get => _columnOption;
            set
            {
                if(Equals( _columnOption,value))
                {
                    return;
                }
                _columnOption = value;
                OnPropertyChanged(nameof(ColumnOption));
            }
        }

        protected TableRowOption _rowOption = new();
        public TableRowOption RowOption
        {
            get => _rowOption;
            set
            {
                if( Equals(_rowOption,value))
                {
                    return;
                }
                _rowOption = value;
                OnPropertyChanged(nameof(RowOption));
            }
        }

        protected TableCellOption _cellOption = new();
        public TableCellOption CellOption
        {
            get => _cellOption;
            set
            {
                if (Equals(_cellOption, value))
                {
                    return;
                }
                _cellOption = value;
                OnPropertyChanged(nameof(CellOption));
            }
        }

        protected Dictionary<string, object> _tableAdditionalAttributes=new();
        public Dictionary<string, object> TableAdditionalAttributes 
        {
            get => _tableAdditionalAttributes;
            set
            {
                if (_tableAdditionalAttributes == value)
                {
                    return;
                }
                _tableAdditionalAttributes = value;
                OnPropertyChanged(nameof(TableAdditionalAttributes));
            }
        }
    }
}
