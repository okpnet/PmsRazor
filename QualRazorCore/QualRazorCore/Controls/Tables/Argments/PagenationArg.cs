using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Argments
{
    /// <summary>
    /// テーブルに表示されるページネーションのリンクアイテム
    /// </summary>
    public class PagenationArg
    {
        public bool Active { get; }

        public Func<string> GetLabelInvoke { get; }
        
        public int CurrentPageNumber { get; } = 1;

        public PagenationArg(bool active, Func<string> label, int currentPageNumber)
        {
            Active = active;
            GetLabelInvoke = label;
            CurrentPageNumber = currentPageNumber;
        }
    }
}
