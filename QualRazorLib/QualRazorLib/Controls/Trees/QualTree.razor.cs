using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Core;
using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Controls.Trees
{
    public partial class QualTree<T>:QualRazorComponentBase
    {
        public const string _casdcadingParameterName = $"{nameof(QualTree<T>)}Parent";

        [Parameter]
        public ITreeViewModel<T> TreeViewModels { get; set; } = default!;

        protected RenderFragment<TreeNodeArg<T>>? NodeRenderFlagment { get; set; }

        public class NodeTemplate: QualRazorComponentBase
        {
            [CascadingParameter(Name =_casdcadingParameterName)]
            public QualTree<T> Parent { get; set; } = default!;

            [Parameter]
            public RenderFragment<TreeNodeArg<T>>? ChildContent { get; set; }

            protected override void OnInitialized()
            {
                base.OnInitialized();
                Parent.NodeRenderFlagment = ChildContent;
            }
        }
    }
}
