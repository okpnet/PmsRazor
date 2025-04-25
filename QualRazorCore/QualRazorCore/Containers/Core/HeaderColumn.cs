using QualRazorCore.Core;
using System.Runtime.CompilerServices;

namespace QualRazorCore.Containers.Core
{
    public class HeaderColumn<TModel> :NotifyCore, IHeaderColumn<TModel>, IHeaderColumn
    {
        Guid _key=Guid.NewGuid();

        public Guid Key => _key;

        Func<TModel, string> _getPropertyValueInvoke=default!;
        public Func<TModel, string> GetPropertyValueInvoke
        {
            get => _getPropertyValueInvoke;
            set
            {
                _getPropertyValueInvoke = value;
                OnPropertyChanged(nameof(GetPropertyValueInvoke));
            }
        }

        Func<string> _getColumnNameInvoke = default!;
        public Func<string> GetColumnNameInvoke
        {
            get => _getColumnNameInvoke;
            set
            {
                _getColumnNameInvoke = value;
                OnPropertyChanged(nameof(GetColumnNameInvoke));
            }
        }

        TextArignType _textArignType;
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

        public HeaderColumn(Func<TModel, string> getPropertyValueInvoke, Func<string> getColumnNameInvoke,Type valueType)
        {
            _getPropertyValueInvoke = getPropertyValueInvoke;
            _getColumnNameInvoke = getColumnNameInvoke;
            _textArignType = GetTextAlignType(valueType);
        }

        public HeaderColumn(Func<TModel, string> getPropertyValueInvoke, Func<string> getColumnNameInvoke,TextArignType textArignType)
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
