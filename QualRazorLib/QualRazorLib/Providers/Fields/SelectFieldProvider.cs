using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class SelectFieldProvider<T> : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
    {
        ObservableCollection<T> _collection = new();
        public IEnumerable<T> Source
        {
            get => _collection;
            set
            {
                _collection.Clear();
                foreach (var item in value)
                {
                    _collection.Add(item);
                }
            }
        }
        Func<T, string> _getOptionText = default!;
        public Func<T, string> GetOptionText
        {
            get => _getOptionText;
            set
            {
                if (_getOptionText == value)
                {
                    return;
                }
                _getOptionText = value;
                OnPropertyChanged(nameof(GetOptionText));
            }
        }

        string _chosePrompt = string.Empty;
        public string ChoosePrompt
        {
            get => _chosePrompt;
            set
            {
                if (value == _chosePrompt)
                {
                    return;
                }
                _chosePrompt = value;
                OnPropertyChanged(nameof(ChoosePrompt));
            }
        }
    }
}
