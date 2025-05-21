using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Options;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables.Helpers
{
    /// <summary>
    /// テーブルインフォメーションのページネーションヘルパ
    /// </summary>
    public static class PaginationBuilder
    {
        /// <summary>
        /// テーブルインフォメーションのページネーションボタン情報を生成
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="pageResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<PagenationArg> Build(int numberOfPage, ITalkPageResult pageResult)
        {

            if (  pageResult.NumberOfPage == 1)
            {
                yield break;
            }

            if (numberOfPage >= pageResult.NumberOfPage)
            {
                for (int page = 1; page <= pageResult.NumberOfPage; page++)
                {
                    yield return new PagenationArg(
                        pageResult.PageNumber == page,
                        PagenationArg.PagenationButtonType.Number,
                        page,
                        ()=>page
                    );
                }

                yield break;
            }

            int half = numberOfPage / 2;
            int start, end;
            bool isPrev, isNext;

            if (pageResult.PageNumber <= half + 1)
            {
                start = 1;
                end = numberOfPage;
                isPrev = false;
                isNext = true;
            }
            else if (pageResult.NumberOfPage - pageResult.PageNumber > half)
            {
                start = pageResult.PageNumber - half;
                end = start + numberOfPage - 1;
                isPrev = true;
                isNext = true;
            }
            else
            {
                end = pageResult.NumberOfPage;
                start = end - numberOfPage + 1;
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
                ()=> pageResult.PageNumber - 1);

            yield return new PagenationArg
                (start > 1, 
                PagenationArg.PagenationButtonType.Between, 
                0,
                ()=>0);

            for (int page = start; page <= end; page++)
            {
                yield return new PagenationArg(
                    pageResult.PageNumber == page,
                    PagenationArg.PagenationButtonType.Number,
                    page,
                    ()=>page
                );
            }

            yield return new PagenationArg(
                end < pageResult.NumberOfPage,
                PagenationArg.PagenationButtonType.Between, 
                0,
                ()=>0);

            yield return new PagenationArg(
                isNext,
                PagenationArg.PagenationButtonType.Next,
                pageResult.PageNumber + 1,
                () => pageResult.PageNumber + 1);
        }
    }
}
