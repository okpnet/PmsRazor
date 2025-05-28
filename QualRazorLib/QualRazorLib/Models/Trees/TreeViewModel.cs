using QualRazorLib.Helpers;
using QualRazorLib.Models.Core;
using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Models.Trees
{
    public abstract class TreeViewModel<T> : ViewStateCore, ITreeViewModel<T>
    {
        protected TreeStructureDataProvider<T> _treeStructureDataProvider=new();

        public ITreeStructureDataProvider<T> Data => _treeStructureDataProvider;

        protected TreeNodeViewModel<T> _root => (TreeNodeViewModel<T>)_treeStructureDataProvider.Root;

        protected abstract void AssignParent(T child,T? parent);

        public void AddChild(T? parent, T addChild)
        {
            AssignParent(addChild, parent);
            var addModel = new TreeNodeViewModel<T>(addChild);
            if (parent is null)
            {
                _root.Children.Add(addModel);
                return;
            }
            var findParent = parent is null ? 
                _root : TreeStructureHelper.FilndNodeItem(new TreeNodeViewModel<T>(parent), _root.Children, (t) => t.Children, (a, b) => ReferenceEquals(a.Value, b.Value));
            findParent?.Children.Add(addModel);
        }

        public void AddNode(T node)
        {
            AddChild(default, node);
        }

        public void ChangeParent(T? parent, T chaild)
        {
            AssignParent(chaild, parent);
            var findParent = parent is null ?
                _root : TreeStructureHelper.FilndNodeItem(new TreeNodeViewModel<T>(parent), _root.Children, (t) => t.Children, (a, b) => ReferenceEquals(a.Value, b.Value));
            var findChild= TreeStructureHelper.FilndNodeItem(new TreeNodeViewModel<T>(chaild), _root.Children, (t) => t.Children, (a, b) => ReferenceEquals(a.Value, b.Value));
            if(findChild is null)
            {
                return;
            }
            findChild.Parent?.Children.Remove(findChild);
            findChild.SetParent(findParent);
        }

        public override void ClearError()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(T node)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public override void SetError(string message)
        {
            throw new NotImplementedException();
        }

        public override void SetLoading(bool isLoading)
        {
            throw new NotImplementedException();
        }

        public Task SubmitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
