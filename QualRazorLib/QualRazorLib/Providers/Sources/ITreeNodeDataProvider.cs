using QualRazorLib.Views.States;
using System.Collections.ObjectModel;

namespace QualRazorLib.Providers.Sources
{
    /// <summary>
    /// ツリーノードの情報をビューに提供する
    /// </summary>
    public interface ITreeNodeDataProvider
    {

        bool HasParent { get; }

        int ChildrenCount { get; }

        int Level { get; }
    }
    /// <summary>
    /// ツリーノードの情報をビューに提供する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeNodeDataProvider<T> : ITreeNodeDataProvider, IDataProvider, ISelectedState, IStructureState<ITreeNodeDataProvider<T>>
    {
        T Value { get; }
        ObservableCollection<ITreeNodeDataProvider<T>> Children { get; }
    }
}
