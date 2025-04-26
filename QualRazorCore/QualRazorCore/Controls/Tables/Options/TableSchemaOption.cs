using QualRazorCore.Controls.Tables.Columns;
using QualRazorCore.Controls.Tables.Rows;
using QualRazorCore.Core;
using System.Collections.ObjectModel;

namespace QualRazorCore.Controls.Tables.Options
{
    public class TableSchemaOption<TModel> : NotifyCore
    {
        ObservableCollection<ITableColumn> _columns = new();
        public ObservableCollection<ITableColumn> Columns => _columns;

        protected IEnumerable<TableRowState<TModel>> _source = [];
        public IEnumerable<TableRowState<TModel>> Source
        {
            get => _source;
            protected set
            {
                if (_source == value)
                {
                    return;
                }
                _source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        protected TableRowState<TModel>? _editRowState;

        protected TModel? _editingModel;
        public TModel? EditingModel
        {
            get => _editingModel;
            protected set
            {
                if (Equals(_editingModel, value))
                {
                    return;
                }
                _editingModel = value;
                OnPropertyChanged(nameof(EditingModel));
            }
        }

        protected int _currentPageNumber;
        public int CurrentPageNumber
        {
            get => _currentPageNumber;
            set
            {
                if (_currentPageNumber == value)
                {
                    return;
                }
                _currentPageNumber = value; 
                OnPropertyChanged(nameof(CurrentPageNumber));
            }
        }

        protected int _numberOfPage;
        public int NumberOfPage
        {
            get => _numberOfPage;
            set
            {
                if (_numberOfPage == value)
                {
                    return;
                }
                _numberOfPage = value;
                OnPropertyChanged(nameof(NumberOfPage));
            }
        }

        public int _numberOfRecods;
        public int NumberOfRecords
        {
            get => _numberOfRecods;
            set
            {
                if (_numberOfRecods == value)
                {
                    return;
                }
                _numberOfRecods = value;
                OnPropertyChanged(nameof(NumberOfRecords));
            }
        }

        protected int _numberOfFilteredRecords;
        public int NumberOfFilteredRecords
        {
            get => _numberOfFilteredRecords;
            set
            {
                if(_numberOfFilteredRecords == value)
                {
                    return;
                }
                _numberOfFilteredRecords = value;
                OnPropertyChanged(nameof(NumberOfFilteredRecords));
            }
        }

        public Func<string> PrevLabel { get; set; } = () => "*Prev*";

        public Func<string> NextLabel { get; set; } = () => "*Next*";
    }
}
