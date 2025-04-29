using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Argments
{
    /// <summary>
    /// テーブルコンテンツのページとレコード情報
    /// </summary>
    public class PageInformationArg
    {
        /// <summary>
        /// 全レコード数
        /// </summary>
        public int NumberOfRecords { get; }
        /// <summary>
        /// 検索結果からヒットした件数
        /// </summary>
        public int NumberOfMatchedRecords { get; }
        /// <summary>
        /// 全ページ数
        /// </summary>
        public int NumberOfPage { get; }
        /// <summary>
        /// 現在のページ
        /// </summary>
        public int PageNumber { get; }

        public PageInformationArg(int numberOfRecords, int numberOfMatchedRecords, int numberOfPage, int pageNumber)
        {
            NumberOfRecords = numberOfRecords;
            NumberOfMatchedRecords = numberOfMatchedRecords;
            NumberOfPage = numberOfPage;
            PageNumber = pageNumber;
        }
    }
}
