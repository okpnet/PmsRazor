using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Tables.Cells
{
    public partial class Cell<TModel>: QualRazorComponentBase where TModel : class
    {
        [Parameter,EditorRequired]
        public IColumnState ColumnState { get; set; } = default!;

        [Parameter, EditorRequired]
        public TModel Model { get; set; } = default!;


        protected string? Value { get; set; }

        protected Dictionary<string, object> MergedAttributes =>
                HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS]=""
                }
            );



        protected override void OnInitialized()
        {
            base.OnInitialized();
            Value=ColumnState.GetStringFromValue( Model );
        }


        protected string GetClassName()
        {
            var className = ColumnState.TextAlign switch
            {
                TextAlignType.Left => CssClasses.TEXT_LEFT,
                TextAlignType.Center => CssClasses.TEXT_CENTER,
                TextAlignType.Right => CssClasses.TEXT_RIGHT,
                _ => string.Empty,
            };
            return className;
        }
    }
}
