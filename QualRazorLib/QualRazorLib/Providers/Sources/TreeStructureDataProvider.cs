using QualRazorLib.Core;
using QualRazorLib.Models.Trees;

namespace QualRazorLib.Providers.Sources
{
    /// <summary>
    /// 汎用のツリートップモデル
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeStructureDataProvider<T> : NotifyCore, ITreeStructureDataProvider<T>
    {
        private TreeNodeViewModel<T> _viewModel = new(default!);
        public ITreeNodeDataProvider<T> Root => _viewModel;

    }
}
