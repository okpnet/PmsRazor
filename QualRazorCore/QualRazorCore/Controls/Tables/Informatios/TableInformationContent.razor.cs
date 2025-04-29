using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkLib.Pages.Results.ResultItems;
using static System.Net.Mime.MediaTypeNames;

namespace QualRazorCore.Controls.Tables.Informatios
{
    public partial class TableInformationContent:RazorCore
    {
        [Parameter,EditorRequired]
        public TableInformationOption Option { get; set; } = default!;

        [Parameter,EditorRequired]
        public ITalkPageNumberResult PageNumberResult { get; set; } = default!;

        ITalkPageResult PageResult => (ITalkPageResult)PageNumberResult;

        public  PageInformationArg CreatePageInformationArg()
        {
            return new PageInformationArg(PageNumberResult.NumberOfRecords, PageNumberResult.NumberOfMatchedRecords, PageNumberResult.NumberOfPage, PageNumberResult.PageNumber);    
        }

        protected IEnumerable<PagenationArg> GetPagenation()=>Helpers.PaginationBuilder.Build(Option, PageResult);

        protected async IAsyncEnumerable<PagenationArg> GetPagenationAsync()
        {
            if (PageResult.NumberOfPage == 1)
            {
                yield break;
            }
            if (Option.MaxPageCount > PageResult.NumberOfPage)
            {//次と前のボタン無し
                //yield return new PagenationArg(PageResult.PageNumber > 1, Option.PrevLabelInvoke,1);
                for (var page = 1; PageResult.NumberOfPage >= page; page++)
                {
                    var currentPage = page;
                    yield return new PagenationArg(PageResult.PageNumber == currentPage, () => currentPage.ToString(), currentPage);
                }
                //yield return new PagenationArg(PageResult.NumberOfPage > PageResult.PageNumber, Option.NextLabelInvoke,PageNumberResult.NumberOfPage);
            }
            else
            {
                var _bothSideCount=Option.MaxPageCount / 2;
                var start = 1;
                var end = start + _bothSideCount * 2;
                var isPrev = false;
                var isNext = false;
                if (_bothSideCount + 1 >= PageResult.PageNumber)
                {
                    isPrev = false; isNext = true;
                    start = 1;
                }
                else if (PageResult.NumberOfPage - PageResult.PageNumber > _bothSideCount)
                {
                    isPrev = true; isNext = true;
                    start = PageResult.PageNumber - _bothSideCount;
                    end = start + _bothSideCount * 2;
                }
                else
                {
                    isPrev = true; isNext = false;
                    start = PageResult.NumberOfPage - _bothSideCount * 2 + 1;
                    end = PageResult.NumberOfPage;
                }

                if (start > end)
                {
                    throw new ArgumentException("end must be greater then start.");
                }

                yield return new PagenationArg(isPrev, Option.PrevLabelInvoke, start-1);

                if(start > 1)
                {
                    yield return new PagenationArg(true, ()=>"…", 0);
                }

                for (var page = start; end >= page; page++)
                {
                    var currentPage = page;
                    yield return new PagenationArg(true,() => currentPage.ToString(), currentPage);
                }

                if (PageResult.NumberOfPage > end)
                {
                    yield return new PagenationArg(true, () => "…", 0);
                }

                yield return new PagenationArg(isNext, Option.NextLabelInvoke, end+1);
            }
        }
    }
}
