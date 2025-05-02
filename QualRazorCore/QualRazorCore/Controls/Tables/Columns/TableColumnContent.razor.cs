using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.Metadata;
using QualRazorCore.Controls.Filters;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using System;

namespace QualRazorCore.Controls.Tables.Columns
{
    public partial class TableColumnContent:RazorCore
    {
        [Parameter, EditorRequired]
        public ITableColumn Column { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableColumnOption Option { get; set; } = default!;

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.ColumnAdditionalAttributes,
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
