using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables
{
    /// <summary>
    /// ページネーションのラッパー
    /// </summary>
    public class Pagenations<TModel> : QualRazorComponentBase where TModel : class
    {
        [CascadingParameter(Name = CascadingParameterName.TableContentParent)]
        public QualTable<TModel> TableParent { get; set; } = default!;
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            TableParent.PageInforamation = ChildContent;
        }
    }
}
