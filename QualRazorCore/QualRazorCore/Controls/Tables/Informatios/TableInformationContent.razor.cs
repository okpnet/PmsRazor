using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables.Informatios
{
    public partial class TableInformationContent:RazorCore
    {
        [Parameter,EditorRequired]
        public TableInformationOption Option { get; set; } = default!;

        [Parameter,EditorRequired]
        public ITalkPageNumberResult PageNumberResult { get; set; } = default!;

        protected ITalkPageResult PageResult => (ITalkPageResult)PageNumberResult;

        /// <summary>
        /// インフォメーションDIVの属性
        /// </summary>
        protected Dictionary<string, object> MeargeContainerAttribute =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.ContainerAdditionalAttributes,
                new([
                    new("class",ClassDefine.Table.INFORMATION)
                    ])
                );
        /// <summary>
        /// テーブルインフォメーションメッセージの属性
        /// </summary>
        protected Dictionary<string, object> MergeInformationAttribute =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.InformationAdditionalAttributes,
                new([
                    new("class",$"{ClassDefine.MARGIN_ALL} {ClassDefine.TEXT_GREY}")
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
        /// ページネーションボタンの属性取得
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Dictionary<string, object> GetMergeButtonAttribute(PagenationArg page)
        {
            return page.Active ?
                HtmlAttributeHelper.PurgeAttributes(
                    Option.ActiveButtonAdditionalAttributes,
                    new([
                        new("class",ClassDefine.Table.PAGE_CURRENT_BUTTON),
                        new("onclick",EventCallback.Factory.Create(this,()=>Option.PageMoveInvoke.InvokeAsync(page.CurrentPageNumber)))
                        ])) :
                HtmlAttributeHelper.PurgeAttributes(
                    Option.ActiveButtonAdditionalAttributes,
                    new([
                        new("class",ClassDefine.Table.PAGE_BUTTON),
                        new("onclick",EventCallback.Factory.Create(this,()=>Option.PageMoveInvoke.InvokeAsync(page.CurrentPageNumber)))
                        ]));
        }

        /// <summary>
        /// テーブルインフォメーション引数を生成
        /// </summary>
        /// <returns></returns>
        public PageInformationArg CreatePageInformationArg()
        {
            return new PageInformationArg(PageNumberResult.NumberOfRecords, PageNumberResult.NumberOfMatchedRecords, PageNumberResult.NumberOfPage, PageNumberResult.PageNumber);    
        }
        /// <summary>
        /// ページネーションボタンの引数配列を生成
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<PagenationArg> GetPagenation()=>Helpers.PaginationBuilder.Build(Option, PageResult);
    }
}
