using QualRazorLib.Models.Core;
using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Trees;

namespace QualRazorLib.Models.Trees
{
    public class TreeViewModel<T> : ViewStateCore, ITreeViewModel<ITreeStructureDataProvider<T>>
    {
        public ITreeStructureDataProvider<ITreeStructureDataProvider<T>> Data => throw new NotImplementedException();

        public void AddChild(ITreeStructureDataProvider<T>? parent, ITreeStructureDataProvider<T> addChild)
        {
            throw new NotImplementedException();
        }

        public void AddNode(ITreeStructureDataProvider<T> node)
        {
            throw new NotImplementedException();
        }

        public void ChangeParent(ITreeStructureDataProvider<T>? parent, ITreeStructureDataProvider<T> chaild)
        {
            throw new NotImplementedException();
        }

        public override void ClearError()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(ITreeStructureDataProvider<T> node)
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
