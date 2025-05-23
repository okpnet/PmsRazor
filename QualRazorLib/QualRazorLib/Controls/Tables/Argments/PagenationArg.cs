using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables.Argments
{
    /// <summary>
    /// テーブルに表示されるページネーションのリンクアイテム
    /// </summary>
    public class PagenationArg
    {
        public bool Active { get; }

        public PagenationButtonType ButtonType { get; }

        public int CurrentPageNumber { get; } = 1;

        public Func<int> ChagePage { get; }

        public PagenationArg(bool active, PagenationButtonType buttonType, int currentPageNumber, Func<int> chagePage)
        {
            Active = active;
            ButtonType = buttonType;
            CurrentPageNumber = currentPageNumber;
            ChagePage = chagePage;
        }

        [Flags]
        public enum PagenationButtonType
        {
            None = 0,
            Number = 1 << 1,
            Prev = 1 << 2,
            Next = 1 << 3,
            Between = 1 << 4,
        }
    }
}
