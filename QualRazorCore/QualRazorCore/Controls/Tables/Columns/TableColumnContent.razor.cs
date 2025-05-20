using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Filters;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Parameters;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Tables.Columns
{
    public partial class TableColumnContent:RazorCore
    {
        [Parameter, EditorRequired]
        public IColumnParamter Paramter { get; set; } = default!;

        public SortType SortStatus { get; set; }

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new([
                    new("onclick",(Action<MouseEventArgs>)((e)=>OnMouseClick(e)))//クリックイベント
                    ])
                );

        async void OnMouseClick(MouseEventArgs e)
        {
           var changeOrderType= Column.SortStatus switch
            {
                    SortType.None => SortType.ASC,
                    SortType.ASC=>SortType.DESC,
                    SortType.DESC=>SortType.None,
                    _=>SortType.None,
                };
            ((IOrderChange)Column).OrderChange(changeOrderType);
            StateHasChanged();
            await Option.ColumnClick.InvokeAsync(Column);
        }
    }
}
