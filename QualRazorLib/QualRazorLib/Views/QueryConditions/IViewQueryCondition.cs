using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Viewの状態とFacade条件DTOの相互変換を担うインターフェース
    /// </summary>
    public interface IViewQueryCondition<TQuery> :IViewQueryExtractor<TQuery>,IViewQueryRestorer<TQuery>
    {
    }
}
