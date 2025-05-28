using QualRazorLib.Core;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.States;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QualRazorLib.Models.Trees
{
    public class TreeNodeViewModel<T> : NotifyCore, ITreeNodeDataProvider<T>, ITreeNodeDataProvider, INotifyPropertyChanged, ITreeNodeState
    {
        protected bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if(_isSelected == value)
                {
                    return;
                }
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));  
            }
        }

        protected T _value=default!;
        public T Value 
        {
            get => _value;
            protected set
            {
                if(Equals(value, _value)) 
                {
                    return;
                }
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }


        protected ITreeNodeDataProvider<T>? _parent;

        public ITreeNodeDataProvider<T>? Parent
        {
            get => _parent;
            set
            {
                if(Equals(_parent, value))
                {
                    return;
                }
                _parent = value;
                OnPropertyChanged(nameof(Parent));
            }
        }

        protected ObservableCollection<ITreeNodeDataProvider<T>> _children = [];
        public ObservableCollection<ITreeNodeDataProvider<T>> Children
        {
            get => _children;
            set
            {
                if(Equals(_children, value))
                {
                    return;
                }
                _children = value;
                OnPropertyChanged(nameof(Children));
            }
        }


        public bool HasParent => _parent is not null;

        protected int _childrenCount;
        public int ChildrenCount
        {
            get => _childrenCount;
            set
            {
                if(_childrenCount == value)
                {
                    return;
                }
                _childrenCount = value;
                OnPropertyChanged(nameof(ChildrenCount));
            }
        }

        protected int _level;
        public int Level
        {
            get => _level;
            set
            {
                if(_level== value)
                {
                    return;
                }
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        protected bool _isExpanded;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if(_isExpanded == value)
                {
                    return;
                }
                _isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }

        protected bool _isHidden;
        public bool IsHidden
        {
            get => _isHidden;
            set
            {
                if(_isHidden == value)
                {
                    return;
                }
                _isHidden = value;
                OnPropertyChanged(nameof(IsHidden));
            }
        }

        public TreeNodeViewModel(T value)
        {
            _value = value;
        }

        public void SetParent(ITreeNodeDataProvider<T>? newParent)=> Parent = newParent;
    }
}
