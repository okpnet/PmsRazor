using Microsoft.AspNetCore.Components;
using QualAnalyzer.Attributes;
using QualRazorLib.Controls.Tables.Argments;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Intterfaces;
using System.Reflection.Metadata;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorLib.Controls.Tables.Informations
{
    public class Information<TModel>: QualRazorComponentBase, ITableInformationContent where TModel : class
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter]
        public RenderFragment<PageInformationArg>? InformationContent { get; set; }

        [Parameter]
        public RenderFragment? PrevContent { get; set; }
        
        [Parameter]
        public RenderFragment? NextContent { get; set; }

        [CastCheck(typeof(ITableViewModel))]
        protected IViewModel<ITalkPageResult<TModel>> ViewModel => TableParent.TableViewModel;

        protected ITableViewModel TableViewModel => (ITableViewModel)ViewModel;

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
            if(TableParent.TableViewModel.Data is null)
            {
                return PageInformationArg.CreateFailArg();
            }
            return PageInformationArg.CreateSuccessArg(
                ViewModel.Data.NumberOfRecords,
                ViewModel.Data.NumberOfMatchedRecords,
                ViewModel.Data.NumberOfPage,
                ViewModel.Data.PageNumber);
        }
        /// <summary>
        /// ページネーションボタンの引数配列を生成
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<PagenationArg> GetPagenation() => ViewModel.Data is null ? [] : BuildPageButtonInformation(TableViewModel.MaxNumberOfPage, ViewModel.Data);

        public RenderFragment RenderInformation() => builder =>
        {
            var pageButtons= ViewModel.Data is null ? [] : BuildPageButtonInformation(, ViewModel.Data);
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
            foreach (var page in pageButtons)
            {
                builder.OpenComponent<PagenationButtonContent>(6);
                builder.AddAttribute(8, nameof(PagenationButtonContent.PagenationButton), page);
                builder.CloseComponent();
            }
            builder.CloseElement();
            builder.CloseElement();
            builder.CloseComponent();
        };

        /// <summary>
        /// テーブルインフォメーションのページネーションボタン情報を生成
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="pageResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected IEnumerable<PagenationArg> BuildPageButtonInformation(int maxNumberOfPage, ITalkPageResult pageResult)
        {

            if (pageResult.NumberOfPage == 1)
            {
                yield break;
            }

            if (maxNumberOfPage >= pageResult.NumberOfPage)
            {
                for (int page = 1; page <= pageResult.NumberOfPage; page++)
                {
                    yield return new PagenationArg(
                        pageResult.PageNumber == page,
                        PagenationArg.PagenationButtonType.Number,
                        page,
                        () => page
                    );
                }

                yield break;
            }

            int half = maxNumberOfPage / 2;
            int start, end;
            bool isPrev, isNext;

            if (pageResult.PageNumber <= half + 1)
            {
                start = 1;
                end = maxNumberOfPage;
                isPrev = false;
                isNext = true;
            }
            else if (pageResult.NumberOfPage - pageResult.PageNumber > half)
            {
                start = pageResult.PageNumber - half;
                end = start + maxNumberOfPage - 1;
                isPrev = true;
                isNext = true;
            }
            else
            {
                end = pageResult.NumberOfPage;
                start = end - maxNumberOfPage + 1;
                isPrev = true;
                isNext = false;
            }

            if (start > end)
            {
                throw new ArgumentException("start must be <= end");
            }

            yield return new PagenationArg(
                isPrev,
                PagenationArg.PagenationButtonType.Number,
                pageResult.PageNumber - 1,
                () => pageResult.PageNumber - 1);

            yield return new PagenationArg
                (start > 1,
                PagenationArg.PagenationButtonType.Between,
                0,
                () => 0);

            for (int page = start; page <= end; page++)
            {
                yield return new PagenationArg(
                    pageResult.PageNumber == page,
                    PagenationArg.PagenationButtonType.Number,
                    page,
                    () => page
                );
            }

            yield return new PagenationArg(
                end < pageResult.NumberOfPage,
                PagenationArg.PagenationButtonType.Between,
                0,
                () => 0);

            yield return new PagenationArg(
                isNext,
                PagenationArg.PagenationButtonType.Next,
                pageResult.PageNumber + 1,
                () => pageResult.PageNumber + 1);
        }
    }
}
