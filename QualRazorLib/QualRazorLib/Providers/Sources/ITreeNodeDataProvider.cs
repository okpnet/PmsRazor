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
    }
    /// <summary>
    /// ツリーノードの情報をビューに提供する
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface ITreeNodeDataProvider<TModel> : ITreeNodeDataProvider, IDataProvider, ISelectedState
    {
        TModel Value { get; }
        ITreeNodeDataProvider<TModel>? Parent { get; }
        ObservableCollection<ITreeNodeDataProvider<TModel>> Children { get; }
    }
}
