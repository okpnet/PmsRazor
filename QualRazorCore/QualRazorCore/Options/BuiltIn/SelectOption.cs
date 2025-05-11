using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.BuiltIn
{
    public class SelectOption<T> : FieldOption, IOption, INotifyPropertyChanged
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

        public SelectOption(string? placeHolder, Func<T, string> getOptionText, string chosePrompt) : base(placeHolder)
        {
            _getOptionText = getOptionText;
            _chosePrompt = chosePrompt;
        }
    }
}
