using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Models.Trees;
using QualRazorLib.Observer;
using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Controls.Trees.Nodes
{
    public partial class TreeNode<T>:QualRazorComponentBase
    {
        const decimal INNDENT = 1.2M;

        [CascadingParameter(Name =$"{QualTree<T>.CASCADE_PARAM}")]
        public QualTree<T>? Parent { get; set; }

        [Parameter]
        public RenderFragment<TreeNodeArg<T>>? NodeTemplate { get; set; }

        [Parameter]
        public ITreeNodeDataProvider<T> TreeDataProvider { get; set; } = default!;

        protected TreeNodeViewModel<T> Model => (TreeNodeViewModel<T>)TreeDataProvider;

        protected bool IsSelected { get; set; }

        protected bool IsExpanded { get; set; }

        protected bool HssChild { get; set; }

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                {
                    [HtmlAtributes.STYLE]=$"{Indent()}",
                    [HtmlAtributes.CLASS]=$"{(Model.ChildrenCount>0? "icon-text":"")}",
                }
                );

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //プログラマブル展開変更をビューに反映
            PropertyChangedRelay<TreeNodeViewModel<T>, bool>.Create(
                    Model,
                    nameof(TreeNodeViewModel<T>.IsExpanded),
                    t => t.IsExpanded,
                    t => IsExpanded = t);

            //プログラマブル選択変更をビューに反映
            PropertyChangedRelay<TreeNodeViewModel<T>, bool>.Create(
                    Model,
                    nameof(TreeNodeViewModel<T>.IsSelected),
                    t => t.IsSelected,
                    t => IsSelected = t);

            //プログラマブル選択変更をビューに反映
            PropertyChangedRelay<TreeNodeViewModel<T>, bool>.Create(
                    Model,
                    nameof(TreeNodeViewModel<T>.IsHidden),
                    t => t.IsHidden,
                    t => IsHidden=t);
        }

        protected string Indent()
        {
            var result = INNDENT * Model.Level + ( Model.ChildrenCount == 0 ? INNDENT : 0 );
            return $"margin-left:{(result.ToString("{0:#.#}"))}rem";
        }


        protected IEnumerable<ITreeNodeDataProvider<T>> Parents(ITreeNodeDataProvider<T>? node)
        {
            if(node is null)
            {
                yield break;
            }
            yield return node;
            var array = Parents(node.Parent);
            foreach (var item in array)
            {
                yield return item;
            }
        }

        protected TreeNodeArg<T> Create() => new(Model.Value, IsSelected, Model.Level);
    }
}
