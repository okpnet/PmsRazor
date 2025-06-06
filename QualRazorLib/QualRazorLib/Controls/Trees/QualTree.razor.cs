using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Controls.Trees
{
    public partial class QualTree<T>:QualRazorComponentBase
    {
        public const string CASCADE_PARAM = $"{nameof(QualTree<T>)}.Parent";

        [Parameter]
        public ITreeViewModel<T> TreeViewModels { get; set; } = default!;



        protected RenderFragment<TreeNodeArg<T>>? NodeRenderFlagment { get; set; }
        
        protected Dictionary<string, object> MergedAttributes =>
                    HtmlAttributeHelper.PurgeAttributes(
                        MergeAttributeBase,
                        new()
                        );

        public class NodeTemplate: QualRazorComponentBase
        {
            [CascadingParameter(Name = CASCADE_PARAM)]
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
