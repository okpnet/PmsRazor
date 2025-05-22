using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Intterfaces
{
    /// <summary>
    /// 可変な処理（イベントコールバック）を注入・実行できる
    /// </summary>
    public interface IActionDispatcher
    {
        void RegisterAction(string key, Action action);
        bool InvokeAction(string key);
    }
}
