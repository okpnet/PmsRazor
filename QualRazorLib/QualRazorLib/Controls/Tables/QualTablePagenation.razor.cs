using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables
{
    /// <summary>
    /// ページネーションのラッパー
    /// </summary>
    public class QualTablePagenation<TModel> : QualRazorComponentBase where TModel : class
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            TableParent.PageInforamation = ChildContent;
        }
    }
}
}
