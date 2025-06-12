using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables
{
    /// <summary>
    /// 列群のラッパー
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class Columns<TModel> : QualRazorComponentBase where TModel : class
    {
        [CascadingParameter(Name = CascadingParameterName.TableContentParent)]
        public QualTable<TModel> TableParent { get; set; } = default!;
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, ChildContent);
        }
    }
}
