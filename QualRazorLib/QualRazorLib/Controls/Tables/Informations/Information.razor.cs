using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Argments;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using System.Reflection.Metadata;

namespace QualRazorLib.Controls.Tables.Informations
{
    public class Information<TModel>: QualRazorComponentBase, ITableInformationContent where TModel : class
    {
        [CascadingParameter(Name = "TableContentParent")]
        public TableContent<TModel> TableParent { get; set; } = default!;

        [Parameter]
        public RenderFragment<PageInformationArg>? InformationContent { get; set; }

        [Parameter]
        public RenderFragment? PrevContent { get; set; }
        
        [Parameter]
        public RenderFragment? NextContent { get; set; }

        [Parameter]
        public InformationParameter Parameter { get; set; } = default!;


        /// <summary>
        /// インフォメーションDIVの属性
        /// </summary>
        protected Dictionary<string, object> MeargeAttribute =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = CssClasses.Table.INFORMATION
                }
                );

        /// <summary>
        /// テーブルインフォメーション引数を生成
        /// </summary>
        /// <returns></returns>
        public PageInformationArg CreatePageInformationArg()
        {
            if(TableParent.Source is null)
            {
                return PageInformationArg.CreateFailArg();
            }
            return PageInformationArg.CreateSuccessArg(
                TableParent.Source.NumberOfRecords, 
                TableParent.Source.NumberOfMatchedRecords, 
                TableParent.Source.NumberOfPage, 
                TableParent.Source.PageNumber);
        }
        /// <summary>
        /// ページネーションボタンの引数配列を生成
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<PagenationArg> GetPagenation() => TableParent.Source is null ? [] : Helpers.PaginationBuilder.Build(Parameter.MaxNumberOfPage, TableParent.Source);

        public RenderFragment RenderInformation() => builder =>
        {
            builder.OpenComponent<CascadingValue<ITableInformationContent>>(0);
            builder.AddAttribute(1, nameof(PagenationButtonContent.ParentTableInformation), this);
            builder.OpenElement(2, "div");
            builder.AddMultipleAttributes(1, MeargeAttribute);
            builder.OpenElement(3, "div");
            builder.AddAttribute(4, "class", $"{CssClasses.MARGIN_ALL} {CssClasses.TEXT_GREY}");
            builder.AddContent(5, InformationContent, CreatePageInformationArg());
            builder.CloseElement();
            builder.OpenElement(6, "div");
            builder.AddAttribute(7, "class", CssClasses.Table.PAGE_BUTTON_GROUP);
            foreach (var page in GetPagenation())
            {
                builder.OpenComponent<PagenationButtonContent>(6);
                builder.AddAttribute(8, nameof(PagenationButtonContent.PagenationButton), page);
                builder.CloseComponent();
            }
            builder.CloseElement();
            builder.CloseElement();
            builder.CloseComponent();
        };
    }
}
