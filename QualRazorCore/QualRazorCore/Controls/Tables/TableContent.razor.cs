using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables
{
    public partial class TableContent<TModel>:RazorCore where TModel : class
    {
        protected TableInformationContent _informationContent=default!;

        [Parameter,EditorRequired]
        public TableSchemaOption<TModel> Option { get; set; } = default!;

        IEnumerable<ITableColumn<TModel>> Columns=>Option.Columns.OfType<ITableColumn<TModel>>();

        int NumberOfColumn => Columns.Count();

        
    }
}
