using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables
{
    public class Information<TModel>:RazorCore,ITableInformationContent where TModel : class
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
                Option.ContainerAdditionalAttributes,
                new([
                    new("class","is-flex-deskto is-justify-content-space-between is-align-items-center is-flex-wrap-wrap")
                    ])
                );

        /// <summary>
        /// ページボタングループの属性
        /// </summary>
        protected Dictionary<string, object> MergeButtonGroupAttribute =>
            HtmlAttributeHelper.PurgeAttributes(Option.ButtonGroupAdditionalAttributes,
                new([
                    new("class",ClassDefine.Table.PAGE_BUTTON_GROUP)
                    ])
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
        protected IEnumerable<PagenationArg> GetPagenation() => TableParent.Source is null ? [] : Helpers.PaginationBuilder.Build(Parameter, TableParent.Source);

        public RenderFragment RenderInformation() => builder =>
        {
            builder.OpenComponent<CascadingValue<ITableInformationContent>>(0);
            builder.AddAttribute(1, nameof(PagenationButtonContent.ParentTableInformation), this);
            builder.OpenElement(2, "div");
            builder.AddMultipleAttributes(1, MeargeAttribute);
            builder.OpenElement(3, "div");
            builder.AddAttribute(4, "class", ClassDefine.Table.INFORMATION);
            builder.AddContent(5, InformationContent, CreatePageInformationArg());
            builder.CloseElement();
            builder.OpenElement(6, "div");
            builder.AddAttribute(7, "class", ClassDefine.Table.PAGE_BUTTON_GROUP);
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
