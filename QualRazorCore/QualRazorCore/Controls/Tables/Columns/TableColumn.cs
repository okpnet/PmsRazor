using QualRazorCore.Containers;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Columns
{
    public class TableColumn : NotifyCore, ITableColumn
    {
        public Guid Key { get; } = Guid.NewGuid();

        protected Func<string> _getColumnNameInvoke = default!;
        public Func<string> GetColumnNameInvoke
        {
            get => _getColumnNameInvoke;
            set
            {
                _getColumnNameInvoke = value;
                OnPropertyChanged(nameof(GetColumnNameInvoke));
            }
        }

        protected TextArignType _textArignType;
        public TextArignType TextArign
        {
            get => _textArignType;
            set
            {
                if (_textArignType == value)
                {
                    return;
                }
                _textArignType = value;
                OnPropertyChanged(nameof(TextArign));
            }

        }
    }

    public class TableColumn<TModel> : TableColumn, ITableColumn<TModel>, ITableColumn
    {
        

        Func<TModel, string> _getPropertyValueInvoke = default!;
        public Func<TModel, string> GetPropertyValueInvoke
        {
            get => _getPropertyValueInvoke;
            set
            {
                _getPropertyValueInvoke = value;
                OnPropertyChanged(nameof(GetPropertyValueInvoke));
            }
        }


        public TableColumn(Func<TModel, string> getPropertyValueInvoke, Func<string> getColumnNameInvoke, Type valueType)
        {
            _getPropertyValueInvoke = getPropertyValueInvoke;
            _getColumnNameInvoke = getColumnNameInvoke;
            _textArignType = GetTextAlignType(valueType);
        }

        public TableColumn(Func<TModel, string> getPropertyValueInvoke, Func<string> getColumnNameInvoke, TextArignType textArignType)
        {
            _getPropertyValueInvoke = getPropertyValueInvoke;
            _getColumnNameInvoke = getColumnNameInvoke;
            _textArignType = textArignType;
        }


        TextArignType GetTextAlignType(Type valueType)
        {

            if (valueType == typeof(string))
            {
                return TextArignType.Left;
            }
            if (valueType == typeof(DateTime))
            {
                return TextArignType.Center;
            }
            return TextArignType.Right;
        }
    }
}
