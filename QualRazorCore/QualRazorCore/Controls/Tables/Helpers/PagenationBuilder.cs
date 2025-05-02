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
        /// <param name="option"></param>
        /// <param name="pageResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<PagenationArg> Build(TableInformationOption option, ITalkPageResult pageResult)
        {
            if (pageResult.NumberOfPage == 1)
            {
                yield break;
            }

            if (option.MaxPageCount >= pageResult.NumberOfPage)
            {
                for (int page = 1; page <= pageResult.NumberOfPage; page++)
                {
                    yield return new PagenationArg(
                        pageResult.PageNumber == page,
                        () => page.ToString(),
                        page
                    );
                }

                yield break;
            }

            int half = option.MaxPageCount / 2;
            int start, end;
            bool isPrev, isNext;

            if (pageResult.PageNumber <= half + 1)
            {
                start = 1;
                end = option.MaxPageCount;
                isPrev = false;
                isNext = true;
            }
            else if (pageResult.NumberOfPage - pageResult.PageNumber > half)
            {
                start = pageResult.PageNumber - half;
                end = start + option.MaxPageCount - 1;
                isPrev = true;
                isNext = true;
            }
            else
            {
                end = pageResult.NumberOfPage;
                start = end - option.MaxPageCount + 1;
                isPrev = true;
                isNext = false;
            }

            if (start > end)
            {
                throw new ArgumentException("start must be <= end");
            }

            yield return new PagenationArg(isPrev, option.PrevLabelInvoke, pageResult.PageNumber - 1);

            if (start > 1)
            {
                yield return new PagenationArg(false, () => "…", 0);
            }

            for (int page = start; page <= end; page++)
            {
                yield return new PagenationArg(
                    pageResult.PageNumber == page,
                    () => page.ToString(),
                    page
                );
            }

            if (end < pageResult.NumberOfPage)
            {
                yield return new PagenationArg(false, () => "…", 0);
            }

            yield return new PagenationArg(isNext, option.NextLabelInvoke, pageResult.PageNumber + 1);
        }
    }
}
