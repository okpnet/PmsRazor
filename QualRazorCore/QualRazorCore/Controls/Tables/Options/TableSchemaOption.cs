using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Rows;
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
                if (_pageResult == value)
                {
                    return;
                }
                _pageResult = value;
                OnPropertyChanged(nameof(PageResult));
            }
        }

        protected TableInformationOption _informationOption=default!;
        public TableInformationOption InformationOption
        {
            get => _informationOption;
            set
            {
                if (_informationOption == value)
                {
                    return;
                }
                _informationOption = value;
                OnPropertyChanged(nameof(InformationOption));
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
