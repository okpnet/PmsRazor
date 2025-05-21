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
        /// 取得ソースが有効かどうか
        /// </summary>
        public bool IsSourceEnabled { get; }
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

        protected PageInformationArg(bool isSourceEnabled, int numberOfRecords, int numberOfMatchedRecords, int numberOfPage, int pageNumber)
        {
            IsSourceEnabled = isSourceEnabled;
            NumberOfRecords = numberOfRecords;
            NumberOfMatchedRecords = numberOfMatchedRecords;
            NumberOfPage = numberOfPage;
            PageNumber = pageNumber;
        }

        public static PageInformationArg CreateFailArg()=>new PageInformationArg(false,0,0,0,0);

        public static PageInformationArg CreateSuccessArg(int numberOfRecords, int numberOfMatchedRecords, int numberOfPage, int pageNumber)
            => new(true, numberOfRecords, numberOfMatchedRecords, numberOfPage, pageNumber);
    }
}
