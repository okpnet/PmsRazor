using QualRazorLib.Core;
using QualRazorLib.Helpers;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Tables.Columns.Dtos
{
    public class ColumnState<TModel,TProperty> :PropertyAccessCore<TModel,TProperty>,INotifyPropertyChanged, IColumnState<TModel,TProperty>, IColumnState
    {
        protected string? _formatString;
        public string? FormatString 
        {
            get => _formatString;
            set
            {
                if (_formatString == value)
                {
                    return;
                }
                _formatString = value;
                OnPropertyChanged(nameof(FormatString));
            }
        }

        protected TextAlignType _textAlign;
        public TextAlignType TextAlign 
        {
            get => _textAlign;
            set
            {
                if (_textAlign == value)
                {
                    return;
                }
                _textAlign = value;
                OnPropertyChanged(nameof(TextAlign));
            }
        }

        protected SortType _sortType = SortType.None;
        public SortType SortStatus 
        {
            get => _sortType;
            set
            {
                if (_sortType == value)
                {
                    return;
                }
                _sortType = value;
                OnPropertyChanged(nameof(SortStatus));
            }
        }

        public ColumnState(Expression<Func<TModel, TProperty>> propertyExpression) : base( propertyExpression)
        {
        }

        public string? GetStringFromValue<T>(T value)
        {
            if(value is not TModel model)
            {
                throw new InvalidOperationException();
            }
            if (Getter.Invoke(model).IfDeclare(out var result) is not null)
            {
                return result!.ToString();
            }
            return null;
        }
    }
}
