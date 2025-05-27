using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Core;
using QualRazorLib.Models.Trees;
using QualRazorLib.Providers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Trees.Nodes
{
    public partial class TreeNode<T>:QualRazorComponentBase
    {
        [CascadingParameter]
        public 

        [Parameter]
        public RenderFragment<TreeNodeArg<T>>? NodeTemplate { get; set; }

        [Parameter]
        public ITreeNodeDataProvider<T> TreeDataProvider { get; set; } = default!;

        protected TreeNodeModel<T> Model => (TreeNodeModel<T>)TreeDataProvider;

        protected int Level => Parents(TreeDataProvider).Count();

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
    }
}
