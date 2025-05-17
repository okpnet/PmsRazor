using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Extensions;
using QualRazorCore.Controls.Tables.Helpers;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

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

        IEnumerable<PropertyAccessCore> Columns { get; set; }=new ObservableCollection<PropertyAccessCore>();

        protected int NumberOfColumn => Columns.Count();


        protected IEnumerable<TableRowState<TModel>> Source { get; set; } = [];

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                {
                    ["class"]=$"table is-fullwidth is-hoverable"
                }
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

        public class Columns:RazorCore
        {
            [CascadingParameter(Name = "TableContentParent")]
            public TableContent<TModel> TableParent { get; set; } = default!;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.AddContent(0, ChildContent);
            }
        }

        public class Column<TPorperty> : RazorCore
        {
            [CascadingParameter(Name = "TableContentParent")]
            public TableContent<TModel> TableParent { get; set; } = default!;
            [Parameter,EditorRequired]
            public Expression<Func<TModel, TPorperty>>? Property { get; set; }

            [Parameter]
            public RenderFragment? HeaderTemplate { get; set; }

            [Parameter]
            public Func<TModel, RenderFragment>? CellTemplate { get; set; }

            protected override void OnInitialized()
            {
                if (TableParent != null)
                {

                    TableParent.AddColumn(this);
                }
            }
        }
    }
}
