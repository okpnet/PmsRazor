using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Extensions;
using QualRazorCore.Controls.Tables.Helpers;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;

namespace QualRazorCore.Controls.Tables
{
    public partial class TableContent<TModel>:RazorCore where TModel : class
    {
        /// <summary>
        /// エレメント参照
        /// </summary>
        protected TableInformationContent _informationContent=default!;

        [Parameter,EditorRequired]
        public TableSchemaOption<TModel> Option { get; set; } = default!;

        IEnumerable<ITableColumn<TModel>> Columns=>Option.Columns.OfType<ITableColumn<TModel>>();

        protected int NumberOfColumn => Columns.Count();


        protected IEnumerable<TableRowState<TModel>> Source { get; set; } = [];

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.TableAdditionalAttributes, 
                new([
                    new("class",ClassDefine.Table.STYLE)
                    ])
                );

        protected override void OnInitialized()
        {
            disposables.Add(
                PropertyChangedRelay<TableSchemaOption<TModel>, IEnumerable<TableRowState<TModel>>>.Create
                (
                    Option,
                    nameof(Option.PageResult),
                    src => Option.GenerateSource(),
                    sources => Source=sources
                    )
                );
        }
    }
}
