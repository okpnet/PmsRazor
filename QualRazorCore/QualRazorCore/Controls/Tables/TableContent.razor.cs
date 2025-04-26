using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Columns;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QualRazorCore.Controls.Tables
{
    public partial class TableContent<TModel>:RazorCore
    {
        [Parameter,EditorRequired]
        public TableSchemaOption<TModel> Option { get; set; } = default!;

        protected IEnumerable<TableColumn<TModel>> Columns =>Option.Columns.OfType<TableColumn<TModel>>();

        protected IEnumerable<PagenationArg> GetPagenation()
        {
            if (Option.NumberOfPage==1)
            {
                yield break;
            }
            if (_maxCount > Option.NumberOfPage)
            {//次と前のボタン無し
                yield return new PagenationArg(Option.CurrentPageNumber > 1, Option.PrevLabel);
                for (var page = 1; Option.NumberOfPage >= page; page++)
                {
                    yield return new PagenationArg(Option.CurrentPageNumber==page, ()=>page.ToString());
                }
                yield return new PagenationArg(Option.NumberOfPage > Option.CurrentPageNumber, Option.NextLabel);
            }
            else
            {
                var start = 1;
                var end = start + _bothSideCount * 2;

                if (_bothSideCount + 1 >= pageResult.PageNumber)
                {//
                    Prev = false; Next = true;
                    start = 1;
                }
                else if (pageResult.NumberOfPage - pageResult.PageNumber > _bothSideCount)
                {
                    Prev = true; Next = true;
                    start = pageResult.PageNumber - _bothSideCount;
                    end = start + _bothSideCount * 2;
                }
                else
                {
                    Prev = true; Next = false;
                    start = pageResult.NumberOfPage - _bothSideCount * 2 + 1;
                    end = pageResult.NumberOfPage;
                }

                for (var page = start; end >= page; page++)
                {
                    PageNumbers.Add(page, page == pageResult.PageNumber);
                }
            }
        }
    }
}
