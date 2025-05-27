using QualRazorLib.Core;
using QualRazorLib.Providers.Sources;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QualRazorLib.Models.Trees
{
    public class TreeNodeModel<TModel> : NotifyCore, ITreeNodeDataProvider<TModel>, ITreeNodeDataProvider, INotifyPropertyChanged
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

        protected TModel _value=default!;
        public TModel Value 
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


        protected ITreeNodeDataProvider<TModel>? _parent;

        public ITreeNodeDataProvider<TModel>? Parent
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

        protected ObservableCollection<ITreeNodeDataProvider<TModel>> _children = [];
        public ObservableCollection<ITreeNodeDataProvider<TModel>> Children
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

        public TreeNodeModel(TModel value)
        {
            _value = value;
        }
    }
}
