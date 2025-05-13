using QualRazorCore.Controls.Filters;
using QualRazorCore.Core;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables.Columns.Core
{
    public class TableColumn<TModel,TResult> : PropertyAccessCore<TModel,TResult>, ITableColumn<TModel>, ITableColumn, IOrderChange,INotifyPropertyChanged
    {
        protected SortType _sortStaetus = SortType.None;
        public SortType SortStatus
        {
            get => _sortStaetus;
            set
            {
                if (_sortStaetus == value)
                {
                    return;
                }
                _sortStaetus = value;
                OnPropertyChanged(nameof(SortStatus));
            }
        }

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

        public Func<TModel, string> GetPropertyValueStringInvoke => (t) => Getter?.Invoke(t)?.ToString()??Key.ToString();

        public string ColumnName => _propertyName;

        public TableColumn(
            Expression<Func<string>> getColumnNameInvoke,
            string propertyName,
            Expression<Func<TModel, TResult>> propertyExpression) : base(propertyName, propertyExpression)
        {
            _getColumnNameInvoke = getColumnNameInvoke.Compile();
            _textArignType = GetTextAlignType(typeof(TResult));
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

        public void OrderChange(SortType changeSortType)
        {
            SortStatus = changeSortType;
        }
    }
}
