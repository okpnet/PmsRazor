using QualRazorLib.Models.Trees;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.States;

namespace QualRazorLib.Presentation.Facades
{
    public interface ITreeViewModel<T>: IViewModel<ITreeStructureDataProvider<T>>, ITreeViewParamter, IViewState
    {
        void AddNode(T node);

        void RemoveNode(T node);

        void ChangeParent(T? parent, T chaild);

        void AddChild(T? parent, T addChild);
    }
}
